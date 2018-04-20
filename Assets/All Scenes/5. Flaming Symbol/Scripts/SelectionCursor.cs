using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCursor : MonoBehaviour {

    public int movementCooldown;

    private float speed = 0.5f;
    private int coolCounter = 0;

    [HideInInspector]
    public GameObject player = null;
    [HideInInspector]
    public GameObject enemy = null;

	private Vector3 startPos;
	private float endPosPlusX;
	private float endPosMinusX;
	private float endPosPlusY;
	private float endPosMinusY;

	[SerializeField]
	private GameObject[] blocking = new GameObject[4];
	private bool[] blocked = new bool[4];

    [SerializeField]
    private float deadzone = 0.4f;

    private int movCountX = 0;
	private int movCountY = 0;

    [HideInInspector]
	public bool unitSelected = false;
	private bool attacking = false;

	private Animator playerAnimator;

    Coroutine attackAnimation;
    Coroutine endTurn;

	// Use this for initialization
	void Start () {
		
    }

    void OnEnable() {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnDisable() {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		MoveCursor();
		HandleAnimations();
		GetEnemy();
		SelectUnit();
		UpdateCounter();
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			player = collision.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			player = null;
		}
	}

	void MoveCursor() {
		Vector3 move = new Vector3(0, 0, 0);

		if (unitSelected) {

			for (int i = 0; i < 4; ++i) {
				blocked[i] = blocking[i].GetComponent<CursorBlock>().blocked;
			}

            
			if ((transform.position + move).x < endPosPlusX && Input.GetAxis("Horizontal") > deadzone && coolCounter == 0 && !blocked[2]) { // right
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.x += speed;
					movCountX += 1;
				}
				else if (movCountX < 0) {
					move.x += speed;
					movCountX += 1;
				}

				coolCounter = movementCooldown;
			}
			else if ((transform.position - move).x > endPosMinusX && Input.GetAxis("Horizontal") < -deadzone && coolCounter == 0 && !blocked[3]) { // left
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.x -= speed;
					movCountX -= 1;
				}
				else if (movCountX > 0) {
					move.x -= speed;
					movCountX -= 1;
				}

				coolCounter = movementCooldown;
			}
			else if ((transform.position + move).y < endPosPlusY && Input.GetAxis("Vertical") > deadzone && coolCounter == 0 && !blocked[0]) { // up
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.y += speed;
					movCountY += 1;
				}
				else if (movCountY < 0) {
					move.y += speed;
					movCountY += 1;
				}

				coolCounter = movementCooldown;
			}
			else if ((transform.position - move).y > endPosMinusY && Input.GetAxis("Vertical") < -deadzone && coolCounter == 0 && !blocked[1]) { // down
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.y -= speed;
					movCountY -= 1;
				}
				else if (movCountY > 0) {
					move.y -= speed;
					movCountY -= 1;
				}

				coolCounter = movementCooldown;
			}
		}
		else {
			if (Input.GetAxis("Horizontal") > deadzone && coolCounter == 0) {
				move.x += speed;

				coolCounter = movementCooldown;
			}
			else if (Input.GetAxis("Horizontal") < -deadzone && coolCounter == 0) {
				move.x -= speed;

				coolCounter = movementCooldown;
			}
			else if (Input.GetAxis("Vertical") > deadzone && coolCounter == 0) {
				move.y += speed;

				coolCounter = movementCooldown;
			}
			else if (Input.GetAxis("Vertical") < -deadzone && coolCounter == 0) {
				move.y -= speed;

				coolCounter = movementCooldown;
			}
		}
		

		transform.position += move;
		if (unitSelected) {
			player.transform.position += move;
		}
	}

	void SelectUnit() {
		if (player != null) {
			if (Input.GetButtonDown("Jump") && !unitSelected && !player.GetComponent<FEFriendlyUnit>().turnOver) {
				unitSelected = true;

				startPos = player.transform.position;
				float movRange = player.GetComponent<FEFriendlyUnit>().mov * speed;

				endPosPlusX = startPos.x + movRange;
				endPosMinusX = startPos.x - movRange;
				endPosPlusY = startPos.y + movRange;
				endPosMinusY = startPos.y - movRange;
			}
			else if (Input.GetButtonDown("Jump") && unitSelected) {
				if (enemy != null) {
					LoadAttackState();
				}
				unitSelected = false;
                player.GetComponent<FEFriendlyUnit>().turnOver = true;
                Debug.Log(transform.position);
                if (transform.position == new Vector3(6.92f, 4.52f, 0)) {
                    EndLevel();
                }

                movCountX = 0;
				movCountY = 0;
			}
		}
	}

    public GameObject GetSelectedUnit() {
        if (unitSelected) {
            return player;
        }
        else {
            return null;
        }
    }

	void UpdateCounter() {
		if (coolCounter > 0) {
			coolCounter--;
		}
	}

	void GetEnemy() {
		foreach (var block in blocking) {
			if (block.GetComponent<CursorBlock>().enemy != null) {
				enemy = block;
				break;
			}
			else {
				enemy = null;
			}
		}
	}

	void LoadAttackState() {
		FEFriendlyUnit playerStats = player.GetComponent<FEFriendlyUnit>();
		FEHostileUnit enemyStats = null;
		playerAnimator = player.GetComponent<Animator>();

		enemyStats = enemy.GetComponent<CursorBlock>().enemy.GetComponent<FEHostileUnit>();

		int accuracy = 69;

		if (enemy == null) {
			attacking = false;
			Debug.Log("No Enemy");
			return;
		}

		int playerChance = accuracy + playerStats.skl * 2 + playerStats.lck / 2;
		int enemyChance = accuracy + enemyStats.skl * 2 + enemyStats.lck / 2;

		bool playerHit = (Random.Range(0, 100) <= playerChance);
		bool enemyHit = (Random.Range(0, 100) <= enemyChance);

		if (playerHit) {
			attacking = true;
			attackAnimation = StartCoroutine("AttackAnimation");
			playerAnimator.SetBool("attackPhase", attacking);

			bool crit = (Random.Range(0, 100) <= playerStats.lck);
			bool outSpeed = playerStats.GetCurrentSpd() > (enemyStats.GetCurrentSpd() + 5);
			int damage = playerStats.atk - enemyStats.def;

			if (damage <= 1) {
				damage = 1;
			}

			if (outSpeed) {
				damage *= 2;
			}

			if (crit) {
				damage *= 3;
			}

			if (damage >= enemyStats.GetCurrentHP()) {
				enemy.GetComponent<CursorBlock>().enemy.GetComponent<FEHostileUnit>().SendMessage("TakeDamage", damage);
                enemy = null;
            }
			else {
				enemy.GetComponent<CursorBlock>().enemy.GetComponent<FEHostileUnit>().SendMessage("TakeDamage", damage);
			}

        }

		if (enemyStats && enemy != null) {
			bool crit = (Random.Range(0, 100) <= playerStats.lck);
			bool outSpeed = enemyStats.GetCurrentSpd() > (playerStats.GetCurrentSpd() + 5);
			int damage = enemyStats.atk - playerStats.def;

			if (damage <= 1) {
				damage = 1;
			}

			if (outSpeed) {
				damage *= 2;
			}

			if (crit) {
				damage *= 3;
			}

			player.GetComponent<FEFriendlyUnit>().SendMessage("TakeDamage", damage);
		}

		attacking = false;
	}

	void HandleAnimations() {
		if (player != null && !attacking) {
			playerAnimator = player.GetComponent<Animator>();

			playerAnimator.SetBool("unitSelected", unitSelected);
			playerAnimator.SetBool("attackPhase", attacking);
		}
	}

	IEnumerator AttackAnimation() {

		Vector3 playerPos = player.transform.position;
		float animScale = 0.04f;
		Vector3 direction = (enemy.transform.position - playerPos).normalized;

		int i = 0;

		for (i = 0; i < 5; ++i) {
			playerPos += direction * animScale;
			player.transform.position = playerPos;

            yield return null;
		}

		if (i >= 4) {
			for (i = 5; i < 10; ++i) {
				playerPos -= direction * animScale;
				player.transform.position = playerPos;

                yield return null;
			}
		}

        StopCoroutine(attackAnimation);
        attackAnimation = null;
	}

    IEnumerator WaitBeforeEnd() {
        yield return new WaitForSeconds(0.3f);
    }

    void EndLevel() {
        DontDestroyOnLoad(new GameObject("levelCompleted"));
    }
}
