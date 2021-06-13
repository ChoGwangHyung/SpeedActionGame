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

    private int rank;
    public int _rank { get { return rank; } }

    private int curCharacterKind = 0;
    public int _curCharcterKind { get { return curCharacterKind; } set { curCharacterKind = value; } }

    private float audioBGMVolume = 0.5f;
    public float _audioBGMVolume { get { return audioBGMVolume; } }

    private float audioEffectVolume = 0.5f;
    public float _audioEffectVolume { get { return audioEffectVolume; } }

    private bool gameStop = false;
    public bool _gameStop { get { return gameStop; } }

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
                rank = index + 1;
                scores[4] = score;
                break;
            }
        }

        //등수에 들지 못하였을 때
        if (scores[4] != score) rank = 6;

        scores.Sort(delegate (int a, int b) { if (a < b) return 1; else if (a > b) return -1; return 0; });
    }

    public void SetBGMVolume(float value)
    {
        audioBGMVolume = value;
    }

    public void SetEffectVolume(float value)
    {
        audioEffectVolume = value;
    }

    public void GameStart()
    {
        gameStop = false;
        Player.instance.PlayerStart();
    }

    public void GameStop()
    {
        gameStop = true;
        Player.instance.PlayerStop();
    }
}
