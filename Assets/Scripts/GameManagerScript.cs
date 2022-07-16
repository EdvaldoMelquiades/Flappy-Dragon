using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {
	public int myScore;

	public Text myScoreGUI;
	public GameObject startButton;

	public Transform bottomObstacle, topObstacle;

	private AudioSource audioSource;

	// Use this for initialization
	void Start (){
		myScore = 0;

		myScoreGUI = GameObject.Find ("Score").GetComponent<Text> ();

		Time.timeScale = 0f;
	}
		
	public void GmAddScore (){
		this.myScore++;
		myScoreGUI.text = myScore.ToString();
		audioSource.Play ();
	}

	public void ObstacleSpawner (){
		int rand = Random.Range (0, 2);
		float topObstacleMinY = 2f,
		topObstacleMaxY = 6f,
		bottomObstacleMinY = -6f,
		bottomObstacleMaxY = -2f;

		switch (rand){
		case 0:
			Instantiate (bottomObstacle, new Vector2(9f, Random.Range(bottomObstacleMinY, bottomObstacleMaxY)), Quaternion.identity);
			break;
		case 1:
			Instantiate (topObstacle, new Vector2(9f, Random.Range(topObstacleMinY, topObstacleMaxY)), Quaternion.identity);
			break;
		}
	}

	public void RestartButton (){
		SceneManager.LoadScene(sceneName: "Game");
		Time.timeScale = 1f; 
	}

    public void BackButton (){
        SceneManager.LoadScene(sceneName: "Menu");
		Time.timeScale = 1f; 
    }

	public void StartButton (){
		Time.timeScale = 1f;
		startButton.SetActive(false);
		InvokeRepeating ("ObstacleSpawner", .5f, 1.5f);
		audioSource = gameObject.GetComponent<AudioSource> ();
	}
}





