using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingTrafficSpawner : MonoBehaviour {

    public GameObject[] carBlocks;
    public GameObject player;
    public float Front_Back_Offset;
    private Vector3 spawnPosition;
    float TimeToNextSpawn;
    float LastSpawnTime;

	// Use this for initialization
	void Start () {
        int index = Random.Range(0, carBlocks.Length);
        spawnPosition = new Vector3(Random.Range(-25f, 25f), 1.12f, (player.transform.position.z + Front_Back_Offset));
        Instantiate(carBlocks[index], spawnPosition, Quaternion.identity);
        TimeToNextSpawn = Random.Range(1, 4);
        LastSpawnTime = 0;
    }

    void Update()
    {
        LastSpawnTime += Time.deltaTime;
        if(LastSpawnTime >= TimeToNextSpawn)
        {
            int index = Random.Range(0, carBlocks.Length);
            spawnPosition = new Vector3(Random.Range(-25f, 25f), 1.12f, (player.transform.position.z+Front_Back_Offset));
            Instantiate(carBlocks[index], spawnPosition, Quaternion.identity);
            TimeToNextSpawn = Random.Range(1, 4);
            LastSpawnTime = 0;
        }
    }

}
