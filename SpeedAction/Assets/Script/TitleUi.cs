using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUi : MonoBehaviour
{
    [SerializeField] private GameObject explain = null;

    public void GameStartButton()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void HelpButton()
    {
        explain.SetActive(true);
    }

    public void BackButton()
    {
        explain.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
