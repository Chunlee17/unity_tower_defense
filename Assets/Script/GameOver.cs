using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
	public Text roundsText;
	public SceneFader sceneFader;

	private void OnEnable()
	{
		Time.timeScale = 0f;
		roundsText.text = PlayerStats.Rounds.ToString();
	}


	public void Retry()
	{
		Time.timeScale = 1f;
		sceneFader.Fadeto(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		Time.timeScale = 1f;
		sceneFader.Fadeto("MainMenu");
	}
}

