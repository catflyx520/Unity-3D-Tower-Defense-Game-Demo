using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayEnemiesKilled : MonoBehaviour
{
    public GameObject enemiesKilledDisplay;

    public int enemiesKilled;
    
    void Update()
    {
        enemiesKilled = Enemy.enemiesKilled;
        enemiesKilledDisplay.GetComponent<Text>().text ="Enemies Killed:"+Enemy.enemiesKilled;
    }
}
