using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUi : MonoBehaviour
{
    [SerializeField] private Text title = null;

    [SerializeField] private Text range = null;
    [SerializeField] private Text score = null;

    void Start()
    {
        if (GameController.instance._rank <= 5)
        {
            title.text = GameController.instance._rank + "등을 축하드립니다!";
            title.fontSize = 100;
        }
        else
        {
            title.text = "Game Over";
            title.fontSize = 120;
        }

        range.text = "거리 : " + GameController.instance._prevRange;
        score.text = "점수 : " + GameController.instance._prevScore;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Lobby");
    }
}
