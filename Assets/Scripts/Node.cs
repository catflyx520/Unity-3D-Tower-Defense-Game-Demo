using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 positionOffset;
    BuildManager buildManager;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
       
        if(turret != null)
        {
            buildManager.SelectNode(this);

            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
       // buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough coins");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab,GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBluePrint = blueprint;
        Debug.Log("Turret build" );
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Not enough coins to upgrade that");
            return;
        }
        PlayerStats.Money -= turretBluePrint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        isUpgraded = true;
        Debug.Log("Turret Upgraded");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();
        Destroy(turret);
        turretBluePrint = null;
    }
  void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild)
        {
            return;
        }
        rend.material.color = hoverColor;

    }
    void OnMouseExit()
    {
        rend.material.color = startColor;   
    }


}
