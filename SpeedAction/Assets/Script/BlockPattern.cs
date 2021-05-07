using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPattern : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemsPrefab;

    void Start()
    {
        int itemsPattern = Random.Range(0, itemsPrefab.Count);
        GameObject block = Instantiate(itemsPrefab[itemsPattern], transform);        
    }
}
