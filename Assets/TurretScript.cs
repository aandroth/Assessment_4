using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour, IDamageDealer, IToggle {

    public bool isActive;
    public float fireRate;
    public GameObject Bullet;
    public GameObject Player;
    private float lastFired;
    private int power;
    private float m_damage;

	// Use this for initialization
	void Start () {
        power = 10;
        m_damage = 10;
	}
	
	// Update is called once per frame
	void Update () {

        if(isActive)
        {
            lastFired += Time.deltaTime;

            if(lastFired > fireRate)
            {
                lastFired = 0;
                FireBullet();
            }
        }
	}

    void FireBullet()
    {
        GameObject go = Instantiate(Bullet);

        Vector3 directionToPlayer = Vector3.zero;
        directionToPlayer.x = -(transform.position.x - Player.transform.position.x);
        directionToPlayer.y = -(transform.position.y - Player.transform.position.y);
        directionToPlayer.Normalize();

        go.transform.position = transform.position;
        go.GetComponent<Rigidbody2D>().velocity = directionToPlayer * power;
    }

    public float DealDamage()
    {
        return m_damage;
    }

   public void toggleActive()
    {
        isActive = !isActive;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isActive = false;
    }
}
