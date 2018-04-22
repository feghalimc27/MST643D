using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour {

	private FEHostileUnit[] units;

	private int currentUnit;
	private int tempCounter = 0;
	private int unitMoves = 0;
	private int waitStart = 300;

    [SerializeField]
    private float movSpeed = 0.5f;

	public bool turnOver = true;

	Coroutine moveUnits = null;
    Coroutine attackAnimation = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (units.Length > 0 && moveUnits == null) {
			moveUnits = StartCoroutine("MoveUnits");
		}

		if (units.Length <= 0) {
			GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartPlayerManager");
		}

		if (currentUnit >= units.Length) {
			GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartPlayerManager");
		}
	}

	private void OnEnable() {
		units = GetComponentsInChildren<FEHostileUnit>();
		turnOver = false;
		tempCounter = 0;
		currentUnit = 0;
	}

	private void OnDisable() {
		turnOver = true;
	}

	IEnumerator MoveUnits() {
		while (!turnOver) {
			FEHostileUnit stats = units[currentUnit];
			if (units[currentUnit].fade == null && units[currentUnit] != null) {
                FEFriendlyUnit playerStats = GameObject.Find("unit").GetComponent<FEFriendlyUnit>();
				Vector3 position = stats.gameObject.transform.position;
                Vector3 playerPos = GameObject.Find("unit").transform.position;

                bool attack = false;
                GameObject player = null;
                foreach (var block in stats.blocking) {
                    if (block.GetComponent<EnemyBlock>().canAttack) {
                        attack = true;
                        player = block.GetComponent<EnemyBlock>().player;
                    }
                }

                if (attack) {
                    int accuracy = 69;

                    playerStats = player.GetComponent<FEFriendlyUnit>();
                    int playerChance = accuracy + playerStats.skl * 2 + playerStats.lck / 2;
                    int chance = accuracy + stats.skl * 2 + stats.lck / 2;

                    bool playerHit = (Random.Range(0, 100) <= playerChance);
                    bool hit = (Random.Range(0, 100) <= chance);

                    yield return StartCoroutine("AttackAnimation");

                    if (hit) {

                        bool crit = (Random.Range(0, 100) <= stats.lck);
                        bool outSpeed = (stats.GetCurrentSpd() > (playerStats.GetCurrentSpd() + 5));
                        int damage = stats.atk - playerStats.def;

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
                        if (damage >= playerStats.GetCurrentHP()) {
                            player = null;
                        }
                    }

                    if (playerHit && player != null) {

                        bool crit = (Random.Range(0, 100) <= playerStats.lck);
                        bool outSpeed = (playerStats.GetCurrentSpd() > (stats.GetCurrentSpd() + 5));
                        int damage = playerStats.atk - stats.def;

                        if (damage <= 1) {
                            damage = 1;
                        }

                        if (outSpeed) {
                            damage *= 2;
                        }

                        if (crit) {
                            damage *= 3;
                        }

                        units[currentUnit].SendMessage("TakeDamage", damage);
                    }

                    unitMoves = 0;
                    currentUnit++;
                    if (currentUnit >= units.Length) {
                        turnOver = true;
                        break;
                    }
                }                
                else if (unitMoves < stats.mov && tempCounter == 0) {
                    if (playerPos.y > position.y) {
                        // Player north
                        if (!stats.blocked[0]) {
                            position.y += movSpeed;
                        }
                        else if (playerPos.x > position.x && !stats.blocked[2]) {
                            position.x += movSpeed;
                        }
                        else if (playerPos.x < position.x && !stats.blocked[3]) {
                            position.x -= movSpeed;
                        }
                        else if (!stats.blocked[1]) {
                            position.y -= movSpeed;
                        }
                    }
                    else if (playerPos.y < position.y) {
                        // Player south
                        if (!stats.blocked[1]) {
                            position.y -= movSpeed;
                        }
                        else if (playerPos.x > position.x && !stats.blocked[2]) {
                            position.x += movSpeed;
                        }
                        else if (playerPos.x < position.x && !stats.blocked[3]) {
                            position.x -= movSpeed;
                        }
                        else if (!stats.blocked[0]) {
                            position.y += movSpeed;
                        }
                    }
                    else if (playerPos.x > position.x) {
                        // Player east
                        if (!stats.blocked[2]) {
                            position.x += movSpeed;
                        }
                        else if (playerPos.y > position.y && !stats.blocked[0]) {
                            position.y += movSpeed;
                        }
                        else if (playerPos.y < position.y && !stats.blocked[1]) {
                            position.x -= movSpeed;
                        }
                        else if (!stats.blocked[3]) {
                            position.x -= movSpeed;
                        }
                    }
                    else if (playerPos.x < position.x) {
                        // Player west
                        if (!stats.blocked[3]) {
                            position.x -= movSpeed;
                        }
                        else if (playerPos.y > position.y && !stats.blocked[0]) {
                            position.y += movSpeed;
                        }
                        else if (playerPos.y < position.y && !stats.blocked[1]) {
                            position.x -= movSpeed;
                        }
                        else if (!stats.blocked[2]) {
                            position.x += movSpeed;
                        }
                    }

                    unitMoves++;
					stats.gameObject.transform.position = position;
					tempCounter = 7;
				}
				else if (tempCounter > 0) {
					tempCounter--;
				}
				else {
					unitMoves = 0;
					currentUnit++;
					if (currentUnit >= units.Length) {
						turnOver = true;
						break;
					}
				}
			}
			else if (units[currentUnit] == null) {
				currentUnit++;
			}

			yield return null;
		}

		StopCoroutine(moveUnits);
        moveUnits = null;
	}

    IEnumerator AttackAnimation() {
        GameObject player = null;
        
        foreach (var block in units[currentUnit].blocking) {
            if (block.GetComponent<EnemyBlock>().canAttack) {
                player = block.GetComponent<EnemyBlock>().player;
            }
        }

        Vector3 playerPos = player.transform.position;
        Vector3 position = units[currentUnit].gameObject.transform.position;
        float animScale = 0.04f;
        Vector3 direction = (position - playerPos).normalized;

        int i = 0;

        for (i = 0; i < 5; ++i) {
            playerPos += direction * animScale;
            position -= direction * animScale;
            player.transform.position = playerPos;
            units[currentUnit].gameObject.transform.position = position;

            yield return null;
        }

        if (i >= 4) {
            for (i = 5; i < 10; ++i) {
                playerPos -= direction * animScale;
                position += direction * animScale;
                player.transform.position = playerPos;
                units[currentUnit].gameObject.transform.position = position;

                yield return null;
            }
        }
    }
}
