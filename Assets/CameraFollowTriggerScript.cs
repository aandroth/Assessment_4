using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CameraFollowTriggerScript : MonoBehaviour {

    public GameObject Player;
    public UnityEvent toggleCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
        if (collider.tag == "Player" && toggleCamera != null)
        {
            toggleCamera.Invoke();
        }
    }
}
