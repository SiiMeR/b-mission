using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

	[SerializeField] private Text timeText;
	[SerializeField] private Text scoreText;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreText.text = GameObject.FindGameObjectWithTag("Player").GetComponent<BeeManager>().CurrentScore.ToString();
		timeText.text = Mathf.Floor(Time.timeSinceLevelLoad).ToString();
	}
}
