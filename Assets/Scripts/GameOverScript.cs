using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

	[SerializeField] private GameObject[] highscores;

	[SerializeField] private InputField name;

	private string playerName = "";
	// Use this for initialization
	void Start () {
		
	}

	public void getName()
	{
		playerName = name.text;
		print("sain nime : " + playerName);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
