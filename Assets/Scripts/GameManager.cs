using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameBoard;
    public GameObject gameOver;
    public Text gameOverText;
    public static bool gameWon; 
    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.lives <= 0)
        {
            GameFinished();
        }
        /* if(Bullet.enemiesKilled >=100)
         {
             GameFinished();
         }*/

        if (gameWon)
        {
            gameOver.GetComponent<Text>().text = "Victory";

            if(WaveSpawner.ExistingEnemies == 0)
                GameFinished();
        }
    }

    private void GameFinished()
    {
        gameBoard.gameObject.SetActive(true);
        foreach (Transform comp in gameBoard.transform)
        {
            if (PlayerStats.Money >= 100)
                comp.gameObject.SetActive(false);
            else
                comp.gameObject.SetActive(false);
        }
        gameBoard.gameObject.SetActive(false);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        GameObject[] towers = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in towers)
        {
            Destroy(turret.gameObject);
        }

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }

        gameOver.SetActive(true);
    }
}
