using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPowerUp : MonoBehaviour {

    GameMaster game;

    GameObject player;

    public float powerUpSpeed;

    public float powerUpMaxSpeed;

    public int value;

    public float secondsActive;

    public float speed;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.GetComponent<PlayerController>().isFast == false)
        {
            game.score += value;
            StartCoroutine("SpeedUp", secondsActive);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public IEnumerator SpeedUp()
    {
        var originalSpeed = player.GetComponent<PlayerController>().speed;
        var originalMaxSpeed = player.GetComponent<PlayerController>().maxSpeed;
        player.GetComponent<PlayerController>().speed = powerUpSpeed;
        player.GetComponent<PlayerController>().maxSpeed = powerUpMaxSpeed;
        player.GetComponent<PlayerController>().isFast = true;
        yield return new WaitForSeconds(secondsActive);
        player.GetComponent<PlayerController>().speed = originalSpeed;
        player.GetComponent<PlayerController>().maxSpeed = originalMaxSpeed;
        player.GetComponent<PlayerController>().isFast = false;
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

}
