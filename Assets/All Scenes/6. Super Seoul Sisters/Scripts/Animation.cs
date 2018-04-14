using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    Animator m_Animator;
    //Value from the slider, and it converts to speed level
    public float AnimationSpeed;

    void Start()
    {
        //Get the animator, attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void OnGUI()
    {
        //Make the speed of the Animator match the Slider value
        m_Animator.speed = AnimationSpeed;

    }
}
