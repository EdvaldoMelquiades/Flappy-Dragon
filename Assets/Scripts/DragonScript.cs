using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragonScript : MonoBehaviour {
	 
	private Rigidbody2D myRigidBody;
	private Animator myAnimator;
	private float jumpForce;
	public bool isAlive;
	public GameObject GameOver;

	// Get GameManagerScript cript
	GameManagerScript gameManager;

	void Start () {
		isAlive = true;

		myRigidBody = gameObject.GetComponent<Rigidbody2D>();
		myAnimator = gameObject.GetComponent<Animator>();

		jumpForce = 10f;
		myRigidBody.gravityScale = 5f;

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
	}
		
	void Update () {
		if (isAlive) {
			if (Input.GetMouseButton (0)) {
				Flap ();
			} 
			CheckIfDragonVisibleOnScreen ();
		} 
	}


	void Flap(){
		myRigidBody.velocity = 
			new Vector2 (0,jumpForce);
		
		myAnimator.SetTrigger ("Flap");

	}


	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Obstacles") {
			// Set Dragon dead
			isAlive = false;

			// Pause game
			Time.timeScale = 0f;

			// Save score
			if (gameManager.myScore > PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore", gameManager.myScore);
				PlayerPrefs.Save();
			}

			// Enable Game Over menu
            GameOver.SetActive(true);
        }
	}

	void CheckIfDragonVisibleOnScreen() {
		if (Mathf.Abs(gameObject.transform.position.y) > 5.3f) {
			isAlive = false;
			Time.timeScale = 0f;
            GameOver.SetActive(true);
        }
	}
}