using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = Player.instance._curSpeed + 1.5f;
    }

    private void FixedUpdate()
    {
        if (GameController.instance._gameStop) return;

        if (Player.instance._curState == State.FEVER && Vector3.Distance(gameObject.transform.position, Player.instance.transform.position) <= 7.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.instance.transform.position + new Vector3(0.0f,0.5f,0.0f), moveSpeed * 1.5f * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemCollect();
        }
    }

    private void ItemCollect()
    {
        AudioManager.instance.PlayItemCollectSound();
        UiManager.instance.GetItem();
        gameObject.SetActive(false);
    }
}
