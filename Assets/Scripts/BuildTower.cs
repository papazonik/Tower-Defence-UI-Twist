using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    public Transform towerPrefab;
    public Transform towerPreviewPrefab;

    public void BuildTowerSelect()
    {
        Instantiate(towerPreviewPrefab, transform.position, transform.rotation);
    }
}
