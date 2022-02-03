using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNextWave : MonoBehaviour
{
    public static bool startNextWave;
    public GameObject startWave; 

    public void ClickedNextWave()
    {
        startNextWave = true;
        startWave.SetActive(false);
        startWave.SetActive(false);
    }
}
