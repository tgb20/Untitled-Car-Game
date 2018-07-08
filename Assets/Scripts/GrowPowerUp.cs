using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPowerUp : MonoBehaviour {

    GameMaster game;

    public int value;

    public float secondsActive;

    public float speed;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<GameMaster>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            game.score += value;
            var player = collision.gameObject.GetComponent<PlayerController>();//scriptname
            player.StartCoroutine("GrowPowerUp", secondsActive);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

}
