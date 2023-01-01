using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceble;
    [SerializeField] GameObject towerPrefab;
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
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceble = false;
        }
        
    }
}
