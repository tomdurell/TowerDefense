using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public Transform RotatingPiece;
    public string EnemyTag = "Enemy";
    public float range = 12f;

    public float fireRate = 2f;
    public float shotCooldown = 0f;


    // Use this for initialization
    void Start()
    {
        //start looking for enemies twice every second - not placed in update loop due to processing power required to calculate distances etc
        InvokeRepeating("TargetAquisition", 0f, 0.5f);
    }

    void TargetAquisition()
    {
        //initialise variables
        float closestDistance = Mathf.Infinity;
        GameObject eligibleTarget = null;
        //find all enemies in scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        //loop through and calculate distances from enemies
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            //iterate through and update information on closest enemy
            if (distance < closestDistance)
            {
                closestDistance = distance;
                eligibleTarget = enemy;
            }
        }
        //once the closest target is found, check that we actually have a target, and that it is in range
        if (eligibleTarget != null && closestDistance < range)
        {
            target = eligibleTarget.transform;
        }
        else //if both conditions are not met, set target to null
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(shotCooldown);
        //check if we have a target
        if (target == null)
        {
            return;
        }
        //smoothly rotate to look at target
        Vector3 Direction = target.position - transform.position;
        Quaternion lookatEnemy = Quaternion.LookRotation(Direction);
        Vector3 rotation = Quaternion.Lerp(RotatingPiece.rotation, lookatEnemy, Time.deltaTime * 5).eulerAngles;
        RotatingPiece.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
        if (shotCooldown <= 0f)
        {
            Shoot();
            shotCooldown = 2f;
        }

        shotCooldown -= Time.deltaTime;

    }

    void OnDrawGizmosSelected()
    {
        //used to draw range indicators on turrets
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        Debug.Log("Shooting");
    }
}