using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 targetPosition;
    public int damage;
    public float speed;
    float destroyDistance = 1f;

    private void Start()
    {
        speed = 2f;
        targetPosition = new Vector3(20, 20, 0);
    }

    private void Update()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPosition) < destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
