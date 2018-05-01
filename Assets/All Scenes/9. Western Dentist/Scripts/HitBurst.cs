using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBurst : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
}