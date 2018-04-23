using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStatus : MonoBehaviour {

    public bool active = false;
    public bool blocked = false;
    public int type; // 0 = mov 1 = atk

    public bool enemyTile = false;

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite atk, mov, obj;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            enemyTile = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            enemyTile = false;
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
            case 2:
                spriteRenderer.sprite = obj;
                break;
        }

        if (enemyTile) {
            spriteRenderer.sprite = atk;
        }
	}
}
