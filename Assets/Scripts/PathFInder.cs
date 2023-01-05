using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInder : MonoBehaviour
{
    
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    NodeClass startNode;
    NodeClass destinationNode;
    NodeClass currentSearchNode;

    Queue<NodeClass> frontier = new Queue<NodeClass>();
    Dictionary<Vector2Int, NodeClass> reached = new Dictionary<Vector2Int, NodeClass>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, NodeClass> grid = new Dictionary<Vector2Int, NodeClass>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }

        startNode = new NodeClass(startCoordinates, true);
        destinationNode = new NodeClass(destinationCoordinates, true);


    }
    void Start()
    {
        BreadthFirstSearch();
    }

    private void ExploreNeighbors()
    {
        List<NodeClass> neighbors = new List<NodeClass>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;

            if(grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);

                
            }
        }

        foreach(NodeClass neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }

    }

    void BreadthFirstSearch()
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }

    }
}
