using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Blocks
{
    [SerializeField] private List<GameObject> prefabs;
    public List<GameObject> _prefabs { get { return prefabs; } }
}

public class MapManager : MonoBehaviour
{
    private static MapManager mapManager;
    public static MapManager instance
    {
        get
        {
            if (mapManager == null)
                mapManager = FindObjectOfType<MapManager>();
            return mapManager;
        }
    }

    [SerializeField] private List<Blocks> blockPrefab;

    private Queue<GameObject> instantiatedBlocks = new Queue<GameObject>();

    private int curLevel = 0;
    private int maxLevel = 0;

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
            blockCreatePos += blockCreateDist;
            BlockInstantiate();
        }
    }

    private void BlockInstantiate()
    {
        int randomLevel = Random.Range(curLevel, maxLevel + 1);
        int blockPattern = Random.Range(0, blockPrefab[randomLevel]._prefabs.Count);

        print(randomLevel + "   " + blockPattern);

        GameObject block = Instantiate(blockPrefab[randomLevel]._prefabs[blockPattern], transform);
        block.transform.position = new Vector3(blockCreatePos, -0.5f, 0.0f);

        instantiatedBlocks.Enqueue(block);
        if (instantiatedBlocks.Count >= 4)
            Destroy(instantiatedBlocks.Dequeue());

        ObstacleManager.instance.CreateObstacle(blockCreatePos);
    }

    public void UpLevel()
    {
        if (curLevel == maxLevel)
            maxLevel++;
        else
            curLevel++;
    }
}
