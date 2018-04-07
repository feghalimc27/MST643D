using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -4.84)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("Super Seoul Sisters");
    }
}
