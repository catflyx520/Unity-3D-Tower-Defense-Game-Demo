using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   // public float speed = 500f;
    private Transform target;
    private int wavePointIndex = 0;
    public Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.points[0];

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized *enemy.speed * Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position,target.position)<=0.4f)
        {
            GetNextWayPoint();
        }
        enemy.speed = enemy.startSpeed; 
    }
    void GetNextWayPoint()
    {   
        if(wavePointIndex>=WayPoints.points.Length-1)
        {
            EnemyGotAway(); 
            return;
        }
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    void EnemyGotAway()
    {
        if(PlayerStats.lives > 0)
        {
            PlayerStats.lives--;
            PlayerStats.Money -= 10;
            WaveSpawner.ExistingEnemies--;
            Destroy(gameObject);
        }
    }
}
