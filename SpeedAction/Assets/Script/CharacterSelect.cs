using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private List<Image> selects = new List<Image>(4);
    [SerializeField] private List<Button> buttons = new List<Button>(4);
    [SerializeField] private List<Image> locks = new List<Image>(3);

    [SerializeField] private Image curSelect = null;

    void Start()
    {
        for (int index = 0; index < 4; index++)
            buttons[index].interactable = false;

        if (GameController.instance._scores[0] >= 10000)
        {
            locks[0].gameObject.SetActive(false);
            buttons[1].interactable = true;
        }
        if (GameController.instance._scores[0] >= 20000)
        {
            locks[1].gameObject.SetActive(false);
            buttons[2].interactable = true;
        }
        if (GameController.instance._scores[0] >= 30000)
        {
            locks[2].gameObject.SetActive(false);
            buttons[3].interactable = true;
        }

        if (GameController.instance._curCharcterKind != (int)Kind.DEFAULT)
        {
            buttons[GameController.instance._curCharcterKind].interactable = false;
            buttons[0].interactable = true;
        }

        curSelect.transform.position = selects[GameController.instance._curCharcterKind].transform.position;
    }

    public void SelectCharacter(int val)
    {
        buttons[GameController.instance._curCharcterKind].interactable = true;

        GameController.instance._curCharcterKind = val;
        curSelect.transform.position = selects[GameController.instance._curCharcterKind].transform.position;
        buttons[GameController.instance._curCharcterKind].interactable = false;
    }
}
