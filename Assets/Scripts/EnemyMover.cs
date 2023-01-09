using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridmanager;
    PathFinder pathfinder;

    // Start is called before the first frame update

    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
        
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridmanager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<PathFinder>();
    }
   

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if(resetPath ) 
        {
            coordinates = pathfinder.StartCoordinates;
        }
        else
        {
            coordinates = gridmanager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());

    }

    void ReturnToStart()
    {
        transform.position = gridmanager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for(int i = 1; i< path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridmanager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercentage = 0f;

            transform.LookAt(endPosition);

            while(travelPercentage < 1)
            {
                travelPercentage += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
            
        }

        FinishPath();
        
    }
}
