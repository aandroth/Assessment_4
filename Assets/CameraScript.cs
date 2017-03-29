using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject Player;
    private Vector3 nextPos;
    public bool followPlayerX, followPlayerY;

	// Use this for initialization
	void Start () {
        followPlayerX = followPlayerY = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(followPlayerX || followPlayerY)
        {
            Vector3 new_pos = transform.position;

            if (followPlayerX)
                new_pos.x = Player.transform.position.x;
            if (followPlayerY)
                new_pos.y = Player.transform.position.y;

            nextPos = new_pos;
        }

        nextPos.z = transform.position.z;
        float biasX = Mathf.Abs(Player.transform.position.x - transform.position.x);
        float biasY = Mathf.Abs(Player.transform.position.y - transform.position.y);
        Vector3 lerp_pos = transform.position;
        lerp_pos.x = Mathf.Lerp(transform.position.x, nextPos.x, Time.deltaTime * biasX);
        lerp_pos.y = Mathf.Lerp(transform.position.y, nextPos.y, Time.deltaTime * biasY);
        transform.position = lerp_pos;
    }

    public void toggleFollowingPlayerX()
    {
        followPlayerX = !followPlayerX;
    }

    public void toggleFollowingPlayerY()
    {
        followPlayerY = !followPlayerY;
    }

    public void fixNextPos(Vector2 new_pos)
    {
        nextPos = new_pos;
    }
}
