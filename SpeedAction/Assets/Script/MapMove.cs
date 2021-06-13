using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(transform.right * Player.instance._curSpeed * Time.deltaTime);
    }
}
