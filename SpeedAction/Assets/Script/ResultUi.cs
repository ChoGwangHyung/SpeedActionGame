using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUi : MonoBehaviour
{
    [SerializeField] private Text range = null;
    [SerializeField] private Text score = null;

    void Start()
    {
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
