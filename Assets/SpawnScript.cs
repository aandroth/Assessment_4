using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject parent;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !collision.collider.GetComponent<PlayerScript>().isFull)
        {
            collision.gameObject.GetComponent<PlayerScript>().AddMass(0.1f);
            parent.GetComponent<SpawnerScript>().spawnReportsAsDead();
            Destroy(this.gameObject);
        }
    }
}
