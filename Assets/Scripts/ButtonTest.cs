using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public GameObject textBox;
    public GameObject ShowUnlock;
    public GameObject livesDisplay;
    public GameObject gameBoard;
    public GameObject towerList;

    public void OnClick()
    {
        PlayerStats.Money += 1;
    }

    public void ShowUnlockFeature()
    {
        //(PlayerStats.Money >= 45 && !towerList.gameObject.activeSelf)
        if ((PlayerStats.Money >= 30 && !livesDisplay.gameObject.activeSelf)  || (PlayerStats.Money >= 65 && !gameBoard.gameObject.activeSelf))
        
            ShowUnlock.SetActive(true);
        
    }
}
