using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // If the player has collided with the door, loads a scene based on what tag the door has. 
        if (other.gameObject.tag == "Player") {
            if (this.tag == "Start") {
                SceneManager.LoadScene("Start", LoadSceneMode.Single);
            } else if (this.tag == "Dungeon1") {
                SceneManager.LoadScene("Dungeon1", LoadSceneMode.Single);
            }
        }
    }
}