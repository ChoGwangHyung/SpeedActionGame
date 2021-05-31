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
        if (Player.instance._curState == State.FEVER && Vector3.Distance(gameObject.transform.position, Player.instance.transform.position) <= 5.0f)
        {
            Vector3 dir = (Player.instance.transform.position - gameObject.transform.position).normalized;
            gameObject.transform.Translate(dir * moveSpeed* Time.fixedDeltaTime);
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
