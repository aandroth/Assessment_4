using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    public float floatness;

    // Use this for initialization
    void Start () {
        floatness = Physics2D.gravity.y;
        RenderSettings.fog = false;
        RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
        RenderSettings.fogDensity = 10f;
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            RenderSettings.fog = true;
            //collider.GetComponent<PlayerScript>().max_fall_speed = -1;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Ground" && collider.gameObject.tag != "PlayerFoot")
        {
            //          Vector3 new_pos = collider.transform.position;
            //          new_pos.y = Mathf.Min(GetComponent<BoxCollider2D>().bounds.max.y,
            //Mathf.Max(GetComponent<BoxCollider2D>().bounds.max.y - collider.GetComponent<Rigidbody2D>().mass,
            //                          GetComponent<BoxCollider2D>().bounds.min.y));

            //Vector2 v = Vector2.zero;
            //v.y = collider.GetComponent<Rigidbody2D>().mass;
            //float depth = GetComponent<BoxCollider2D>().bounds.max.y - (collider.transform.position.y);
            //depth += 1;
            //Debug.Log(-(depth) / (v.y * floatness));
            //collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, (v.y * floatness)/(depth)));

            float height = collider.bounds.max.y - collider.bounds.min.y;
            float midPt = collider.bounds.max.y - (height * 0.5f);

            if (midPt < GetComponent<Collider2D>().bounds.max.y && 
                collider.GetComponent<Rigidbody2D>().mass < 1.5f)
            {
                collider.GetComponent<Rigidbody2D>().gravityScale = -0.09f;
            }
            else
            {
                collider.GetComponent<Rigidbody2D>().gravityScale = 1;
                collider.GetComponent<Rigidbody2D>().velocity *= 0.8f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Ground" && collider.gameObject.tag != "PlayerFoot")
        {
            collider.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (collider.gameObject.tag == "Player")
        {
            //collider.GetComponent<PlayerScript>().max_fall_speed = -7;
            RenderSettings.fog = false;
        }
    }
}
