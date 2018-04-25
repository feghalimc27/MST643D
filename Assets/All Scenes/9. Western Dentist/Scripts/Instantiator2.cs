using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator2 : MonoBehaviour
{
    public static string selectedProjectile;

    void OnEnable()
    {
        GameObject projectileInstance = Instantiate(Resources.Load(selectedProjectile), transform.position, transform.rotation) as GameObject;
        transform.gameObject.SetActive(false);
    }
}