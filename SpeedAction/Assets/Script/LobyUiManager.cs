using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobyUiManager : MonoBehaviour
{
    [SerializeField] private List<Text> rankText = new List<Text>(5);

    [SerializeField] private GameObject option = null;
    [SerializeField] private GameObject helpText = null;

    void Start()
    {
        for (int index = 0; index < 5; index++)
        {
            if (GameController.instance._scores[index] == 0)
                rankText[index].text = "-";
            else
                rankText[index].text = "" + GameController.instance._scores[index];
        }

        option.SetActive(false);
    }    

    public void GameStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OptionButton()
    {
        option.SetActive(true);
        option.GetComponent<Option>().Open();
    }

    public void OkButton()
    {
        helpText.SetActive(false);
    }

    public void BackButton()
    {
        option.SetActive(false);
    }

    public void HelpButton()
    {
        helpText.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
