using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D changeScene)
    {
        if (changeScene.name == "Merry")
        {
            SceneManager.LoadScene("Mike");
        }
    }
}
