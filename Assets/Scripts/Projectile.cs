using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;
    public int damage = 50;
    public float speed;
    float destroyDistance = 1f;
    public AudioClip hitTarget;

    private void Start()
    {
        speed = 10f;
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;       
    }

    public void HitTarget()
    {
        SoundManager.Instance.PlaySound(hitTarget);
        var healthScript = target.GetComponent<Health>();
        healthScript.TakeDamage(damage);
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 moveDirection = (target.transform.position - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.transform.position) < destroyDistance)
        {
            HitTarget();
            Destroy(gameObject);
            return;
        }
    }
}
