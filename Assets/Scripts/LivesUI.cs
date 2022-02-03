using UnityEngine;
using UnityEngine.UI; 

public class LivesUI : MonoBehaviour
{
    public Text lives; 

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + PlayerStats.lives;
    }
}
