using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentmanagerScript : MonoBehaviour {


    public static PersistentmanagerScript Instance { get; private set; }

    public int value;
    ScoreManager _score_manager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        _score_manager = FindObjectOfType<ScoreManager>();

        value = _score_manager.currentScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
