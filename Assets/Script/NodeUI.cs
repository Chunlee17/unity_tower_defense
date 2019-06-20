using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node targetNode;

	public GameObject ui;

	public Text upgradeCost;
	public Text sellAmount;
	public Button upgradeButton;

	public void setUITargetOnNode(Node node)
	{	
		ui.SetActive(true);
		targetNode = node;
		transform.position = targetNode.getBuildPosition();
		if (!targetNode.isUpgraded)
		{
			upgradeCost.text = "$ "+ targetNode.turretModel.upgradeCost;
			upgradeButton.interactable = true;
		}
		else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}
		sellAmount.text = "$ "+targetNode.turretModel.getSellCost();
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

	public void SellTurret()
	{
		targetNode.SellTurret();
		BuildManager.instance.DeselectNode();
	}
}
