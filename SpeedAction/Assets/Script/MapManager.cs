using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> blockPrefab;

    private Queue<GameObject> instantiatedBlocks = new Queue<GameObject>();

    private float blockCreateDist = 10.0f;
    private float blockCreatePos;

    void Start()
    {
        blockCreatePos = Player.instance.transform.position.x + blockCreateDist;
        BlockInstantiate();
    }

    void Update()
    {
        if (Player.instance.transform.position.x >= blockCreatePos)
        {
            blockCreatePos = Player.instance.transform.position.x + blockCreateDist;
            BlockInstantiate();
        }
    }

    private void BlockInstantiate()
    {
        int blockPattern = Random.Range(0, blockPrefab.Count);

        GameObject block = Instantiate(blockPrefab[blockPattern], transform);
        block.transform.position = new Vector3(blockCreatePos, -0.5f, 0.0f);

        instantiatedBlocks.Enqueue(block);
        if (instantiatedBlocks.Count >= 3)
            Destroy(instantiatedBlocks.Dequeue());
    }
}
