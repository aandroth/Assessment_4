using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletExplosionScript : MonoBehaviour {
    

    public float lifespan;
    public float force;
    private float m_damage;

    // Use this for initialization
    void Start () {
        m_damage = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifespan -= Time.deltaTime;
        if (lifespan < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
            IDamagable[] list = collision.collider.gameObject.GetComponents<IDamagable>();
            foreach (IDamagable id in list)
            {
                float dist = Vector3.Distance(transform.position,
                                                collision.gameObject.GetComponent<Transform>().position);
                collision.gameObject.GetComponent<IDamagable>().TakeDamage(m_damage / dist);

                if (collision.collider.gameObject.tag == "Player")
                {
                    Vector2 dir = collision.collider.GetComponent<Transform>().position - transform.position;
                    dir.Normalize();
                    collision.collider.gameObject.GetComponent<PlayerScript>().SubtractMass(0.1f);
                    collision.collider.GetComponent<Rigidbody2D>().AddForce(dir * force);
                }
            }
        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
        
}
