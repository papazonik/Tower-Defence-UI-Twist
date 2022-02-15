using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public uint damage = 20;
    float attackCooldown = 0f;
    private float attackRate = 0.5f;
    public float attackRange = 3f;
    GameObject currentTarget;
    GameManager gameManager;
    public GameObject projectilePrefab;
    EnemyMovement enemyMovementScript;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SetTarget();
        enemyMovementScript = GetComponent<EnemyMovement>();
    }

    void SetTarget()
    {
        if (gameManager.hearts.Count > 0)
        {
            currentTarget = gameManager.hearts[gameManager.hearts.Count - 1].gameObject;
        }
    }

    IEnumerator Iterate()
    {
        yield return new WaitForSeconds(1f);
        SetTarget();
    }

    void Shoot()
    {
        GameObject _projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = _projectile.GetComponent<Projectile>();
        projectile.SetTarget(currentTarget);
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (!currentTarget)
        {
            SetTarget();
            return;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            if (distance <= attackRange)
            {
                print("distance " + distance + " attack range: " + attackRange);
                if (attackCooldown <= 0f)
                {
                    Shoot();
                    enemyMovementScript.enabled = false;
                    attackCooldown = 1f / attackRate;
                }
            }
        }
    }
}
