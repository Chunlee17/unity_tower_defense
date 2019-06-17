using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LiveUI : MonoBehaviour
{
	public Text liveText;
    void Update()
    {
		liveText.text = string.Format("Live: {0}", PlayerStats.Lives);
    }
}
