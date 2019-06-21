using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public GameObject UI;
	public SceneFader sceneFader;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Toggle();
		}
    }

	void Toggle()
	{
		UI.SetActive(!UI.activeSelf);

		if (UI.activeSelf == true) {
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
		
	}

	public void Retry()
	{
		Toggle();
		sceneFader.Fadeto(SceneManager.GetActiveScene().name);
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		Toggle();
		sceneFader.Fadeto("MainMenu");
		Debug.Log("Go to Menu!!");
	}

	public void Continue()
	{
		Toggle();
	}
}
