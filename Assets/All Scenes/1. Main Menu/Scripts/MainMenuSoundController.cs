using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuSoundController : MonoBehaviour
{
    public EventSystem currentEventSystem;
    public AudioSource audioSource;
    public AudioClip changeSelectionClip;
    public AudioClip selectButtonClip;

    GameObject lastSelected;

    void Start()
    {
        lastSelected = currentEventSystem.currentSelectedGameObject;
    }

    void Update ()
    {
        if (currentEventSystem.currentSelectedGameObject != lastSelected)
        {
            audioSource.PlayOneShot(changeSelectionClip);
        }
        lastSelected = currentEventSystem.currentSelectedGameObject;
    }

    public void playSelect()
    {
        audioSource.PlayOneShot(selectButtonClip);
    }
}
