using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject spriteObject;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        spriteObject.transform.position = transform.position;
        //spriteObject.transform.up = Vector3.up;
        spriteObject.transform.Rotate(Vector3.up * 2.0f * Input.GetAxis("Horizontal"));
        transform.GetComponent<Rigidbody>().AddForce(spriteObject.transform.forward * 20 * Input.GetAxis("Vertical"), ForceMode.Acceleration);
        transform.GetComponent<Rigidbody>().AddForce(spriteObject.transform.right * 20 * Input.GetAxis("Horizontal"), ForceMode.Acceleration);

        if (Input.GetAxis("Horizontal") > 0 && transform.rotation.z > -5)
        {
            transform.GetChild(0).Rotate(transform.forward * -Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxis("Horizontal") < 0 && transform.rotation.z < 5)
        {
            transform.GetChild(0).Rotate(transform.forward * Input.GetAxis("Horizontal"));
        }
    }
}
