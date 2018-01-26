using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
	private int currentScore = 0;
	
	public int CurrentScore
	{
		get { return currentScore; }
		set { currentScore = value; }
	}
	
}
