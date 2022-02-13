using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public int damage;
    public float speed;
    float destroyDistance = 1f;

    private void Start()
    {
        speed = 10f;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 moveDirection = (target.position - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) < destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
