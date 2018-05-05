using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFighter : MonoBehaviour
{
    public static int playerHealth;

    public SpriteRenderer playerSpriteRenderer;
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

    float lastHit;

    void Awake()
    {
        playerHealth = 100;
        isGrounded = true;
        attacking = false;
        aerialAttack = false;
        hitStun = false;
        isBlocking = false;
        lastHit = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time > lastHit + 0.5f && playerHealth > 0)
        {
            if (collision.gameObject.tag == "EnemyPunchGrounded")
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
                    playerHealth -= 4;
                    StartCoroutine(Hit());
                }
            }
            else if (collision.gameObject.tag == "EnemyKickGrounded")
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
                    playerHealth -= 8;
                    StartCoroutine(Hit());
                }
            }
            else if (collision.gameObject.tag == "EnemyPunchAerial")
            {
                audioSource.PlayOneShot(hurtClip);
                audioSource.PlayOneShot(punchAerialClip);
                lastHit = Time.time;
                StopAllCoroutines();
                disableHitboxes();
                if (isBlocking == true)
                {
                    playerHealth -= 8;
                    StartCoroutine(HitBlocked());
                }
                else
                {
                    playerHealth -= 11;
                    StartCoroutine(Hit());
                }
            }
            else if (collision.gameObject.tag == "EnemyKickAerial")
            {
                audioSource.PlayOneShot(hurtClip);
                audioSource.PlayOneShot(kickAerialClip);
                lastHit = Time.time;
                StopAllCoroutines();
                disableHitboxes();
                if (isBlocking == true)
                {
                    playerHealth -= 10;
                    StartCoroutine(HitBlocked());
                }
                else
                {
                    playerHealth -= 13;
                    StartCoroutine(Hit());
                }
            }
        }
    }

    void Update()
    {
        if (Time.timeScale == 1 && playerHealth > 0)
        {
            if (Input.GetAxis("Horizontal") <= -0.85f && hitStun == false)
            {
                isBlocking = true;
            }
            else if (hitStun == false)
            {
                isBlocking = false;
            }

            if (isBlocking == true && hitStun == true)
            {
                playerSpriteRenderer.sprite = blockSprite;
            }

            if (Input.GetButtonDown("A Button") && isGrounded == true && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(PunchGrounded());
            }
            else if (Input.GetButtonDown("B Button") && isGrounded == true && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(KickGrounded());
            }
            else if (Input.GetButtonDown("Y Button") && isGrounded == true && attacking == false && hitStun == false)
            {
                jump();
            }
            else if (Input.GetButtonDown("A Button") && isGrounded == false && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(PunchAerial());
            }
            else if (Input.GetButtonDown("B Button") && isGrounded == false && attacking == false && hitStun == false)
            {
                currentMoveCR = StartCoroutine(KickAerial());
            }

            if (hitStun == true)
            {
                playerSpriteRenderer.sprite = hitSprite;
            }
            else if (isGrounded == true && attacking == false && hitStun == false)
            {
                playerSpriteRenderer.sprite = standingSprite;
            }
            else if (isGrounded == false && attacking == false && hitStun == false)
            {
                playerSpriteRenderer.sprite = aerialSprite;
            }
        }

        if (playerHealth <= 0 && deathCR == null)
        {
            StopAllCoroutines();
            disableHitboxes();
            deathCR = StartCoroutine(Death());
        }
    }

    void FixedUpdate ()
    {
        if (hitStun == true)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-500f, 0);
        }
        else if (isGrounded == true && attacking == true)
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if (playerHealth > 0)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * 250f, transform.GetComponent<Rigidbody2D>().velocity.y);
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
        playerSpriteRenderer.sprite = punchGroundedSprite;
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
        playerSpriteRenderer.sprite = kickGroundedSprite;
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
        playerSpriteRenderer.sprite = punchAerialSprite;
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
        playerSpriteRenderer.sprite = kickAerialSprite;
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
        playerSpriteRenderer.sprite = deathSprite_1;
        yield return new WaitForSecondsRealtime(2);
        audioSource.PlayOneShot(deathClip);
        playerSpriteRenderer.sprite = deathSprite_2;
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
