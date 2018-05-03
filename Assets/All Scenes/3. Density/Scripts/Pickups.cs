using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

    public enum PickupType { health, none }
    public PickupType type;
    public AudioClip sound;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 5);
	}

    public void PlayPickupSound() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        StartCoroutine("DestroySelf");
    }

    IEnumerator DestroySelf() {
        MeshRenderer[] parts = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < parts.Length; ++i) {
            parts[i].enabled = false;
        }
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        Object.Destroy(this.gameObject);
    }
}
