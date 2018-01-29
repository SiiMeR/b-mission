using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {
	
	public dreamloLeaderBoard dl;
	public List<dreamloLeaderBoard.Score> scoreList;

	[SerializeField] private GameObject[] highscores;

	private void Start()
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
		while (scoreList.Count == 0)
		{
            
			scoreList = this.dl.ToListHighToLow();
			if (scoreList.Count != 0)
			{
				int i = 0;
				foreach (dreamloLeaderBoard.Score currentScore in scoreList)
				{
					if (i < highscores.Length)
					{
						Text[] children = highscores[i].GetComponentsInChildren<Text>();
						foreach (Text child in children)
						{
							if (child.name == "name")
							{
								child.text = currentScore.playerName;
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
 
 
}
