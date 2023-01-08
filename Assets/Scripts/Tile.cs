using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceble;
    [SerializeField] Tower towerPrefab;
    public bool IsPlaceable { get { return isPlaceble; } }

    GridManager gridManager;
    PathFinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
      gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<PathFinder>(); 
    }

    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if(!isPlaceble) 
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if(gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);                     
            isPlaceble = !isPlaced;
            gridManager.BlockNode(coordinates);
        }
        
    }
}
