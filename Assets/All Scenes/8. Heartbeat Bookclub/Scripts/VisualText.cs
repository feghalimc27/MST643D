using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class VisualText : MonoBehaviour
{

    public Text text;

    private enum States { start }

    private States myState;

    // Use this for initialization
    void Start()
    {
        myState = States.start;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

