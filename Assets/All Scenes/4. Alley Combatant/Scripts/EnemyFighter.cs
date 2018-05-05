using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFighter : MonoBehaviour
{
    public static int enemyHealth;

    public GameObject playerObject;

    public SpriteRenderer enemySpriteRenderer;
    public AudioSource audioSource;

    public Sprite standingSprite;
    public Sprite aerialSprite;
    public Sprite hitSprite;
    public Sprite blockSprite;

    public Sprite deathSprite_1;
    public Sprite deathSprite_2;

    public Sprite punchGroundedSprite;
    public Sprite kickGroundedSprite;
    public Sprite punchAerialSprite;
    public Sprite kickAerialSprite;

    public GameObject punchGroundedHitbox;
    public GameObject kickGroundedHitbox;
    public GameObject punchAerialHitbox;
    public GameObject kickAerialHitbox;

    public AudioClip hurtClip;
    public AudioClip deathClip;
    public AudioClip whiffClip;
    public AudioClip punchGroundedClip;
    public AudioClip kickGroundedClip;
    public AudioClip punchAerialClip;
    public AudioClip kickAerialClip;

    bool isGrounded;
    bool attacking;
    bool aerialAttack;
    bool hitStun;
    bool isBlocking;

    Coroutine currentMoveCR;
    Coroutine deathCR;

    float enemyHorizontalAxis;
    bool enemyAPress;
    bool enemyBPress;
    bool enemyYPress;

    int frameCounter;

    float lastHit;

    void computerFight()
    {
        if (PlayerFighter.playerHealth > 0)
        {
            if (Vector2.Distance(transform.position, playerObject.transform.position) > 150)
            {
                enemyHorizontalAxis = Random.Range(-0.5f, -1.0f);
            }
            else if (Vector2.Distance(transform.position, playerObject.transform.position) < 140)
            {
                enemyHorizontalAxis = Random.Range(0.5f, 1.0f);
            }
            else
            {
                enemyHorizontalAxis = 0;
            }

            if (frameCounter < Random.Range(60, 360))
            {
                frameCounter++;
            }
            else
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        StartCoroutine(EnemyAPress());
                        break;
                    case 1:
                        StartCoroutine(EnemyBPress());
                        break;
                    case 2:
                        StartCoroutine(EnemyYPress());
                        break;
                }
                frameCounter = 0;
            }
        }
    }

    void Awake()
    {
        enemyHealth = 100;
        isGrounded = true;
        attacking = false;
        aerialAttack = false;
        hitStun = false;
        isBlocking = false;
        frameCounter = 0;
        lastHit = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time > lastHit + 0.5f && enemyHealth > 0)
        {
            if (collision.gameObject.tag == "PlayerPunchGrounded")
            {
                audioSource.PlayOneShot(hurtClip);
                audioSource.PlayOneShot(punchGroundedClip);
                lastHit = Time.time;
                StopAllCoroutines();
                disableHitboxes();
                if (isBlocking == true)
                {
                    StartCoroutine(HitBlocked());
                }
                else
                {
                    enemyHealth -= 3;
                    StartCoroutine(Hit());
                }
            }
            else if (collision.gameObject.tag == "PlayerKickGrounded")
            {
                audioSource.PlayOneShot(hurtClip);
                audioSource.PlayOneShot(kickGroundedClip);
                lastHit = Time.time;
                StopAllCoroutines();
                disableHitboxes();
                if (isBlocking == true)
                {
                    StartCoroutine(HitBlocked());
                }
                else
                {
                    enemyHealth -= 6;
                    StartCoroutine(Hit());
                }
            }
            else if (collision.gameObject.tag == "PlayerPunchAerial")
            {
                audioSource.PlayOneShot(hurtClip);
                audioSource.PlayOneShot(punchAerialClip);
                lastHit = Time.time;
                StopAllCoroutines();
                disableHitboxes();
                if (isBlocking == true)
                {
                    enemyHealth -= 5;
                    StartCoroutine(HitBlocked());
                }
                else
                {
                    enemyHealth -= 8;
                    StartCoroutine(Hit());
                }
            }
            else if (collision.gameObject.tag == "PlayerKickAerial")
            {
                audioSource.PlayOneShot(hurtClip);
                audioSource.PlayOneShot(kickAerialClip);
                lastHit = Time.time;
                StopAllCoroutines();
                disableHitboxes();
                if (isBlocking == true)
                {
                    enemyHealth -= 7;
                    StartCoroutine(HitBlocked());
                }
                else
                {
                    enemyHealth -= 10;
                    StartCoroutine(Hit());
                }
            }
        }
    }

    void Update()
    {
        computerFight();

        if (Time.timeScale == 1 && enemyHealth > 0)
        {
            if (enemyHorizontalAxis >= 0.85f && hitStun == false)
            {
                isBlocking = true;
            }
            else if (hitStun == false)
            {
                isBlocking = false;
            }

            if (isBlocking == true && hitStun == true)
            {
                enemySpriteRenderer.sprite = blockSprite;
            }

            if (enemyAPress && isGrounded == true && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(PunchGrounded());
            }
            else if (enemyBPress && isGrounded == true && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(KickGrounded());
            }
            else if (enemyYPress && isGrounded == true && attacking == false && hitStun == false)
            {
                jump();
            }
            else if (enemyAPress && isGrounded == false && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(PunchAerial());
            }
            else if (enemyBPress && isGrounded == false && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(KickAerial());
            }

            if (hitStun == true)
            {
                enemySpriteRenderer.sprite = hitSprite;
            }
            else if (isGrounded == true && attacking == false && hitStun == false)
            {
                enemySpriteRenderer.sprite = standingSprite;
            }
            else if (isGrounded == false && attacking == false && hitStun == false)
            {
                enemySpriteRenderer.sprite = aerialSprite;
            }
        }

        if (enemyHealth <= 0 && deathCR == null)
        {
            StopAllCoroutines();
            disableHitboxes();
            deathCR = StartCoroutine(Death());
        }
    }

    void FixedUpdate()
    {
        if (hitStun == true)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(500f, 0);
        }
        else if (isGrounded == true && attacking == true)
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if (enemyHealth > 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyHorizontalAxis * 250f, transform.GetComponent<Rigidbody2D>().velocity.y);
        }


        if (transform.position.y <= -135.5f + 0.1f)
        {
            isGrounded = true;
            if (currentMoveCR != null && aerialAttack == true)
            {
                StopCoroutine(currentMoveCR);
                disableHitboxes();
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    IEnumerator PunchGrounded()
    {
        attacking = true;
        for (int i = 0; i < 4; i++)
        {
            yield return null;
        }
        audioSource.PlayOneShot(whiffClip);
        enemySpriteRenderer.sprite = punchGroundedSprite;
        punchGroundedHitbox.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            yield return null;
        }
        punchGroundedHitbox.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            yield return null;
        }
        attacking = false;
    }

    IEnumerator KickGrounded()
    {
        attacking = true;
        for (int i = 0; i < 5; i++)
        {
            yield return null;
        }
        audioSource.PlayOneShot(whiffClip);
        enemySpriteRenderer.sprite = kickGroundedSprite;
        kickGroundedHitbox.SetActive(true);
        for (int i = 0; i < 8; i++)
        {
            yield return null;
        }
        kickGroundedHitbox.SetActive(false);
        for (int i = 0; i < 7; i++)
        {
            yield return null;
        }
        attacking = false;
    }

    void jump()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 12500f));
    }

    IEnumerator PunchAerial()
    {
        attacking = true;
        aerialAttack = true;
        for (int i = 0; i < 6; i++)
        {
            yield return null;
        }
        audioSource.PlayOneShot(whiffClip);
        enemySpriteRenderer.sprite = punchAerialSprite;
        punchAerialHitbox.SetActive(true);
        for (int i = 0; i < 16; i++)
        {
            yield return null;
        }
        punchAerialHitbox.SetActive(false);
        for (int i = 0; i < 12; i++)
        {
            yield return null;
        }
        attacking = false;
        aerialAttack = false;
    }

    IEnumerator KickAerial()
    {
        attacking = true;
        aerialAttack = true;
        for (int i = 0; i < 8; i++)
        {
            yield return null;
        }
        audioSource.PlayOneShot(whiffClip);
        enemySpriteRenderer.sprite = kickAerialSprite;
        kickAerialHitbox.SetActive(true);
        for (int i = 0; i < 20; i++)
        {
            yield return null;
        }
        kickAerialHitbox.SetActive(false);
        for (int i = 0; i < 16; i++)
        {
            yield return null;
        }
        attacking = false;
        aerialAttack = false;
    }

    IEnumerator Hit()
    {
        hitStun = true;
        for (int i = 0; i < 10; i++)
        {
            yield return null;
        }
        hitStun = false;
    }

    IEnumerator HitBlocked()
    {
        hitStun = true;
        for (int i = 0; i < 5; i++)
        {
            yield return null;
        }
        hitStun = false;
    }

    IEnumerator Death()
    {
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        audioSource.PlayOneShot(punchGroundedClip);
        enemySpriteRenderer.sprite = deathSprite_1;
        yield return new WaitForSecondsRealtime(2);
        audioSource.PlayOneShot(deathClip);
        enemySpriteRenderer.sprite = deathSprite_2;
    }

    IEnumerator EnemyAPress()
    {
        enemyAPress = true;
        yield return null;
        enemyAPress = false;
    }

    IEnumerator EnemyBPress()
    {
        enemyBPress = true;
        yield return null;
        enemyBPress = false;
    }

    IEnumerator EnemyYPress()
    {
        enemyYPress = true;
        yield return null;
        enemyYPress = false;
        for (int i = 0; i < Random.Range(15, 31); i++)
        {
            yield return null;
        }
        switch (Random.Range(0, 2))
        {
            case 0:
                StartCoroutine(EnemyAPress());
                break;
            case 1:
                StartCoroutine(EnemyAPress());
                break;
        }
    }

    void disableHitboxes()
    {
        hitStun = false;
        attacking = false;
        aerialAttack = false;
        punchGroundedHitbox.SetActive(false);
        kickGroundedHitbox.SetActive(false);
        punchAerialHitbox.SetActive(false);
        kickAerialHitbox.SetActive(false);
    }
}