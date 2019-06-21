using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
	public Image img;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(FadeIn());
    }

	public void Fadeto(string scene)
	{
		StartCoroutine(FadeOut(scene));
	}

    IEnumerator FadeIn ()
	{
		float alpha = 1;
		while (alpha > 0)
		{
			alpha -= Time.deltaTime;
			img.color = new Color(0f, 0f, 0f, alpha);
			yield return 0;
		}
	}

	IEnumerator FadeOut(string scene)
	{
		float alpha = 0;
		while (alpha < 1)
		{
			alpha += Time.deltaTime;
			img.color = new Color(0f, 0f, 0f, alpha);
			yield return 0;
		}
		SceneManager.LoadScene(scene);
	}
}
