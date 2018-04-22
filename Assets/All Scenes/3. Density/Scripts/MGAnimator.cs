using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGAnimator : MonoBehaviour {

    public float spinSpeed;

    [SerializeField]
    private float scaleSpin = 1.75f;
    [HideInInspector]
    public float activeSpin = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton("Fire1")) {
            if (activeSpin < spinSpeed) {
                if (activeSpin == 0) {
                    activeSpin = 2;
                }

                activeSpin *= scaleSpin;
            }
        }
        else if (!Input.GetButton("Fire1")) {
            if (activeSpin > 2) {
                activeSpin /= 1.05f;
            }
            else if (activeSpin <= 2) {
                activeSpin = 0;
            }
        }

        transform.Rotate(new Vector3(0, 0, activeSpin));
    }
}
