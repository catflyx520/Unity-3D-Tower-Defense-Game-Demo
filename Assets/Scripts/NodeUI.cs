using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target;
    public Text upgradeCost;
    public Button upgradedButton;
    public Text sellAmount;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$ " + target.turretBluePrint.upgradeCost;
            upgradedButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradedButton.interactable = false;
        }
        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();
        UI.SetActive(true);
      
    }
    public void Hide()
    {
        UI.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
