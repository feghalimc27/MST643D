using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    ScoreManager _score_manager;



    void Awake()
    {
        _score_manager= FindObjectOfType<ScoreManager>();
        _score_manager.currentScore = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Score");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
