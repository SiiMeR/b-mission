using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
	private GameObject currentPollen;
	private int currentScore = 0;


	public GameObject CurrentPollen
	{
		get { return currentPollen; }
		set { currentPollen = value; }
	}

	public int CurrentScore
	{
		get { return currentScore; }
		set { currentScore = value; }
	}
	
}
