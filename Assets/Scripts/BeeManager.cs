using UnityEngine;
using UnityEngine.UI;

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
  //  private GameObject lastFlower = null;

	public int CurrentScore
	{
		get { return currentScore; }
		set { currentScore = value; }
	}
	
	
    [SerializeField] public Text punText;
    public string[] puns;
    public string[] deathPuns;

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
			AudioManager.instance.Play("PollinateSound");
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
				;
				;
				CurrentScore += 10;
                if (puns.Length > 0)
                {
                    punText.text = puns[Random.Range(0, puns.Length)];
                    Invoke("RemovePun", 3);
                }
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

      //      lastFlower = otherObject;
		//	Destroy(gameObject);
			Destroy(otherObject.GetComponent<FlowerController>());
		}
	}

    public void ShowDeathPun()
    {
        if (deathPuns.Length > 0)
        {
            punText.text = deathPuns[Random.Range(0, deathPuns.Length)];
            Invoke("RemovePun", 3);
        }
    }

    void RemovePun()
    {
        punText.text = "";
    }
}
