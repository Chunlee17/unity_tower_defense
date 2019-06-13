using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

	public BuildManager buildManager;


	private void Start()
	{
		buildManager = BuildManager.instance;
	}
	public void purchaseStandardTurret()
	{
		buildManager.setTurretToBuild(buildManager.standardTurretPrafab);
	}


	public void purchaseAnotherTurret()
	{
		buildManager.setTurretToBuild(buildManager.anotherTurretPrafab);
	}
}
