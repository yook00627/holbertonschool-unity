using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    private float timer = 0.0f;
    private bool stop = false;

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            timer += Time.deltaTime;

            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", timer / 60, timer % 60, timer * 100 % 100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WinFlag")
        {
            stop = true;

            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", timer / 60, timer % 60, timer * 100 % 100);
            timerText.fontSize = 36;
            timerText.color = Color.green;
        }
    }
}
