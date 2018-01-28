using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    dreamloLeaderBoard dl;
    List<dreamloLeaderBoard.Score> scoreList;
    dreamloLeaderBoard.Score[] scores;

    [SerializeField] private GameObject[] highscores;
	
    void Start()
    {
        GetHighscores();
    }
	// Use this for initialization
	public void GetHighscores () {
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        this.dl.LoadScores();

        scoreList = new List<dreamloLeaderBoard.Score>();
        StartCoroutine(GetHighscore());
    }

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator GetHighscore()
    {
        while (scoreList.Count == 0)
        {
            scoreList = this.dl.ToListHighToLow();
            if (scoreList != null)
            {
                int i = 0;
                foreach (dreamloLeaderBoard.Score currentScore in scoreList)
                {
                    scores[i] = currentScore;
                    if (i < highscores.Length) {
                        Text[] children = highscores[i].GetComponentsInChildren<Text>();
                        foreach (Text child in children) {
                            if (child.name == "name")
                            {
                                child.text = currentScore.playerName.Substring(0, 13);
                            } else
                            {
                                child.text = currentScore.score.ToString();
                            }
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void CheckIfHighscore(int score)
    {
    }
}
