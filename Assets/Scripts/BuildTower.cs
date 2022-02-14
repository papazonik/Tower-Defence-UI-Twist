using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{ 
    public Transform towerPreviewPrefab;

    

    public void BuildTowerSelect()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Instantiate(towerPreviewPrefab, mousePos, Quaternion.identity);
    }
}
