using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretModel turretToBuild;

    public GameObject standardTurretPrafab;

	public GameObject missileLauncherPrafab;

	public GameObject buildEffectParticle;

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

	public void buildTurretOn(Node node)
	{
		if(PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not Enough money to build!!");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;
		GameObject turret = Instantiate(turretToBuild.prefab,node.getBuildPosition(),Quaternion.identity);
		GameObject buildEffect = Instantiate(buildEffectParticle, node.getBuildPosition(), Quaternion.identity);
		Destroy(buildEffect, 5f);

		Debug.Log("Player Money left: " + PlayerStats.Money);
		node.turret = turret;
	}

	public void selectTurretToBuild(TurretModel turret)
	{
		turretToBuild = turret;
	}
}
