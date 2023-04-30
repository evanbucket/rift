using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // if its the zeroth scene (buildIndex == 0)
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            // reset the score
            PlayerPrefs.SetInt("score", 0);
        }
        GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt("score").ToString();

        // TODO: functionality to reset the score whenever you reach a new floor.
    }
}
