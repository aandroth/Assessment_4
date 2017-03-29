using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour {

    public UnityEvent OnMassGreatEnough;
    public UnityEvent lockDown;

    private float lockHeight, lockdownTime, lockdownTimeLimit;

    // Use this for initialization
    void Start () {
        lockHeight = transform.position.y - 0.18f;
        lockdownTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        lockdownTime += Time.deltaTime;

        if (lockdownTime >= lockdownTimeLimit && transform.position.y <= lockHeight)
        {
            if (OnMassGreatEnough != null)
            {
                OnMassGreatEnough.Invoke();
            }
        }
	}
}
