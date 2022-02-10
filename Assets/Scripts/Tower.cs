using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    public int cost;
    public float range;
    private Vector3 firePointVector3;
    public GameObject projectilePrefab;


    private void Awake()
    {
        firePointVector3 = firePoint.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Shoot(Vector3 firePointPos)
    {
        Instantiate(projectilePrefab, firePointPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("BuildTower");
            Shoot(firePointVector3);
        }
    }
}
