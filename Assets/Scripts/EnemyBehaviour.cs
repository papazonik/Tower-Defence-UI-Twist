using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Healthbar healthbar;
    Health health;
    void Start()
    {
        health = GetComponent<Health>();
        healthbar.SetHealth(health.getCurrentHealth(), health.getMaxHealth());
    }

    void Update()
    {
        healthbar.SetHealth(health.getCurrentHealth(), health.getMaxHealth());
    }
}
