using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
	private Animator beeAnimator;
	
	private int currentScore = 0;
	private bool isHoldingPollen;
	
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
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		GameObject otherObject = other.gameObject;

		if (otherObject.tag.Contains("Flower"))
		{
			
			beeAnimator.SetTrigger("PollenPick");

			if (isHoldingPollen)
			{
				beeAnimator.SetTrigger("DropPollen");
				isHoldingPollen = false;
				return;
			}
			
			
			switch (otherObject.tag)
			{
				case "BlueFlower":
					beeAnimator.SetTrigger("Blue");
					break;
				case "RedFlower":
					beeAnimator.SetTrigger("Red");
					break;
				case "PurpleFlower":
					beeAnimator.SetTrigger("Purple");
					break;
					
			}
			isHoldingPollen = true;
		}
	}
}
