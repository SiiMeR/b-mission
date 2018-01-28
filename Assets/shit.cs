using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shit : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
//		StartCoroutine(play());
		
	}

	public void leene()
	{
		SceneManager.LoadScene("Reimo");
	}
	
/*	
	IEnumerator play()
	{
	//	yield return new WaitForSecondsRealtime(10.0f);
		SceneManager.LoadScene("Reimo");
	}
*/	
	// Update is called once per frame
	void Update () {
		
	}
}
