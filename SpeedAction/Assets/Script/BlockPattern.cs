using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPattern : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemsPrefab;

    [SerializeField] private GameObject obstacle = null;

    void Start()
    {
        int itemsPattern = Random.Range(0, itemsPrefab.Count);
        GameObject block = Instantiate(itemsPrefab[itemsPattern], transform);

        float randomVal = Random.Range(0.0f, 100.0f);
        if (randomVal <= ObstacleManager.instance._probability)
            obstacle.SetActive(true);
        else
            obstacle.SetActive(false);
    }
}
