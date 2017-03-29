using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour, IDamagable {

    private float m_speed, m_maxSpeed, m_force, m_jump, m_jump_time_limit;
    public bool canJump;
    private Rigidbody2D rb;
    public float m_health, m_jump_time, max_fall_speed;
    private Vector3 localScale;
    public bool isFull;
    public GameObject Death_Pt;

    // Use this for initialization
    void Start () {
        canJump = true;
        m_speed = 10f;
        m_maxSpeed = 30f;
        m_force = 50f;
        m_jump = 50;
        m_jump_time = 0;
        m_jump_time_limit = 0.15f;
        m_health = 100;
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        isFull = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(transform.position.y < Death_Pt.transform.position.y)
        {
            transform.position = new Vector3(-0.34f, -2.82f, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        Vector3 new_pos = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            new_pos = new_pos + new Vector3(-m_speed + rb.mass*0.5f, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            new_pos = new_pos + new Vector3(m_speed + rb.mass * 0.5f, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.W) && canJump)
        {
            canJump = false;
            new_pos = new_pos + new Vector3(0, m_jump, 0);
        }
        else if (Input.GetKey(KeyCode.W) && m_jump_time < m_jump_time_limit)
        {
            new_pos = new_pos + new Vector3(0, m_jump * GetComponent<Rigidbody2D>().mass * 0.5f, 0);
        }

        if (!canJump && m_jump_time < m_jump_time_limit)
            m_jump_time += Time.deltaTime;

        GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        rb.AddForce(new_pos);
        
        if (rb.velocity.x > m_maxSpeed)
        {
            rb.velocity = new Vector3(m_maxSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity.x < -m_maxSpeed)
        {
            rb.velocity = new Vector3(-m_maxSpeed, rb.velocity.y, 0);
        }
        if (rb.velocity.y > m_jump)
        {
            rb.velocity = new Vector3(rb.velocity.y, m_jump, 0);
        }

        if (rb.velocity.y < -7)
            rb.velocity = new Vector2(rb.velocity.x, max_fall_speed);
    }

    public void TakeDamage(float damage)
    {
        m_health -= damage;
    }

    public void AddMass(float mass)
    {
        if (rb.mass < 2.3f)
        {
            rb.mass += mass;
            transform.localScale = localScale * rb.mass;
        }
        else
        {
            isFull = true;
        }
    }

    public void SubtractMass(float mass)
    {
        if(rb.mass > 1.0f)
        {
            rb.mass -= mass;
            transform.localScale = localScale * rb.mass;
            isFull = false;
        }   
    }
}
