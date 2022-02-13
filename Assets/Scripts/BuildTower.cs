using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{ 
    public Transform towerPreviewPrefab;
    public Transform secondTowerPreviewPrefab;

    public void BuildTowerSelect()
    {
        Instantiate(towerPreviewPrefab);
    }
    public void BuildSecondsTowerSelect()
    {
        Instantiate(secondTowerPreviewPrefab);
    }
}
