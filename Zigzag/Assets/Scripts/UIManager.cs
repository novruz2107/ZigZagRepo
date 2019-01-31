using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;

    public int scores;
    public int highScores;

    public static UIManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start () {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        scores = 0;
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (scores > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", scores);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", scores);
        }
        highScore2.text = PlayerPrefs.GetInt("HighScore").ToString();
        score.text = scores.ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0); 
    }
}
