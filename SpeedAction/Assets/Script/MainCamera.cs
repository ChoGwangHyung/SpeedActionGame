using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Vector3 dist;

    void Awake()
    {
        dist = transform.position - Player.instance.transform.position;
    }

    void Update()
    {
        transform.position =
            new Vector3(Player.instance.transform.position.x + dist.x, 1.0f, Player.instance.gameObject.transform.position.z + dist.z);
    }
}
