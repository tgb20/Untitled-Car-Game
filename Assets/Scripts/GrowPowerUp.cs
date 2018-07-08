using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPowerUp : MonoBehaviour {

    GameMaster game;

    GameObject player;

    public Vector3 GrowPowerUpSize;

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
        if (collision.gameObject.tag == "Player" && player.GetComponent<PlayerController>().isImmune == false)
        {
            game.score += value;
            StartCoroutine("Grow", secondsActive);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public IEnumerator Grow()
    {
        var originalSize = player.transform.localScale;
        player.transform.localScale = GrowPowerUpSize;
        player.GetComponent<PlayerController>().isImmune = true;
        yield return new WaitForSeconds(secondsActive);
        player.transform.localScale = originalSize;
        player.GetComponent<PlayerController>().isImmune = false;
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

}
