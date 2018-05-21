using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectTimer : MonoBehaviour {

    public float spawnTime = 5.0f;
    public int pointScore;

    public GameUI gameUI;

    void Start()
    {
        InvokeRepeating("PointSpawn", 0, 30);
    }
	

	void DoSpawn()
    {
        SendMessage("Spawn");
        Invoke("DoSpawn", spawnTime);
	}

    void PointSpawn()
    {
        if (gameUI.score >= pointScore)
        {
            Invoke("DoSpawn", spawnTime);
        }
        
    }
}
