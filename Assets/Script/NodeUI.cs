using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node targetNode;

	public GameObject ui;

	public Text upgradeCost;

	public Button upgradeButton;

	public void setUITargetOnNode(Node node)
	{	
		ui.SetActive(true);
		targetNode = node;
		transform.position = targetNode.getBuildPosition();
		if (!targetNode.isUpgraded)
		{
			upgradeCost.text = "$ "+targetNode.upgradeTurret.upgradeCost;
			upgradeButton.interactable = true;
		}
		else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}
		
	}

	public void HideUI()
	{
		ui.SetActive(false);
	}

	public void UpgradeTurret()
	{
		Debug.Log("click");
		targetNode.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}
}
