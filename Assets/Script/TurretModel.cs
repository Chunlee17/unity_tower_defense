using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretModel
{
	public GameObject prefab;
	public GameObject upgradePrefab;
	public int cost;
	public int upgradeCost;

	public int getSellCost()
	{
		return this.cost / 2;
	}
}
