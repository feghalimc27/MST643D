using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour {

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    public bool controller = false;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    private GameObject character;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (!controller) {
            MouseLook();
        }
        else {
            ControllerLook();
        }
    }

    void MouseLook() {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -87.0f, 87.0f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }

    void ControllerLook() {
        Vector2 md = new Vector2(Input.GetAxisRaw("HorizontalR"), Input.GetAxisRaw("VerticalR"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -87.0f, 87.0f);

        transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
