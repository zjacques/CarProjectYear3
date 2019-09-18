using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject player;
    int distanceScore;
    int unscoredDistance;
    public GameObject restartButton;
    public Text ScoreText;
    public Text LivesText;
    int Lives = 3;
    public int Score = 0;
    public bool penalty = false;
    float penaltyTime = 0;
    
	// Update is called once per frame
	void Update () {
        if (penalty)
        {
            penaltyTime += Time.deltaTime;
            if(penaltyTime >= 2.5f)
            {
                penalty = false;
            }
        }
        if (player.GetComponent<PlayerController>().Health <= 0 && player.GetComponent<PlayerController>().alive)
        {
            player.GetComponent<PlayerController>().alive = false;
            Lives--;
            LivesText.text = "Lives: " + Lives;
            if (Lives <= 0)
            {
                restartButton.SetActive(true);
                LivesText.text = "Lives: 0";
                player.GetComponent<PlayerController>().livesLeft = false;
            }
            player.GetComponent<PlayerController>().Dead();
        }
        if (!penalty)
        {
            distanceScore = (int)player.transform.position.z;
            Debug.Log(player.transform.position.z);
            ScoreText.text = "Score: " + (Score + distanceScore- unscoredDistance);
        }
        else
        {
            unscoredDistance = (int)player.transform.position.z - distanceScore;
        }
    }

    public void EnemyDestroyed()
    {
        if (!penalty)
        {
            Score += 100;
        }
    }

    public void CivilianDestroyed()
    {
        penalty = true;
        penaltyTime = 0;
        ScoreText.text = "No Score...";
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
