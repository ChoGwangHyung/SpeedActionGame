using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : Obstacle
{
    private float defalutSpeed = 2.0f;
    public float _defalutSpeed { get { return defalutSpeed; } }

    private float startPos;

    void FixedUpdate()
    {
        if (GameController.instance._gameStop) return;

        transform.Translate(transform.right * defalutSpeed * Time.deltaTime);
        if (startPos - 20.0f >= transform.position.x)
            Destroy(this.gameObject);
    }

    public void SetObstacle(float startXPos)
    {
        startPos = startXPos;
    }
}
