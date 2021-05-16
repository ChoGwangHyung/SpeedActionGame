using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager levelManager;
    public static LevelManager instance
    {
        get
        {
            if (levelManager == null)
                levelManager = FindObjectOfType<LevelManager>();
            return levelManager;
        }
    }

    private int curLevel = 1;

    private float upSpeedFigure = 1.0f;
    public float _upSpeedFigure { get { return upSpeedFigure; } }
    private float upObstructionFigure = 1.0f;

    void FixedUpdate()
    {
        if (UiManager.instance._runDist >= 300 * curLevel)
        {
            upSpeedFigure += 0.2f;
            upObstructionFigure += 0.1f;

            Player.instance._curSpeed = Player.instance._defalutSpeed * upSpeedFigure;
            ObstacleManager.instance._probability *= upObstructionFigure;
            MapManager.instance.UpLevel();

            curLevel++;
        }
    }
}
