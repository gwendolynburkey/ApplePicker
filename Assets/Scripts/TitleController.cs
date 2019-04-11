using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Quits the game
    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("_Scene_0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
