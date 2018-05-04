using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
