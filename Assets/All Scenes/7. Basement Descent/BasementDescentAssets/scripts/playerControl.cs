using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    private float xMove, yMove, xFacing, yFacing;
    private Quaternion lastFacing = Quaternion.Euler(0,0,0);
    private float shotCooldown = 0;
    private Vector2 moveVector;
    private float levelComplete = 0;
    public float speed = 3;
    public float projDelay = 0.5f;
    public Transform bulletObj;

	// Use this for initialization
	void Start () {
		
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
        Instantiate(bulletObj, (transform.position + new Vector3 (-xFacing/2, yFacing/2, 0)), bulletObj.rotation);
    }
	
	// Update is called once per frame
	void Update () {

        PlayerMovement();

        if (yFacing > 0.5 || yFacing < -0.5 || xFacing > 0.5 || xFacing < -0.5)
            if (Input.GetAxis("backTriggers") > 0.9 && shotCooldown == 0)
            {
                shotCooldown = 1;
                PlayerAttack();
                StartCoroutine(shotDelayReset());
            }
    }

    IEnumerator shotDelayReset()
    {
        yield return new WaitForSeconds(projDelay);
        shotCooldown = 0;
    }
}
