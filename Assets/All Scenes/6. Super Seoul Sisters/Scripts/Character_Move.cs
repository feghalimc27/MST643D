using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Move : MonoBehaviour
{

    public float playerSpeed = 3;
    public int hasJumped = 0;
    private int playerJumpPower;
    private float moveX;
    public bool onGround = true;
    public bool onObstacle = false;
    public bool canDoubleJump = true;
    public float raycastDown = .3f;
    public int monsterPoints;
    public int duckPoints;

    public Player_Health _player_health;
    public Enemy_AI enemyAI;
    private ScoreManager _score_manager;

    public AudioClip playDeath;
    public AudioSource deathSound;
    public AudioClip playJump;
    private AudioSource jumpSound;
    public AudioClip playLanding;
    private AudioSource landingSound;
    public AudioClip playerMonsterDie;
    private AudioSource monsterDieSound;

    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject monster5;

    void Start()
    {
        jumpSound = GetComponent<AudioSource>();    // assign AudioSource
        monsterDieSound = GetComponent<AudioSource>();    // assign AudioSource
        landingSound = GetComponent<AudioSource>();    // assign AudioSource
        deathSound = GetComponent<AudioSource>();   // assign AudioSource

        _score_manager = FindObjectOfType<ScoreManager>();

        monsterPoints = 50;
        duckPoints = 100;
    }
    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        PlayerRaycast_duck();
    }

    // controls character movement and physics
    void CharacterMove()
    {
        moveX = Input.GetAxis("Horizontal");

        // jump
        if (Input.GetButtonDown("Jump") && (canDoubleJump == true || onGround == true || onObstacle == true))
        {
            if ((canDoubleJump == true && onGround == true))
            {
                playerJumpPower = 110;
                Jump();
            }
            else if (canDoubleJump == true && onGround == false)
            {
                playerJumpPower = 100;
                Jump();
            }
        }

        //animations
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        // determine what way the character is facing
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // physics stuff
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce((Vector2.up * playerJumpPower));
        onGround = false;
        hasJumped++;
        if (hasJumped >= 2)
        {
            canDoubleJump = false;
            hasJumped = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, 0);
        }
        jumpSound.PlayOneShot(playJump); // play sound
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //landingSound.PlayOneShot(playLanding); // play sound
            onGround = true;
            canDoubleJump = true;
            hasJumped = 0;
            onObstacle = false;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            onGround = false;
            onObstacle = true;
            hasJumped = 0;
            canDoubleJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Monster (1)")
        {
            if (onGround == true)
            {
                deathSound.PlayOneShot(playDeath); // play sound
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Character_Move>().enabled = false;
                Camera.main.GetComponent<Camera_System>().enabled = false;

                if (gameObject.transform.position.y < -6.38)
                {
                    SceneManager.LoadScene("Super Seoul Sisters");
                }
            }
            else if (onGround == false || onObstacle == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);
                monsterDieSound.PlayOneShot(playerMonsterDie); // play sound
                monster1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                monster1.GetComponent<Rigidbody2D>().gravityScale = 4;
                monster1.GetComponent<Rigidbody2D>().freezeRotation = false;
                monster1.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                monster1.GetComponent<BoxCollider2D>().enabled = false;
                monster1.GetComponent<Enemy_AI>().enabled = false;

                _score_manager.AddScore(monsterPoints);
            }
        }

        if (collision.name == "Monster (2)")
        {
            if (onGround == true)
            {
                deathSound.PlayOneShot(playDeath); // play sound
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Character_Move>().enabled = false;
                Camera.main.GetComponent<Camera_System>().enabled = false;

                if (gameObject.transform.position.y < -6.38)
                {
                    SceneManager.LoadScene("Super Seoul Sisters");
                }
            }
            else if (onGround == false || onObstacle == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);
                monsterDieSound.PlayOneShot(playerMonsterDie); // play sound
                monster2.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                monster2.GetComponent<Rigidbody2D>().gravityScale = 4;
                monster2.GetComponent<Rigidbody2D>().freezeRotation = false;
                monster2.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                monster2.GetComponent<BoxCollider2D>().enabled = false;
                monster2.GetComponent<Enemy_AI>().enabled = false;

                _score_manager.AddScore(monsterPoints);
            }
        }

        if (collision.name == "Monster (3)")
        {
            if (onGround == true)
            {
                deathSound.PlayOneShot(playDeath); // play sound
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Character_Move>().enabled = false;
                Camera.main.GetComponent<Camera_System>().enabled = false;

                if (gameObject.transform.position.y < -6.38)
                {
                    SceneManager.LoadScene("Super Seoul Sisters");
                }
            }
            else if (onGround == false || onObstacle == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);
                monsterDieSound.PlayOneShot(playerMonsterDie); // play sound
                monster3.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                monster3.GetComponent<Rigidbody2D>().gravityScale = 4;
                monster3.GetComponent<Rigidbody2D>().freezeRotation = false;
                monster3.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                monster3.GetComponent<BoxCollider2D>().enabled = false;
                monster3.GetComponent<Enemy_AI>().enabled = false;

                _score_manager.AddScore(monsterPoints);
            }
            
        }

        if (collision.name == "Monster (4)")
        {
            if (onGround == true)
            {
                deathSound.PlayOneShot(playDeath); // play sound
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Character_Move>().enabled = false;
                Camera.main.GetComponent<Camera_System>().enabled = false;

                if (gameObject.transform.position.y < -6.38)
                {
                    SceneManager.LoadScene("Super Seoul Sisters");
                }
            }
            else if (onGround == false || onObstacle == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);
                monsterDieSound.PlayOneShot(playerMonsterDie); // play sound
                monster4.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                monster4.GetComponent<Rigidbody2D>().gravityScale = 4;
                monster4.GetComponent<Rigidbody2D>().freezeRotation = false;
                monster4.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                monster4.GetComponent<BoxCollider2D>().enabled = false;
                monster4.GetComponent<Enemy_AI>().enabled = false;

                _score_manager.AddScore(monsterPoints);
            }
        }

        if (collision.name == "Monster (5)")
        {
            if (onGround == true)
            {
                deathSound.PlayOneShot(playDeath); // play sound
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                gameObject.GetComponent<Character_Move>().enabled = false;
                Camera.main.GetComponent<Camera_System>().enabled = false;

                if (gameObject.transform.position.y < -6.38)
                {
                    SceneManager.LoadScene("Super Seoul Sisters");
                }
            }
            else if (onGround == false || onObstacle == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);
                monsterDieSound.PlayOneShot(playerMonsterDie); // play sound
                monster5.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                monster5.GetComponent<Rigidbody2D>().gravityScale = 4;
                monster5.GetComponent<Rigidbody2D>().freezeRotation = false;
                monster5.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                monster5.GetComponent<BoxCollider2D>().enabled = false;
                monster5.GetComponent<Enemy_AI>().enabled = false;

                _score_manager.AddScore(monsterPoints);
            }
        }
    }

    void PlayerRaycast_duck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit != null && hit.collider != null && hit.distance < raycastDown && hit.collider.tag == "Duck")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);

            if (hit != null && hit.collider != null && hit.collider.tag == "Duck")
            {
                hit.collider.gameObject.GetComponent<Minions>().enabled = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<EdgeCollider2D>().enabled = false;

                _score_manager.AddScore(duckPoints);
            }
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit != null && hit.collider != null && hit.distance < raycastDown && hit.collider.tag == "Enemy")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);

            if (hit != null && hit.collider != null && hit.collider.tag == "Enemy")
            {
                monsterDieSound.PlayOneShot(playerMonsterDie); // play sound
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<Enemy_AI>().enabled = false;

            }
        }
    }
}

