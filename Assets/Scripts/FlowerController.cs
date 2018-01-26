using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{

	private const int SCORE_PICK = 10;

	private Color color;

	private List<Color> flowerColors = new List<Color>(){ Color.red, Color.yellow, Color.green };
	// Use this for initialization
	void Start ()
	{
		color = flowerColors[Random.Range(0, flowerColors.Count)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>().CurrentScore += SCORE_PICK;
		//		Destroy(gameObject);
		}

	}
}
