using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject standardTurretPrafab;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        turretToBuild = standardTurretPrafab;
    }


    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
