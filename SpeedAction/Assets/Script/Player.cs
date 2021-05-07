using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State { DEFAULT, FEVER }
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

    private Rigidbody rb;

    private float curSpeed;
    public float _curSpeed { get { return curSpeed; } set { curSpeed = value; } }
    private float defalutSpeed = 4.0f;
    public float _defalutSpeed { get { return defalutSpeed; } }


    private float jumpPower = 4.0f;
    private int jumpCount = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curSpeed = defalutSpeed;
    }

    void Update()
    {
        if (transform.position.y <= -3.0f)
            SceneManager.LoadScene(0);
        rb.MovePosition(transform.position + transform.forward * curSpeed * Time.deltaTime);

        if (jumpCount > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.up * jumpPower;
            jumpCount--;
        }

        if (Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            jumpCount = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            UiManager.instance.GetItem();
        }
    }
}
