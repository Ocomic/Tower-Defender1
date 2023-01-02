using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceble;
    [SerializeField] Tower towerPrefab;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceble;
        }
    }
    

    void OnMouseDown()
    {
        if(isPlaceble)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);                     
            isPlaceble = !isPlaced;
        }
        
    }
}
