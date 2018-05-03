using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionOOB : MonoBehaviour {

    public GameObject leftCamera;

    void Update(){
        if(gameObject.transform.position.x < leftCamera.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
