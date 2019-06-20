using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
	public Color noMoneyColor;
    public Vector3 offset;

    private Renderer rend;

	[HideInInspector]
    public GameObject turret;
	public TurretModel turretModel;
	public bool isUpgraded = false;
	BuildManager buildManager;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
		buildManager = BuildManager.instance;
    }

    private void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		//if we have click turret
		if (turret !=null) {
			buildManager.selectNode(this);
			return;
        }
		if (!buildManager.CanBuild)
		{
			return; 
		}

		buildTurret(buildManager.getTurretToBuild());
        
    }

	public void buildTurret(TurretModel turretModelToBuild)
	{
		if (PlayerStats.Money < turretModelToBuild.cost)
		{
			Debug.Log("Not Enough money to build!!");
			return;
		}

		PlayerStats.Money -= turretModelToBuild.cost;

		//get turretmodel prefab
		GameObject _turretPrefab = Instantiate(turretModelToBuild.prefab, getBuildPosition(), Quaternion.identity);
		turret = _turretPrefab;
		this.turretModel = turretModelToBuild;

		//build effect
		GameObject buildEffect = Instantiate(buildManager.buildEffectParticle, getBuildPosition(), Quaternion.identity);
		Destroy(buildEffect, 5f);
	}

	public void UpgradeTurret()
	{
		if (PlayerStats.Money < turretModel.upgradeCost)
		{
			Debug.Log("Not Enough money to build!!");
			return;
		}

		//destroy old turret
		Destroy(turret);

		PlayerStats.Money -= turretModel.upgradeCost;
		
		//build new one
		GameObject _turret = Instantiate(turretModel.upgradePrefab, getBuildPosition(), Quaternion.identity);
		turret = _turret;

		//upgrade and build effetct
		GameObject buildEffect = Instantiate(buildManager.buildEffectParticle, getBuildPosition(), Quaternion.identity);
		Destroy(buildEffect, 2f);
		isUpgraded = true;
		
	}

	public void SellTurret()
	{
		PlayerStats.Money += turretModel.getSellCost();
		GameObject sellEffect  = Instantiate(buildManager.sellEffectParticle, getBuildPosition(), Quaternion.identity);
		Destroy(sellEffect, 3f);
		Destroy(turret);
		turretModel = null;

	}

	public Vector3 getBuildPosition()
	{
		return transform.position + offset;
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButton(1))
		{
			if (turret == null) return;
			Destroy(turret);
			//turret = null;
		}
	}

	private void OnMouseEnter(){
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = noMoneyColor;
		}
        
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }
}
