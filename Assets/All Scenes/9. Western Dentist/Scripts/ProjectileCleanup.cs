using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCleanup : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag != "SpecialAttack" && collision.gameObject.tag != "HitBurst")
        {
            Destroy(collision.gameObject);
        }
    }
}