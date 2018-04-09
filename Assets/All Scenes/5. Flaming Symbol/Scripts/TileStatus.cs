using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStatus : MonoBehaviour {

    public bool active = false;
    public bool blocked = false;
    public int type; // 0 = mov 1 = atk

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite atk, mov;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

    void OnTriggerStay2D (Collider2D collision) {
        if (collision.gameObject.layer == 9) {
            blocked = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == 9) {
            blocked = false;
        }
    }

    // Update is called once per frame
    void Update () {
		if (active && !blocked) {
            spriteRenderer.enabled = true;
        }
        else {
            spriteRenderer.enabled = false;
        }

        switch(type) {
            case 0: // move
                spriteRenderer.sprite = mov;
                break;
            case 1: // atk
                spriteRenderer.sprite = atk;
                break;
        }
	}
}
