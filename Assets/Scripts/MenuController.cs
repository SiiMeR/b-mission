﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	[SerializeField] private GameObject audioModal;
	[SerializeField] private GameObject guideModal;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPlayClicked()
	{
		SceneManager.LoadScene("Reimo");
	}

	public void OnGuideClicked()
	{
		guideModal.SetActive(true);
	}

	public void OnAudioClicked()
	{
		audioModal.SetActive(true);
	}


}