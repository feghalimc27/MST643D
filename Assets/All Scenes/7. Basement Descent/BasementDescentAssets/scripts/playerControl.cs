using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerControl : MonoBehaviour {

    private float xMove, yMove, xFacing, yFacing;
    private Quaternion lastFacing = Quaternion.Euler(0,0,0);
    private bool shotCooldown = false;
    private Vector2 moveVector;
    public float speed = 3;
    public float projDelay = 0.5f;
    public Transform bulletObj;
    public float playerHealth;
    public Slider healthBar;

	// Use this for initialization
	void Start () {

        healthBar.value = playerHealth;

	}

    void PlayerMovement()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        moveVector = new Vector2(xMove * speed, yMove * speed);

        GetComponent<Rigidbody2D>().velocity = moveVector;

        xFacing = -Input.GetAxis("HorizontalR");
        yFacing = -Input.GetAxis("VerticalR");

        if (yFacing > 0.3 || yFacing < -0.3 || xFacing > 0.3 || xFacing < -0.3)
            lastFacing = Quaternion.Euler(0, 0, (Mathf.Atan2(xFacing, yFacing) * (180 / 3.14f)));
        transform.rotation = lastFacing;
    }

    void PlayerAttack()
    {
        Instantiate(bulletObj, (transform.position + new Vector3(-xFacing / 2, yFacing / 2, 0)), bulletObj.rotation);
    }
	
	// Update is called once per frame
	void Update () {

        PlayerMovement();

        if (yFacing > 0.5 || yFacing < -0.5 || xFacing > 0.5 || xFacing < -0.5)
            if (Input.GetAxis("backTriggers") > 0.9 && shotCooldown == false)
            {
                shotCooldown = true;
                PlayerAttack();
                StartCoroutine(shotDelayReset());
            }

        if(playerHealth <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Arrow(Clone)")
        {
            playerHealth--;
            healthBar.value = playerHealth;
        }
    }

    IEnumerator shotDelayReset()
    {
        yield return new WaitForSeconds(projDelay);
        shotCooldown = false;
    }
}
