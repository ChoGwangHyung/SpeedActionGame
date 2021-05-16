using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController gameController;
    public static GameController instance
    {
        get
        {
            if (gameController == null)
                gameController = FindObjectOfType<GameController>();
            return gameController;
        }
    }

    [SerializeField] private List<int> scores;
    public List<int> _scores { get { return scores; } }

    private int prevScore;
    public int _prevScore { get { return prevScore; } }

    private int prevRange;
    public int _prevRange { get { return prevRange; } }

    private int curCharacterKind = 0;
    public int _curCharcterKind { get { return curCharacterKind; } set { curCharacterKind = value; } }

    void Awake()
    {
        if (gameController == null)
            DontDestroyOnLoad(this.gameObject);

        for (int index = 0; index < 5; index++)
            scores[index] = 0;
    }

    public void UpdateScore(int score, int range)
    {
        prevScore = score;
        prevRange = range;

        for (int index = 0; index < 5; index++)
        {
            if (scores[index] < score)
            {
                scores[4] = score;
                break;
            }
        }

        scores.Sort(delegate(int a, int b) { if (a < b) return 1; else if (a > b) return -1; return 0; });
    }
}
