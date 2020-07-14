using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10;

    // Update is called once per frame
    void Update()
    {
        // Caso seja (Time.timeSinceLevelload== level time), o resultado é 1 (100%)
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            Debug.Log("Level timer expired");
        }
    }
}
