using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State { DEFAULT, FEVER }
public enum Kind { DEFAULT, FEVERFAST, SCOREUP, SPEEDFAST }
public class Player : MonoBehaviour
{
    private static Player player;
    public static Player instance
    {
        get
        {
            if (player == null)
                player = FindObjectOfType<Player>();
            return player;
        }
    }

    private State curState = State.DEFAULT;
    public State _curState { get { return curState; } set { curState = value; } }

    private Kind kind = Kind.DEFAULT;
    public Kind _kind { get { return kind; } }

    [SerializeField] private AudioClip hittedClip= null;
    [SerializeField] private AudioClip jumpClip = null;
    [SerializeField] private AudioClip itemCollectClip = null;
    [SerializeField] private AudioClip feverClip = null;

    private Rigidbody rb;
    private AudioSource audioSource;

    private int lifeCount = 2;
    public int _lifeCount { get { return lifeCount; } }

    private float curSpeed;
    public float _curSpeed { get { return curSpeed; } set { curSpeed = value; } }
    private float defalutSpeed = 4.0f;
    public float _defalutSpeed { get { return defalutSpeed; } }

    private float jumpPower = 5.0f;
    private int jumpCount = 2;

    private float feverTime = 5.0f;

    void Start()
    {
        kind = (Kind)GameController.instance._curCharcterKind;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        if (kind == Kind.SPEEDFAST)
            defalutSpeed *= 1.5f;
        curSpeed = defalutSpeed;
    }

    void FixedUpdate()
    {
        if (transform.position.y <= -3.0f)
            PlayerDie();
        rb.MovePosition(transform.position + transform.forward * curSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.LeftShift) && UiManager.instance._feverValue >= 1.0f && curState == State.DEFAULT)
        {
            StartFever();
        }

        if (jumpCount > 1 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.up * jumpPower;
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(jumpClip);
            jumpCount--;
        }

        if (Physics.Raycast(transform.position, Vector3.down, 0.55f))
        {
            jumpCount = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            audioSource.volume = 0.3f;
            audioSource.PlayOneShot(itemCollectClip);
            UiManager.instance.GetItem();
        }
    }

    private void PlayerDie()
    {
        GameController.instance.UpdateScore((int)UiManager.instance._totalScore, (int)UiManager.instance._runDist);
        SceneManager.LoadScene("Result");
    }

    public void GetDamage()
    {
        if (curState == State.FEVER) return;

        audioSource.volume = 1.0f;
        audioSource.PlayOneShot(hittedClip);

        lifeCount--;
        if (lifeCount <= 0)
            PlayerDie();
    }

    private void StartFever()
    {
        curState = State.FEVER;
        StartCoroutine(FeverCouroutine());
        StartCoroutine(UiManager.instance.FeverUiCoroutine());
    }

    private IEnumerator FeverCouroutine()
    {
        audioSource.volume = 1.0f;
        audioSource.PlayOneShot(feverClip);
        curSpeed = defalutSpeed * LevelManager.instance._upSpeedFigure * 1.5f;

        yield return new WaitForSecondsRealtime(feverTime);

        curSpeed = defalutSpeed * LevelManager.instance._upSpeedFigure;
        curState = State.DEFAULT;
        UiManager.instance.FeverEnd();
    }
}
