using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobyUiManager : MonoBehaviour
{
    [SerializeField] private List<Text> rankText = new List<Text>(5);

    void Start()
    {
        for (int index = 0; index < 5; index++)
        {
            if (GameController.instance._scores[index] == 0)
                rankText[index].text = "-";
            else
                rankText[index].text = "" + GameController.instance._scores[index];
        }
    }

    public void GameStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
