using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstaclesUp : MonoBehaviour {

    public float obstacleSpeed;
    public GameObject bottomSetPoint;
    public GameObject topSetPoint;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 16);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * obstacleSpeed;

        if (gameObject.transform.position.y > topSetPoint.transform.position.y)
        {
            gameObject.transform.position = bottomSetPoint.transform.position;

        }
    }
}
