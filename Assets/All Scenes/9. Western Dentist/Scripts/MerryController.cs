using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MerryController : MonoBehaviour
{
    public static int merryHealth;
    public GameObject soul;
    public GameObject instantiator1;
    public GameObject instantiator2;
    public GameObject instantiator3;
    public GameObject instantiator4;
    public GameObject instantiator5;
    public GameObject instantiator6;
    public GameObject instantiator7;
    public GameObject instantiator8;
    public GameObject instantiator9;
    public GameObject instantiator10;
    public GameObject instantiator11;
    public GameObject instantiator12;
    public Animator merryAnim;

    public Material spriteMaterial;

    public GameObject bossGameObject;
    
    float lastFire;
    bool hit;

    void Start()
    {
        hit = false;
        merryHealth = 5;
        lastFire = 0;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && hit == false)
        {
            Destroy(collision.gameObject);
            StartCoroutine(Hit());
        }
    }

    void Update()
    {
        soul.transform.position = transform.position;
        merryAnim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        merryAnim.SetInteger("TimeScale", (int)Time.timeScale);

        if (merryHealth == 0)
        {
            SceneManager.LoadScene(9);
        }

        if (Input.GetButton("Fire1") && Time.time > lastFire + 0.15f && Time.timeScale == 1)
        {
            fire();
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
        hit = true;
        Time.timeScale = 0;
        soul.transform.localScale = new Vector3(1, 1, 1);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime * 4)
        {
            spriteMaterial.color = new Color(t, 0, 0, 1);
            yield return null;
        }
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            if (BossController.phase1Health > 0 && BossController.phase1Health != 500)
            {
                BossController.phase1Health++;
            }
            else if (BossController.phase2Health > 0 && BossController.phase2Health != 1000)
            {
                BossController.phase2Health++;
            }
            else if (BossController.phase3Health > 0 && BossController.phase3Health != 1500)
            {
                BossController.phase3Health++;
            }
            else if (BossController.phase4Health > 0 && BossController.phase4Health != 2000)
            {
                BossController.phase4Health++;
            }
            yield return null;
        }
        spriteMaterial.color = new Color(1, 1, 1, 1);
        soul.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        GameObject[] allProjectiles = GameObject.FindGameObjectsWithTag("Projectile");
        for (int i = 0; i < allProjectiles.Length; i++)
        {
            Destroy(allProjectiles[i]);
        }
        bossGameObject.GetComponent<BossController>().restartPhase();
        merryHealth--;
        Time.timeScale = 1;
        hit = false;
    }

    void fire()
    {
        lastFire = Time.time;
        GameObject projectile1 = Instantiate(Resources.Load("PlayerProjectile"), instantiator1.transform.position, instantiator1.transform.rotation) as GameObject;
        GameObject projectile2 = Instantiate(Resources.Load("PlayerProjectile"), instantiator2.transform.position, instantiator2.transform.rotation) as GameObject;
        GameObject projectile3 = Instantiate(Resources.Load("PlayerProjectile"), instantiator3.transform.position, instantiator3.transform.rotation) as GameObject;
        GameObject projectile4 = Instantiate(Resources.Load("PlayerProjectile"), instantiator4.transform.position, instantiator4.transform.rotation) as GameObject;
        GameObject projectile5 = Instantiate(Resources.Load("PlayerProjectile"), instantiator5.transform.position, instantiator5.transform.rotation) as GameObject;
        GameObject projectile6 = Instantiate(Resources.Load("PlayerProjectile"), instantiator6.transform.position, instantiator6.transform.rotation) as GameObject;
        GameObject projectile7 = Instantiate(Resources.Load("PlayerProjectile"), instantiator7.transform.position, instantiator7.transform.rotation) as GameObject;
        GameObject projectile8 = Instantiate(Resources.Load("PlayerProjectile"), instantiator8.transform.position, instantiator8.transform.rotation) as GameObject;
        GameObject projectile9 = Instantiate(Resources.Load("PlayerProjectile"), instantiator9.transform.position, instantiator9.transform.rotation) as GameObject;
        GameObject projectile10 = Instantiate(Resources.Load("PlayerProjectile"), instantiator10.transform.position, instantiator10.transform.rotation) as GameObject;
        GameObject projectile11 = Instantiate(Resources.Load("PlayerProjectile"), instantiator11.transform.position, instantiator11.transform.rotation) as GameObject;
        GameObject projectile12 = Instantiate(Resources.Load("PlayerProjectile"), instantiator12.transform.position, instantiator12.transform.rotation) as GameObject;
        projectile1.GetComponent<Rigidbody2D>().velocity = projectile1.transform.up * 1000;
        projectile2.GetComponent<Rigidbody2D>().velocity = projectile2.transform.up * 1000;
        projectile3.GetComponent<Rigidbody2D>().velocity = projectile3.transform.up * 1000;
        projectile4.GetComponent<Rigidbody2D>().velocity = projectile4.transform.up * 1000;
        projectile5.GetComponent<Rigidbody2D>().velocity = projectile5.transform.up * 1000;
        projectile6.GetComponent<Rigidbody2D>().velocity = projectile6.transform.up * 1000;
        projectile7.GetComponent<Rigidbody2D>().velocity = projectile7.transform.up * 1000;
        projectile8.GetComponent<Rigidbody2D>().velocity = projectile8.transform.up * 1000;
        projectile9.GetComponent<Rigidbody2D>().velocity = projectile9.transform.up * 1000;
        projectile10.GetComponent<Rigidbody2D>().velocity = projectile10.transform.up * 1000;
        projectile11.GetComponent<Rigidbody2D>().velocity = projectile11.transform.up * 1000;
        projectile12.GetComponent<Rigidbody2D>().velocity = projectile12.transform.up * 1000;
    }
}
