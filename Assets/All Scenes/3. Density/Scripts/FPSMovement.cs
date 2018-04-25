using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSMovement: MonoBehaviour {

    public float speed = 10.0f;
    public float jumpStrength = 25.0f;
	public int fireRate = 1200;

    private bool onGround = false;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

    }

    // Called at a consistent point per frame
    void FixedUpdate() {
        MovePlayer();
        Jump();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.layer == 8) {
            onGround = true;
        }
    }

    void OnCollisionStay(Collision col) {
        // Layer 8 = Ground
        if (col.gameObject.layer == 8) {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision col) {
        // Layer 8 = Ground
        if (col.gameObject.layer == 8) {
            onGround = false;
        }
    }

    // Move player
    void MovePlayer() {
        // Movement strengths
        float forwardPos = Input.GetAxis("Vertical") * speed;
        float strafePos = Input.GetAxis("Horizontal") * speed;

        // Normalize
        strafePos *= Time.deltaTime;
        forwardPos *= Time.deltaTime;

        // Translate by strength
        transform.Translate(strafePos, 0, forwardPos);

        // Allow cursor to be freed on Esc press
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Jump() {
        if (onGround && Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpStrength, 0));
        }
    }
}
