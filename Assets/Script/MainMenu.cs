using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string LevelToLoad = "Level01";
    public void Play()
	{
		SceneManager.LoadScene(LevelToLoad);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
