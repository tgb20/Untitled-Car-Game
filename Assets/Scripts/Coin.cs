using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    GameMaster game;

    public int value;

    public float speed;

	private void Start()
	{
        game = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<GameMaster>();
	}

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Player"){
            game.score += value;
            Destroy(gameObject);
        }
	}

	private void Update()
	{
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}



}
