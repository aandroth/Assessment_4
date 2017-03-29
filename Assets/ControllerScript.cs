using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

    public GameObject spawner;
    public GameObject teleporterA;
    public GameObject teleporterB;
    public GameObject turret;
    public GameObject activeObject;

    public GameObject player;

    private bool gameIsActive = true;

    // Use this for initialization
    void Start () {
        activeObject = spawner;
	}
	
	// Update is called once per frame
	void Update () {
        Selector();
    }

    void Selector()
    {
        if (gameIsActive)
        {
            spawner.GetComponent<SpawnerScript>().isActive = false;
            teleporterA.GetComponent<Teleport_A_Script>().isActive = false;
            teleporterB.GetComponent<Portal_B_Script>().isActive = false;
            turret.GetComponent<TurretScript>().isActive = false;

            float shortestDist = (player.transform.position - spawner.transform.position).magnitude;
            activeObject = spawner;

            if (shortestDist > (player.transform.position - teleporterA.transform.position).magnitude)
            {
                activeObject = teleporterA;
                shortestDist = (player.transform.position - teleporterA.transform.position).magnitude;
            }
            if (shortestDist > (player.transform.position - teleporterB.transform.position).magnitude)
            {
                activeObject = teleporterB;
                shortestDist = (player.transform.position - teleporterB.transform.position).magnitude;
            }

            if (shortestDist > (player.transform.position - turret.transform.position).magnitude &&
                (player.transform.position - turret.transform.position).magnitude < 20f
                )
            {
                activeObject = turret;
                shortestDist = (player.transform.position - turret.transform.position).magnitude;
            }

            activeObject.GetComponent<IToggle>().toggleActive();
        }
    }
}
