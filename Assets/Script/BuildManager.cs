using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject standardTurretPrafab;

	public GameObject anotherTurretPrafab;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

	public void setTurretToBuild(GameObject turret)
	{
		turretToBuild = turret;
	}
}
