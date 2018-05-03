using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalSoundController : MonoBehaviour
{
    public EventSystem currentEventSystem;
    public AudioSource audioSource;
    public AudioClip changeSelectionClip;
    public AudioClip selectButtonClip;
    public AudioClip codecCall;
    public AudioClip codecOpen;
    public AudioClip codecTalk;
    public AudioClip codecClose;

    GameObject lastSelected;

    void Start()
    {
        lastSelected = currentEventSystem.currentSelectedGameObject;
    }

    void Update()
    {
        if (currentEventSystem.currentSelectedGameObject != lastSelected && currentEventSystem.currentSelectedGameObject != null)
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
