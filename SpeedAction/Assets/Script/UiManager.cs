using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private static UiManager uiManager;
    public static UiManager instance
    {
        get
        {
            if (uiManager == null)
                uiManager = FindObjectOfType<UiManager>();
            return uiManager;
        }
    }

    [SerializeField] private Slider feverGage;

    private float feverValue = 0.0f;
    public float _feverValue { get { return feverValue; } }

    [SerializeField] private Text distance;
    [SerializeField] private Text curScore;
    [SerializeField] private Text bestScore;

    private float startPos;
    private float runDist;
    public float _runDist { get { return runDist; } }

    private float totalScore = 0;
    private float itemScore = 0;

    void Start()
    {
        bestScore.text = "0";
        startPos = Player.instance.transform.position.x;
    }

    void Update()
    {
        feverGage.value = feverValue;

        runDist = Player.instance.transform.position.x - startPos;
        distance.text = (int)runDist + "M";

        totalScore = runDist + itemScore;
        curScore.text = "" + (int)totalScore;
    }

    public void GetItem()
    {
        itemScore += 100;
        feverValue += 0.05f;

        if (feverValue == 1.0f)
        {
            feverValue = 0.0f;
        }
    }
}
