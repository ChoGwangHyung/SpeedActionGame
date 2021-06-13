using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] private Image feverGageFull;
    [SerializeField] private Image fevering;

    [SerializeField] private Text distance;
    [SerializeField] private Text curScore;
    [SerializeField] private Text bestScore;

    private float startPos;
    private float runDist;
    public float _runDist { get { return runDist; } }

    private float totalScore = 0;
    public float _totalScore { get { return totalScore; } }
    private float itemScore = 0;

    [SerializeField] private Text feverText = null;
    [SerializeField] private Image feverTextBackground = null;

    [SerializeField] private List<Image> hpImages;

    [SerializeField] private GameObject option = null;

    void Start()
    {
        //Life 이미지 초기화
        foreach (var hpImage in hpImages)
            hpImage.gameObject.SetActive(false);
        //Life 개수 만큼 보여주기
        for (int lifeCount = 0; lifeCount < Player.instance._lifeCount; lifeCount++)
            hpImages[lifeCount].gameObject.SetActive(true);

        bestScore.text = "" + GameController.instance._scores[0];
        startPos = Player.instance.transform.position.x;

        feverText.gameObject.SetActive(false);
        feverTextBackground.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            option.gameObject.SetActive(true);
            option.GetComponent<Option>().Open();
            GameController.instance.GameStop();
        }

        feverGage.value = feverValue;

        runDist = (Player.instance.transform.position.x - startPos) * 2.0f;
        distance.text = (int)runDist + "M";

        if (Player.instance._kind == Kind.SCOREUP)
            totalScore = runDist * 1.5f + itemScore;
        else
            totalScore = runDist + itemScore;
        curScore.text = "" + (int)totalScore;
    }

    public void GetItem()
    {
        if (Player.instance._curState == State.FEVER) return;

        if (Player.instance._kind == Kind.SCOREUP)
            itemScore += (100 * 1.5f);
        else
            itemScore += 100;

        if (Player.instance._kind == Kind.FEVERFAST)
            feverValue += (0.01f * 1.5f);
        else
            feverValue += 0.01f;

        if (feverValue >= 1.0f) feverGageFull.gameObject.SetActive(true);
    }

    public void FeverEnd()
    {
        feverValue = 0.0f;
        fevering.gameObject.SetActive(false);
    }

    public IEnumerator FeverUiCoroutine()
    {
        feverGageFull.gameObject.SetActive(false);
        fevering.gameObject.SetActive(true);

        feverText.gameObject.SetActive(true);
        feverTextBackground.gameObject.SetActive(true);

        Color textColor = feverText.color;
        Color imageColor = feverTextBackground.color;

        textColor.a = 1.0f;
        imageColor.a = 0.5f;

        while (textColor.a > 0.0f)
        {
            textColor.a -= 0.002f;
            imageColor.a -= 0.002f * 0.5f;

            feverText.color = textColor;
            feverTextBackground.color = imageColor;

            yield return null;
        }

        feverText.gameObject.SetActive(false);
        feverTextBackground.gameObject.SetActive(false);
        yield return null;
    }

    public void GetDamage(int life)
    {
        hpImages[life].gameObject.SetActive(false);
    }

    public void ResumeButton()
    {
        option.gameObject.SetActive(false);
        GameController.instance.GameStart();
    }

    public void RestartButton()
    {
        ResumeButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
