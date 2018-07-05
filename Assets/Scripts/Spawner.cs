using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {



    public GameObject[] items;

    public int spawnTimer;

	private void Start()
	{
        InvokeRepeating("SpawnItem", spawnTimer, spawnTimer);
	}



	void SpawnItem(){

        if(transform.childCount == 0){


            GameObject randomItem = items[Random.Range(0, items.Length)];

            Instantiate(randomItem, transform.position, Quaternion.identity, transform);
        }
    }
}
