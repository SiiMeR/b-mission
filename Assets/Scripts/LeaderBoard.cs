using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour {
    dreamloLeaderBoard dl;
    List<dreamloLeaderBoard.Score> scoreList;

    // Use this for initialization
    void Start () {
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
                foreach (dreamloLeaderBoard.Score currentScore in scoreList)
                {
                    Debug.Log(currentScore.playerName + " " + currentScore.score.ToString());
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}
