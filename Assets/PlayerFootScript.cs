using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootScript : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D fn_collider)
    {
        if(fn_collider.gameObject.tag != "Player" && 
            fn_collider.tag == "Water" &&
            Player.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            Player.GetComponent<PlayerScript>().canJump = true;
            Player.GetComponent<PlayerScript>().m_jump_time = 0;
        }

        else if (fn_collider.gameObject.tag != "Player" && 
            fn_collider.gameObject.tag != "Turret" &&
            fn_collider.tag != "Water" &&
            !Player.GetComponent<PlayerScript>().canJump)
        {
            Player.GetComponent<PlayerScript>().canJump = true;
            Player.GetComponent<PlayerScript>().m_jump_time = 0;
        }
    }
    
    private void OnTriggerExit2D(Collider2D fn_collider)
    {
        Player.GetComponent<PlayerScript>().canJump = false;
    }
}
