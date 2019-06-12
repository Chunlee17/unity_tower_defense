using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
    public Vector3 offset;

    private Renderer rend;

    private GameObject turret;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown() {
        if (turret !=null) {
            Debug.Log("Can't build here");
            return;
        }

        //Build Turret
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + offset, transform.rotation);
        
        
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
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }
}
