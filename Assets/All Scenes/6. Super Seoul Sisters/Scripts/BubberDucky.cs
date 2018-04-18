using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BubberDucky : MonoBehaviour {

	private GameObject mikeMan;
	public float enemySpeed = 1.7f;
    public int xMoveDirection;
	public int yMoveDirection = 1;
	public float mikeRaycast = .2f;
	public Rigidbody projectile;

    void Start()
    {
        InvokeRepeating("JumpMikeJump", 1.0f, 1.3f);
    }

    void JumpMikeJump()
    {
       	gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 3000);
    }


    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * enemySpeed;
	}

	void YDirection()
	{
		if(yMoveDirection > 0)
        {
            yMoveDirection = -yMoveDirection;
        }

        else
        {
            yMoveDirection = +yMoveDirection;
        }
	}
}

