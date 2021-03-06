﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

	private BuildManager buildManager;
	public TurretModel standartTurret;
	public TurretModel missileLauncher;
	public TurretModel laserBeamer;


	private void Start()
	{
		buildManager = BuildManager.instance;
	}
	public void selectStandardTurret()
	{
		buildManager.selectTurretToBuild(standartTurret);
	}


	public void selectMissileLauncher()
	{
		buildManager.selectTurretToBuild(missileLauncher);
	}

	public void selectLaserBeamer()
	{
		buildManager.selectTurretToBuild(laserBeamer);
	}
}
