using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    public Text hsText;
    
    void Start()
    {
        hsText.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void PlayButton(){
        SceneManager.LoadScene("Game");
    }

    public void QuitButton (){
        Application.Quit();
    }
}
