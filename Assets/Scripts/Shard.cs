using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shard : MonoBehaviour
{
    // A reference to the shard count GameObject
    public Text score;
    // How much the shard is worth (score)
    public int scoreAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            // Get current score
            int newScore = Int32.Parse(score.text) + scoreAmount;
            // Save the current score to be used across multiple scenes
            PlayerPrefs.SetInt("score", newScore);
            // Display the newScore in the UI
            score.text = newScore.ToString("D2");
            // Make shard disappear
            Destroy(gameObject);
        }
    }
}
