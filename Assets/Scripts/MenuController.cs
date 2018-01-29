using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

	[SerializeField] private GameObject audioModal;
	[SerializeField] private GameObject guideModal;	
	[SerializeField] private GameObject highScoreModal;	

	[SerializeField] private Slider music;
	[SerializeField] private Slider sound;
	
	// Use this for initialization
	void Start ()
	{
		audioModal.SetActive(false);
		guideModal.SetActive(false);
		highScoreModal.SetActive(false);
		
		
		music.value = PlayerPrefs.GetFloat("MusicVol",1f);
		sound.value = PlayerPrefs.GetFloat("SoundVol",1f);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnLenComplete()
	{
		SceneManager.LoadScene("Reimo");
	}
	public void OnPlayClicked()
	{
		SceneManager.LoadScene("New Scene");
		//	
	}

	public void OnExitClicked()
	{
		Application.Quit();
	}

	public void OnScoreClicked()
	{
		highScoreModal.SetActive(true);
	}
	
	public void OnGuideClicked()
	{
		guideModal.SetActive(true);
	}

	public void OnAudioClicked()
	{
		audioModal.SetActive(true);
	}

	public void OnMusicValueChanged()
	{
		Camera.main.gameObject.GetComponent<AudioSource>().volume = music.value;
		PlayerPrefs.SetFloat("MusicVol", music.value);
	}
	
	public void OnSoundValueChanged()
	{
		PlayerPrefs.SetFloat("SoundVol", sound.value);
	}


}
