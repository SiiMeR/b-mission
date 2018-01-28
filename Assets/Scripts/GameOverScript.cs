using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public dreamloLeaderBoard dl;
    public List<dreamloLeaderBoard.Score> scoreList;
    
   // dreamloLeaderBoard.Score[] scores = {};

    [SerializeField] private GameObject[] highscores;
	[SerializeField] private InputField name;
    
    [SerializeField] private GameObject prompt;
    
        
	private string playerName = "";

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

    private IEnumerator GetHighscore()
    {
        print("sain uud skoord");
        while (scoreList.Count == 0)
        {
            
            scoreList = this.dl.ToListHighToLow();
            if (scoreList.Count != 0)
            {
                int i = 0;
                foreach (dreamloLeaderBoard.Score currentScore in scoreList)
                {
                    //scoreList[i] = currentScore;
                    if (i < highscores.Length)
                    {
                        Text[] children = highscores[i].GetComponentsInChildren<Text>();
                        foreach (Text child in children)
                        {
                            print(child);
                            if (child.name == "name")
                            {
                                child.text = currentScore.playerName;
                                //   child.text = currentScore.playerName.Substring(0, 13);
                            }
                            else
                            {
                                child.text = currentScore.score.ToString();
                            }
                        }
                    }

                    i++;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public int CheckIfHighscore(int score)
    {
   
        if (scoreList.Count == 0)
        {
            return 0;
        }
        if (scoreList.Count < 10)
        {
            return 1;
        }
        if (scoreList.Count > 9 && scoreList[9].score < score)
        {
            return 1;
        }

        return -1;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void overWriteSc()
    {
        scoreList.Sort((x, y) => y.score.CompareTo(x.score));
        
        int i = 0;
        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            //scoreList[i] = currentScore;
            if (i < highscores.Length)
            {
                Text[] children = highscores[i].GetComponentsInChildren<Text>();
                foreach (Text child in children)
                {
                    print(child);
                    if (child.name == "name")
                    {
                        child.text = currentScore.playerName;
                        //   child.text = currentScore.playerName.Substring(0, 13);
                    }
                    else
                    {
                        child.text = currentScore.score.ToString();
                    }
                }
            }

            i++;
        }
        
        
    }
	public void getName()
	{   
		playerName = name.text;

	    dreamloLeaderBoard.Score sc = new dreamloLeaderBoard.Score();
	    sc.playerName = playerName;
	    sc.score = GameObject.FindGameObjectWithTag("Player").GetComponent<BeeManager>().CurrentScore;
	    scoreList.Add(sc);
	    overWriteSc();
	    
	    dl.AddScore(playerName, GameObject.FindGameObjectWithTag("Player").GetComponent<BeeManager>().CurrentScore);
        
	    
	}
}
