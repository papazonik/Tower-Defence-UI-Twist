using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public uint damage = 20;
    float attackRate = 0.5f;
    float attackCooldown = 0f;
    private float fireRate = 0.5f;
    float attackRange = 2f;
    GameObject currentTarget;
    GameManager gameManager;
    public GameObject projectilePrefab;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SetTarget();
    }

    void SetTarget()
    {
        if (gameManager.hearts.Count > 0)
        {
            currentTarget = gameManager.hearts[gameManager.hearts.Count - 1].gameObject;
        }
    }

    void GoAttack()
    {
        //Stop if in range of last heart in heart list

        //Stand still and deal damage over time to last heart in heart list

        
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


    // Update is called once per frame
    void Update()
    {
        if (!currentTarget)
        {
            SetTarget();
            return;
        }
        else
        {
            if (attackCooldown <= 0f)
            {
                Shoot();
                attackCooldown = 1f / fireRate;
            }
            attackCooldown -= Time.deltaTime;
        }
    }
}
