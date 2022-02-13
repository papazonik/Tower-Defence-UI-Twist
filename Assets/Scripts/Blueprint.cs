using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    public GameObject towerPrefab;

    private void Start()
    {

    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        var speed = 150;
        transform.position = Vector3.Lerp(transform.position, mousePos , speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            Instantiate(towerPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
