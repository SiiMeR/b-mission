using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
	

	[SerializeField] private GameObject onCloseAction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void BackButtonClicked()
	{
		onCloseAction.SetActive(false);
	}
}
