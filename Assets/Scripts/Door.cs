using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // If the player has collided with the door, loads a scene. 
        // Look back at online tutorial for different teleports
        // https://learn.meritacademy.tech/docs/unity-and-cs/top-down-game/06/
        if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene("Dungeon1", LoadSceneMode.Single);
        }
    }
}
