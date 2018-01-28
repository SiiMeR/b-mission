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

	[SerializeField] private Slider music;
	[SerializeField] private Slider sound;
	
	// Use this for initialization
	void Start ()
	{	
		music.value = PlayerPrefs.GetFloat("MusicVol");
		sound.value = PlayerPrefs.GetFloat("SoundVol");
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
