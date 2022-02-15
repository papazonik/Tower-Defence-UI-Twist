using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    public int cost;
    public float range = 4f;
    private float fireRate = 1f;
    private float fireCountdown = 0f;
    private Vector3 firePointVector3;
    public GameObject projectilePrefab;
    private GameObject currentTarget;


    private void Awake()
    {
        firePointVector3 = firePoint.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Shoot()
    {
        GameObject _projectile = Instantiate(projectilePrefab, firePointVector3, Quaternion.identity);
        Projectile projectile = _projectile.GetComponent<Projectile>();
        projectile.SetTarget(currentTarget);
    }

    void UpdateTarget()         //Find closest enemy in range
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy && shortestDistance <= range)
        {
            currentTarget = nearestEnemy;
        }
        else
        {
            currentTarget = null;
        }       
    }

    void Update()
    {
        if (!currentTarget)
        {
            return;
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }
}
