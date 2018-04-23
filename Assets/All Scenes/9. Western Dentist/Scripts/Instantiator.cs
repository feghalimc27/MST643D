using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public static string selectedProjectile;

    void OnEnable()
    {
        GameObject projectileInstance = Instantiate(Resources.Load(selectedProjectile), transform.position, transform.rotation) as GameObject;
        projectileInstance.GetComponent<Rigidbody2D>().velocity = transform.up * 150;
        transform.gameObject.SetActive(false);
    }
}