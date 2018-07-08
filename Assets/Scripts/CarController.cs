using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    
    public float speed;

    public float disappearTimer;

    GameObject player;

    public bool isRunning = true;

    // IMPORT NOTE: Change Pixel Light Count to Greater than 20 to allow for headlights and Render Mode on Lights needs to be important
    public Light headR;
    public Light headL;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
	}
	
	// Update is called once per frame
    void Update () {

        if (isRunning)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }


        if(calculateDistance() > 30){
            destroyCar();
        }


	}

	private void OnCollisionEnter(Collision collision)
	{
        var playerController = collision.gameObject.GetComponent<PlayerController>();

        if (isRunning && collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player"){
            BreakDown();
        }
        else if (playerController != null && playerController.isImmune == true)
        {
            BreakDown();
        }
	}

    void BreakDown(){

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < rends.Length; i++){
            rends[i].material.color = Color.gray;
        }

        headL.enabled = false;
        headR.enabled = false;
        GetComponent<AudioSource>().enabled = false;

        Invoke("destroyCar", disappearTimer);

        isRunning = false;

    }

    void destroyCar(){
        Destroy(gameObject);
    }


	float calculateDistance(){


        float a = Mathf.Pow((transform.position.x - 0), 2);
        float b = Mathf.Pow((transform.position.y - 0), 2);

        float distance = Mathf.Sqrt(a + b);



        return distance;
    }
}
