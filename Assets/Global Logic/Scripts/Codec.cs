using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codec : MonoBehaviour
{
    public Texture bar1;
    public Texture bar2;
    public Texture bar3;
    public Texture bar4;
    public Texture bar5;
    public Texture bar6;
    public Texture bar7;
    public Texture bar8;
    public Texture bar9;

    Texture[] allBars;

    void Start ()
    {
        allBars = new Texture[] { bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9 };
    }

    void OnEnable()
    {
        Invoke("mikeTalking", 0f);
    }

    void OnDisable()
    {
        CancelInvoke("mikeTalking");
    }

    void mikeTalking()
    {
        transform.Find("Mike Highlight").gameObject.SetActive(!transform.Find("Mike Highlight").gameObject.activeInHierarchy);
        transform.Find("Bar").GetComponent<RawImage>().texture = allBars[Random.Range(0, 9)];
        Invoke("mikeTalking", Random.Range(0.1f, 0.5f));
    }
}
