using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour, IToggle {
    public GameObject spawn;
    public bool isActive;
    private int spawnCount;

    // Use this for initialization
    void Start () {
        spawnCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive)
        {
            Spawn();
        }
	}

    private void Spawn()
    {
        if(spawnCount < 10)
        {
            Instantiate(spawn);
            spawn.transform.position = transform.position;
            spawn.GetComponent<SpawnScript>().parent = gameObject;

            ++spawnCount;
        }
    }
    
    public void spawnReportsAsDead()
    {
        --spawnCount;
    }

    public void toggleActive()
    {
        isActive = !isActive;
    }
}
