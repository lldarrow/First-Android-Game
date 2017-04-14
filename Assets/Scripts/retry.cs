using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*****************************************************
 * Programmer: Luke Darrow
 * Description: Android game where the objective is
 * to keep the center of the red circle in the blue
 * circle using your device's accelerometer.
 ****************************************************/

public class retry : MonoBehaviour {

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //if game over and player taps screen, reload the game
        if (player.GetComponent<PlayerController>().dead == 1 && Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("FirstScene");
        }
    }

    public void OnMouseUp()
    {
        
        if(player.GetComponent<PlayerController>().dead == 1)
        {
            SceneManager.LoadScene("FirstScene");
        }
    }
}
