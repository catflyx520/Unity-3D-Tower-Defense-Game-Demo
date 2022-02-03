using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 70f;
    public float explosionRadius = 0f;
    public int damage = 50;
   
    public void LockTarget(Transform targ)
    {
        target = targ;
    } 
   
    // Update is called once per frame
    void Update()
    {
        
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distinFrame = bulletSpeed * Time.deltaTime; 

        if(dir.magnitude <= distinFrame)
        {
            Hit();
            
            return;
        }

        transform.Translate(dir.normalized * distinFrame, Space.World);
        transform.LookAt(target);
       
    }

    void Hit()
    {    
        if(explosionRadius >0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }
     
        Destroy(gameObject);
       
        

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);
        foreach( Collider collider in colliders)
        {
            if(collider.tag=="Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage( Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
        // Destroy(Enemy.gameObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
}
