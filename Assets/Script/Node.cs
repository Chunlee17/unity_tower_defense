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

	[Header("Optional")]
    public GameObject turret;

	BuildManager buildManager;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
		buildManager = BuildManager.instance;
    }

    private void OnMouseDown() {

		if(!buildManager.CanBuild)
		{
			return;
		}
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (turret !=null) {
            Debug.Log("Can't build here");
            return;
        }

		buildManager.buildTurretOn(this);
        
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
