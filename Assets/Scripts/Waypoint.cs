using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceble;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if(isPlaceble)
        {
            Debug.Log(transform.name);
        }
        
    }
}
