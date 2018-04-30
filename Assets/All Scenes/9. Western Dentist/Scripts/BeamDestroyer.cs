using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            LogicController.playerScore += 100;
            Destroy(collision.gameObject);
        }
    }
}