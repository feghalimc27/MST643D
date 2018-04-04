using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codec : MonoBehaviour
{
    public RawImage bar1;
    public RawImage bar2;
    public RawImage bar3;
    public RawImage bar4;
    public RawImage bar5;
    public RawImage bar6;
    public RawImage bar7;
    public RawImage bar8;
    public RawImage bar9;

    RawImage[] allBars;

    void Start ()
    {
        allBars = new RawImage[] { bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9 };

    }

	void Update ()
    {
		
	}
}
