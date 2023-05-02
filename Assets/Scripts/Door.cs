using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{    
    public Text requiredScore;
    private SpriteRenderer sr;
    public void Start()
    {
        requiredScore.text = ScoresByScene.requiredScoreByScene[SceneManager.GetActiveScene().name].ToString("D2");
        PlayerPrefs.SetInt("score", 0);
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.grey;
    }

    public void Update()
    {
        int score = PlayerPrefs.GetInt("score");
        if (score < ScoresByScene.requiredScoreByScene[SceneManager.GetActiveScene().name]) {
            sr.color = Color.grey;
        } else if(score >= ScoresByScene.requiredScoreByScene[SceneManager.GetActiveScene().name]) {
            sr.color = Color.blue;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        int score = PlayerPrefs.GetInt("score");
        // If the player has collided with the door, loads a scene based on what tag the door has. 
        if (other.gameObject.tag == "Player") {
            if (score >= ScoresByScene.requiredScoreByScene[SceneManager.GetActiveScene().name]) {
                SceneManager.LoadScene(this.tag, LoadSceneMode.Single);
                Debug.Log("I can go through the Dungeon1 door!");
                // set score to 0
                //  PlayerPrefs.SetInt("score", 0);
            } /* else if (this.tag == Dungeon [PUT A SYSTEM TO FILL IN THE NUMBER AUTOMATICALLY HERE]) */
        }
    }
}

public static class ScoresByScene
{
    public static Dictionary<string, int> requiredScoreByScene = new Dictionary<string, int> {
        // any door of scene "debugroom" has a requirement of a score of 2
        ["Start"] = 0,
        ["debugroom"] = 0,
        ["Dungeon1"] = 2,
        ["Dungeon2"] = 4,
    };
}