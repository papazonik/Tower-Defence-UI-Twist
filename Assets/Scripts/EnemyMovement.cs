using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wayPointIndex = 0;
    SpriteRenderer enemySpriteRenderer;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        target = Waypoints.wayPoints[wayPointIndex];
        enemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = target.position - transform.position;
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
        FlipSprite(moveDirection.normalized);
        if (Vector2.Distance(transform.position, target.position) <= 0.2f) //If very close to waypoint, go to next one
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wayPointIndex >= Waypoints.wayPoints.Length - 1)
        {
            gameManager.LoseHeart();
            Destroy(gameObject);
            return;
        }
        wayPointIndex ++;
        target = Waypoints.wayPoints[wayPointIndex];
    }

    void FlipSprite(Vector2 direction)
    {
        if (direction.x < 0)
        {
            enemySpriteRenderer.flipX = true;
        }
        else
        {
            enemySpriteRenderer.flipX = false;
        }
    }
}
