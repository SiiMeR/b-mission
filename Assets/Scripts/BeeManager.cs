using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
	[SerializeField] private RuntimeAnimatorController BluePollenAnimation;
	[SerializeField] private RuntimeAnimatorController RedPollenAnimation;
	[SerializeField] private RuntimeAnimatorController PurplePollenAnimation;

	private Animator beeAnimator;
	
	private int currentScore = 0;
	
	public int CurrentScore
	{
		get { return currentScore; }
		set { currentScore = value; }
	}


	void Start()
	{
		beeAnimator = GetComponent<Animator>();
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{	
			beeAnimator.runtimeAnimatorController = RedPollenAnimation;
		}
	}
}
