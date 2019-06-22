using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWon : MonoBehaviour
{

	public Text levelSurvived;

	public SceneFader sceneFader;

	public int NextLevel = 2;

	public string levelToLoad = "Level02";
	
	IEnumerator AnimateText()
	{
		int i = 0;
		while( i < PlayerStats.Rounds)
		{
			i++;
			levelSurvived.text = (i+1).ToString();
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void OnEnable()
	{
		StartCoroutine(AnimateText());
	}

	public void Continue()
	{
		PlayerPrefs.SetInt("levelReached", NextLevel);
		sceneFader.Fadeto(levelToLoad);
	}

	public void Menu()
	{
		sceneFader.Fadeto("MainMenu");
	}
	
}
