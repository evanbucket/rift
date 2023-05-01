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
        sr = GetComponent<SpriteRenderer>();
        requiredScore.text = ScoresByScene.requiredScoreByScene["Dungeon1"].ToString("D2");
    }

    public void Update()
    {
        int score = PlayerPrefs.GetInt("score");
        if (score < ScoresByScene.requiredScoreByScene[this.tag]) {
            sr.color = Color.grey;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        int score = PlayerPrefs.GetInt("score");
        // If the player has collided with the door, loads a scene based on what tag the door has. 
        if (other.gameObject.tag == "Player") {
            if (this.tag == "Start") {
                SceneManager.LoadScene("Start", LoadSceneMode.Single);
            } else if (this.tag == "Dungeon1" && score >= ScoresByScene.requiredScoreByScene[this.tag]) {
                SceneManager.LoadScene("Dungeon1", LoadSceneMode.Single);
                Debug.Log("I can go through the Dungeon1 door!");
                requiredScore.text = ScoresByScene.requiredScoreByScene["Dungeon2"].ToString("D2");
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
        ["Dungeon1"] = 2,
        ["Dungeon2"] = 4,
    };
}