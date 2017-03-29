using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public GameObject bulletExplo;
    public GameObject parent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("here_a");
    //    Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    //    bulletExplo.transform.position = transform.position;
    //    Instantiate(bulletExplo);
    //    Destroy(this.gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());

        if (collider.tag == "Turret" || collider.tag == "Trigger")
        {
            Debug.Log("enter");
        }
        else
        {
            bulletExplo.transform.position = transform.position;
            Instantiate(bulletExplo);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
    }
}
