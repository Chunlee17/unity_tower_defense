using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretModel turretToBuild;

	private Node selectedNode;

	public GameObject buildEffectParticle;

	public GameObject sellEffectParticle;

	public NodeUI nodeUI;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

	public bool CanBuild
	{
		get{ return turretToBuild != null; }
	}
	public bool HasMoney
	{
		get { return PlayerStats.Money >= turretToBuild.cost; }
	}

	public void selectNode(Node node)
	{
		if(selectedNode == node)
		{
			DeselectNode();
			return;
		}
		selectedNode = node;
		turretToBuild = null;

		nodeUI.setUITargetOnNode(node);
	}

	public void selectTurretToBuild(TurretModel turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.HideUI();
	}

	public TurretModel getTurretToBuild()
	{
		return turretToBuild;
	}
}
