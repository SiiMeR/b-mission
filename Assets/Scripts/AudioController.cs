using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioSource audioSource;

	public const int COOLDOWN = 5;

	public float timespent = 0;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timespent += Time.deltaTime;
		if (timespent > COOLDOWN)
		{
			timespent = 0;
			audioSource.pitch += 0.02f;
		}
	}
}
