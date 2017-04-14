using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*****************************************************
 * Programmer: Luke Darrow
 * Description: Android game where the objective is
 * to keep the center of the red circle in the blue
 * circle using your device's accelerometer.
 ****************************************************/

public class PlayerController : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public Transform zone;          //the background circle

    public Text stats;              //the score's text object
    private int score;              //the score as an integer
    private float timer;            //float acting as our clock, Time is in minutes so we need this to convert to seconds
    private int highscore;

    public Text GameOver;           //game over text
    public int dead;                //game over flag

    // Use this for initialization
    //sets text elements to empty text and scores to zero
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        stats.text = "";
        GameOver.text = "";
        score = 0;
        timer = 0.0f;
        dead = 0;
        highscore = 0;
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //move the circle based on accelerometer input
        transform.Translate(Input.acceleration.x * speed, Input.acceleration.y * speed, 0);

        //use math to check if the player circle's center is outside of the background circle
        if (Mathf.Sqrt((transform.position.x - zone.position.x) * (transform.position.x - zone.position.x) + (transform.position.y - zone.position.y) * (transform.position.y - zone.position.y)) > 1)
        {
            //game over, set flag and update highscore
            if(score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
                PlayerPrefs.Save();
            }

            //output high score and retry prompt
            highscore = PlayerPrefs.GetInt("highscore");
            GameOver.text = "HIGH SCORE: " + highscore + "\nTap To Retry";
            dead = 1;
        }

        if (dead == 0) //if not game over, increment score and update
        {
            timer += Time.deltaTime;
            score = Mathf.RoundToInt(timer);

            //update highscore on frame just in case player accidentally closes the game before ending
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
                PlayerPrefs.Save();
            }

            //output the score
            stats.text = "SCORE: " + score.ToString();
        }
    }

    private void Update()
    {
        
    }
}
