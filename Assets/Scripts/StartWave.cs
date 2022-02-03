using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour
{
    public GameObject BeginWave;
    public static int a = 0;

   public void OnClick()
    {
        a = 1;
        BeginWave.SetActive(false);
    }
   
}
