using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
	enum PollenColor
	{
		RED,
		BLUE,
		PURPLE,
		NONE
	}

	private PollenColor currentPollenColor = PollenColor.NONE;
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
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		GameObject otherObject = other.gameObject;

		if (otherObject.GetComponent<FlowerController>())
		{
			beeAnimator.SetTrigger("PollenPick");

			bool equals = false;
			PollenColor flowerColor = PollenColor.NONE;
			
			
			switch (otherObject.tag)
			{
					case "BlueFlower":
						if (currentPollenColor == PollenColor.BLUE)
						{
							equals = true;
							
						}
						flowerColor = PollenColor.BLUE;
						break;
					case "RedFlower":
						if (currentPollenColor == PollenColor.RED)
						{
							equals = true;
							
						}
						flowerColor = PollenColor.RED;
						break;
					case "PurpleFlower":
						if (currentPollenColor == PollenColor.PURPLE)
						{
							equals = true;
							
						}
						flowerColor = PollenColor.PURPLE;
						break;
			}

			if (equals)
			{
				CurrentScore += 10;
				currentPollenColor = PollenColor.NONE;
				beeAnimator.SetTrigger("DropPollen");
			}
			else
			{
				currentPollenColor = flowerColor;

				switch (currentPollenColor)
				{
						case PollenColor.BLUE:
							beeAnimator.SetTrigger("Blue");
							break;
						case PollenColor.PURPLE:
								beeAnimator.SetTrigger("Purple");
								break;
						case PollenColor.RED:
								beeAnimator.SetTrigger("Red");
								break;
				}
			}
		//	Destroy(gameObject);
		}
	}
}
