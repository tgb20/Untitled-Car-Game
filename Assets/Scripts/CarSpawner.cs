using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {


    public GameObject carPrefab;

    public float spawnRadius;

    public float spawnTimer;

    GameMaster game;


	private void Start()
	{
        game = GetComponent<GameMaster>();
        InvokeRepeating("spawnCar", spawnTimer, spawnTimer);
	}

	private void Update()
	{
        if(game.gameOver){
            CancelInvoke();
        }
	}


	void spawnCar(){


        Vector2 spawnPoint = Random.insideUnitCircle.normalized * spawnRadius;


        Vector3 spawnPosition = new Vector3(spawnPoint.x, 0.5f, spawnPoint.y);

        Instantiate(carPrefab, spawnPosition, Quaternion.identity);


    }

}
