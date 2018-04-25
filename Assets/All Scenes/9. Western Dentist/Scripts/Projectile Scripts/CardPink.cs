using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPink : MonoBehaviour
{
    bool ready;

    void Awake()
    {
        StartCoroutine(Fire());
        ready = false;
    }

    void Update()
    {
        if (BossController.phaseOver == true)
        {
            StartCoroutine(WaitAnim());
            if (ready == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, LogicController.merryObject.transform.position, 50f);

                if (Vector3.Distance(transform.position, LogicController.merryObject.transform.position) < 10)
                {
                    LogicController.playerScore += 100;
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator Fire()
    {
        transform.up = LogicController.merryObject.transform.position - transform.position;
        yield return new WaitForSeconds(1.5f);
        transform.up = LogicController.merryObject.transform.position - transform.position;
        transform.GetComponent<Rigidbody2D>().velocity = transform.up * 1000;
    }

    IEnumerator WaitAnim()
    {
        transform.GetComponent<BoxCollider2D>().enabled = false;
        transform.up = Vector2.up;
        gameObject.GetComponent<SpriteRenderer>().sprite = LogicController.pointBallSprite;
        gameObject.tag = "PointProjectile";
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(1);
        ready = true;
    }
}
