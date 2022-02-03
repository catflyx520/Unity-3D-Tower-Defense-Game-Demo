using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    //Create Headers for later iterations
    private Transform target;
    private Enemy targetEnemy;
    public float range = 1000f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float rotSpeed = 10f;
    public GameObject Bullet;
    public Transform firePoint; 
    public float bulletsRate = 1f;
    private float bulletTimer = 0f;
    [Header("user laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public int damageOverTime = 50;
    public float slowPct = .5f;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f,0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else target =null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(useLaser)
            {
                if (lineRenderer.enabled) lineRenderer.enabled = false;
            }
            return;

        }
        LockOnTarget();
        if(useLaser)
        {
            laser();
        }
        else { 
        if(bulletTimer <= 0f)
        {
            ShootEnemy();
            bulletTimer = 1f / bulletsRate;
        }

        bulletTimer -= Time.deltaTime;
        }
    }

    void ShootEnemy()
    {
        GameObject bulletRef = (GameObject)Instantiate(Bullet, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletRef.GetComponent<Bullet>();

        if (bullet != null)
            bullet.LockTarget(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void laser()
    {
       targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);
        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
