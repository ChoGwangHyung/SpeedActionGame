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

    private float upSpeedFigure = 1.0f;
    private float upObstructionFigure = 1.0f;
    private float upLandableSectionFigure = 1.0f;

    void Update()
    {
        if ((int)(UiManager.instance._runDist % 500) == 0)
        {
            Player.instance._curSpeed = Player.instance._defalutSpeed * upSpeedFigure;


            upSpeedFigure += 0.2f;
            upObstructionFigure += 0.1f;
            upLandableSectionFigure -= 0.1f;
        }
    }
}
