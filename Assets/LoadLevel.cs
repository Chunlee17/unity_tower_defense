using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
	public SceneFader sceneFader;

	public void LoadToLevel(string levelName)
	{
		sceneFader.Fadeto(levelName);
	}
}
