using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int score;

    public Text scorebox;

    public bool gameOver;


	private void Start()
    {
        InvokeRepeating("addTimeScore", 1, 1);
	}

	private void Update()
	{
        scorebox.text = score.ToString();


        if(gameOver){
            CancelInvoke();
        }


	}


	void addTimeScore(){
        score += 100;
    }


}
