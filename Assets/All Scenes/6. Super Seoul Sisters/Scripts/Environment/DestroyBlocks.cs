using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyBlocksAfterDelay(2f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DestroyBlocksAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
