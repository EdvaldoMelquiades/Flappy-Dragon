using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragonScript : MonoBehaviour {
	 
	private Rigidbody2D myRigidBody;
	private Animator myAnimator;
	private float jumpForce;
	public bool isAlive;
	
	public GameObject GameOver; // Get Game Over Menu object

	GameManagerScript gameManager; // Get GameManagerScript script

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


	void Flap() {
		myRigidBody.velocity = new Vector2 (0,jumpForce);
		
		myAnimator.SetTrigger ("Flap");
	}


	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Obstacles") {
			DeadState();

			// Save score
			if (gameManager.myScore > PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore", gameManager.myScore);
				PlayerPrefs.Save();
			}
        }
	}

	void CheckIfDragonVisibleOnScreen() {
		if (Mathf.Abs(gameObject.transform.position.y) > 5.3f) {
			DeadState();
        }
	}

	void DeadState() {
		isAlive = false;
		Time.timeScale = 0f;
        GameOver.SetActive(true);
		}
}