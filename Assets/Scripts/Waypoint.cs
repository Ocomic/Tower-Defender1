using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceble;
    [SerializeField] GameObject towerPrefab;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if(isPlaceble)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceble = false;
        }
        
    }
}
