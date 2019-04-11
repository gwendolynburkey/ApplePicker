using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
    [Header("Set Dynamically")]
    public Text scoreGT;

	// Use this for initialization
	void Start () {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the text component of that game object.
        scoreGT = scoreGO.GetComponent<Text>();
        //Set the score to 0
        scoreGT.text = "0";
    }
	
	// Update is called once per frame
	void Update () {
        // Get the current position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D Screen space to a 3D world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        // Constrains the basket to the screen
        if (this.transform.position.x > 20)
        {
            pos.x = 20;
        }
        else if (this.transform.position.x < -20)
        {
            pos.x = -20;
        }
        pos.x = mousePos3D.x;

        this.transform.position = pos;

        
    }

    private void OnCollisionEnter(Collision coll)
    {
        //Find out what hits the basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            Destroy(collidedWith);
            // Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
        if (collidedWith.tag == "Zapple")
        {
            int score = int.Parse(scoreGT.text);
            score += 1000;
            scoreGT.text = score.ToString();
            Destroy(collidedWith);
            // Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
        if (collidedWith.tag == "Bomb")
        {
            Destroy(collidedWith);
            // Get a reference to the ApplePicker Component of the MainCamera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Call the public AppleDestroyed method of ApplePicker script
            apScript.AppleDestroyed();
        }
    }
}
