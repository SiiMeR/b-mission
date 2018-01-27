using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
	private const int SCORE_PICK = 10;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
	/*	if (other.gameObject.CompareTag("Player"))
		{
			BeeManager bm = GameObject.FindGameObjectWithTag("Player").GetComponent<BeeManager>();
			bm.CurrentScore += SCORE_PICK;
		} */

	}
}
