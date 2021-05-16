using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private static ObstacleManager obstacleManager;
    public static ObstacleManager instance
    {
        get
        {
            if (obstacleManager == null)
                obstacleManager = FindObjectOfType<ObstacleManager>();
            return obstacleManager;
        }
    }

    [SerializeField] private GameObject moveObstaclePrefab = null;

    private float probability = 30.0f;    
    public float _probability { get { return probability; } set { probability = value; } }
    
    public void CreateObstacle(float xPos)
    {
        float randomVal = Random.Range(0.0f, 100.0f);
        if (randomVal > probability) return;

        GameObject obstacle = Instantiate(moveObstaclePrefab, transform);
        obstacle.GetComponent<MoveObstacle>().SetObstacle(xPos);
        obstacle.transform.position = new Vector3(xPos + 5.0f, Random.Range(0.5f, 2.0f), 0.0f);
    }
}
