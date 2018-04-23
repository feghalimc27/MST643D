using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MerryController : MonoBehaviour
{
    public static int merryHealth;

    bool isInvulnerable;

    void Start()
    {
        merryHealth = 5;
        isInvulnerable = false;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && isInvulnerable == false)
        {
            merryHealth--;
            Destroy(collision.gameObject);
            StartCoroutine(Invulnerable());
        }
    }

    void Update()
    {
        if (merryHealth == 0)
        {
            SceneManager.LoadScene(8);
        }
    }

    void FixedUpdate ()
    {
        Vector2 x = new Vector2(1, 0) * Input.GetAxis("Horizontal") * Time.fixedDeltaTime * 150f;
        Vector2 y = new Vector2(0, 1) * Input.GetAxis("Vertical") * Time.fixedDeltaTime * 150f;
        transform.GetComponent<Rigidbody2D>().MovePosition(transform.GetComponent<Rigidbody2D>().position + x + y);
    }

    IEnumerator Invulnerable()
    {
        isInvulnerable = true;
        transform.GetComponent<SpriteRenderer>().color = new Color(1,1, 1, 0.5f);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        isInvulnerable = false;
    }
}
