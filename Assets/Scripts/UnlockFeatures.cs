using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockFeatures : MonoBehaviour
{
    public GameObject unlock;
    public GameObject gameBoard;
    public GameObject livesDisplay;
    public GameObject towerList; 


    public void UnlockLives()
    {
        if (PlayerStats.Money >= 20 && !gameBoard.gameObject.activeSelf && !livesDisplay.gameObject.activeSelf)
        {
            PlayerStats.Money -= 30;
            livesDisplay.SetActive(true);
            unlock.SetActive(false);
        }
    }

   /* public void unLockTowerList()
    {    //&& !towerList.active && livesDisplay.active
        if (PlayerStats.Money >= 45 )
        {
            var towers = (PlayerStats.Money) /5;
            towerList.SetActive(true);
            towerList.GetComponent<Text>().text = "Towers: " + towers;
            unlock.SetActive(false);
        }
    }   */

    public void UnlockGame()
    {
        if (!(PlayerStats.Money >= 65))
            return; 

        gameBoard.gameObject.SetActive(true);
        foreach(Transform comp in gameBoard.transform)
        {
            if (PlayerStats.Money >= 65)
                comp.gameObject.SetActive(true);
            else
                comp.gameObject.SetActive(false);
        }
       
        if (PlayerStats.Money >= 65)
            unlock.SetActive(false);
        PlayerStats.Money -= 30;
    }

}
