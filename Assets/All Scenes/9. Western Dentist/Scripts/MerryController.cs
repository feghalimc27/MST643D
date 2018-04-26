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
            Destroy(collision.gameObject);
            StartCoroutine(Hit());
        }
    }

    void Update()
    {
        if (merryHealth == 0)
        {
            SceneManager.LoadScene(9);
        }
    }

    void FixedUpdate ()
    {
        Vector2 x = new Vector2(1, 0) * Input.GetAxis("Horizontal") * Time.fixedDeltaTime * 200f;
        Vector2 y = new Vector2(0, 1) * Input.GetAxis("Vertical") * Time.fixedDeltaTime * 200f;
        transform.GetComponent<Rigidbody2D>().MovePosition(transform.GetComponent<Rigidbody2D>().position + x + y);
    }

    IEnumerator Hit()
    {
        isInvulnerable = true;
        Time.timeScale = 0;
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.GetComponent<SpriteRenderer>().color = new Color(t, 1 - t, 1 - t, 1);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        Time.timeScale = 1;
        merryHealth--;
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
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.15f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.15f);
        isInvulnerable = false;
    }
}
