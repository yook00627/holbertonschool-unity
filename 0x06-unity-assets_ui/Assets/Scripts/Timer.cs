using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text finalTime;
    public GameObject winCanvas;

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
            Time.timeScale = 0;

            timerText.text = "";
            /*
            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", timer / 60, timer % 60, timer * 100 % 100);
            timerText.fontSize = 36;
            timerText.color = Color.green;
            */
            winCanvas.SetActive(true);
            Win();
        }
    }

    public void Win()
    {
        finalTime.text = string.Format("{0:0}:{1:00}.{2:00}", timer / 60, timer % 60, timer * 100 % 100);
    }
}
