using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint missleLauncher;
    public TurretBluePrint LaserBeamer;
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
        
    }
    public void SelectStandardTurret()
    {
        Debug.Log("standard turret purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissleLauncher()
    {
        Debug.Log("missile launcher purchased");
        buildManager.SelectTurretToBuild(missleLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer purchased");
        buildManager.SelectTurretToBuild(LaserBeamer);
    }

}
