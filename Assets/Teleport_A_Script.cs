using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleport_A_Script : MonoBehaviour, IToggle {

    public int portalTeleportOffset_X;
    public int portalTeleportOffset_Y;
    public int portalHeight;
    public GameObject PortalB;
    public Camera cam;
    public bool isActive, lockedDown, movingDown;
    public float lockHeight;

    public UnityEvent onTeleportRecieve;

    // Use this for initialization
    void Start () {
        isActive = false;
        lockHeight = -2.48f;
    }
	
	// Update is called once per frame
	void Update () {
        if(!lockedDown)
        {
            if(movingDown)
            {
                Debug.Log("moving down");
                Vector3 newPos = transform.position;
                newPos -= Vector3.up * Time.deltaTime;
                transform.position = newPos;

                if(transform.position.y <= lockHeight)
                {
                    lockedDown = true;
                }
            }
        }
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
        if (go.tag == "Player")
            cam.gameObject.GetComponent<CameraScript>().fixNextPos(new Vector2(-0.14f, 0));
    }

    public void toggleActive()
    {
        isActive = !isActive;
    }

    public void PlaceObject(GameObject go)
    {
        go.transform.position = new Vector3(
            transform.position.x + go.transform.localScale.x * 2f,
            portalTeleportOffset_Y + transform.position.y - portalHeight, 0);
        if (go.tag == "Player")
            cam.gameObject.GetComponent<CameraScript>().fixNextPos(new Vector2(-0.14f, 0));
    }

    void lockDown()
    {
        lockedDown = true;
    }

    public void moveDown()
    {
        movingDown = true;
        Debug.Log("movingDown is true");
    }

}
