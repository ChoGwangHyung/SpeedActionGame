using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayAndNight : MonoBehaviour
{
    private float xRot = 50.0f;

    void FixedUpdate()
    {
        xRot += Time.fixedDeltaTime * 10.0f;
        gameObject.transform.rotation = Quaternion.Euler(xRot, -30.0f, 0.0f);
    }
}
