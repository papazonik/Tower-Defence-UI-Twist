using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    public int cost;
    private Vector3 firePointVector3;


    private void Awake()
    {
        firePointVector3 = firePoint.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("BuildTower");
        }
    }
}
