using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal_B_Script : MonoBehaviour, IToggle {

    public int portalTeleportOffset_X;
    public int portalTeleportOffset_Y;
    public int portalHeight;
    public GameObject PortalA;
    public Camera cam;
    public bool isActive;

    public UnityEvent onTeleportRecieve;

    // Use this for initialization
    void Start () {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onTeleportRecieve != null)
        {
            onTeleportRecieve.Invoke();
        }
    }

    public void TeleportObject(GameObject go)
    {
        go.transform.position = new Vector3(transform.position.x + go.transform.localScale.x + go.transform.localScale.x,
                                            portalTeleportOffset_Y + transform.position.y - portalHeight, 0);
        if(go.tag == "Player")
            cam.gameObject.GetComponent<CameraScript>().fixNextPos(new Vector2(23, 0));
    }
    
    public void PlaceObject(GameObject go)
    {
        go.transform.position = new Vector3(
            transform.position.x + go.transform.localScale.x * 2f,
            portalTeleportOffset_Y + transform.position.y - portalHeight, 0);
        if (go.tag == "Player")
            cam.gameObject.GetComponent<CameraScript>().fixNextPos(new Vector2(23, 0));
    }

    public void toggleActive()
    {
        isActive = !isActive;
    }
}
