using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject player;

    public GameObject mainMenu;
    public GameObject gameOverScreen;

    public GameObject score;

    public void PlayGame(){

        mainMenu.SetActive(false);
        player.SetActive(true);
        GetComponent<CarSpawner>().enabled = true;
        score.SetActive(true);
        GetComponent<GameMaster>().enabled = true;

    }


	private void Update()
	{
        if(GetComponent<GameMaster>().gameOver){
            gameOverScreen.SetActive(true);
        }
	}


    public void Back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
