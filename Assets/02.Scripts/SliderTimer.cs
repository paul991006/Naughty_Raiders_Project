using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public Slider slider;
    public float sliderBarTime = 300f;
    public Text timeText;

    private float currentTime;
    private bool isRunning = false;
    private bool isFinished = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (!isRunning || isFinished) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            isFinished = true;
            isRunning = false;
        }

        slider.value = currentTime;
        UpdateTimeText(currentTime);
    }

    public void StartTimer()
    {
        InitTimer();
        isRunning = true;
    }

    void InitTimer()
    {
        currentTime = sliderBarTime;
        slider.maxValue = sliderBarTime;
        slider.value = currentTime;
        isFinished = false;
        UpdateTimeText(currentTime);
    }

    public bool IsFinished()
    {
        return isFinished;
    }

    void UpdateTimeText(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        string formattedTime;
        if (time >= 60)
        {
            formattedTime = string.Format("{0}:{1:00}", minutes, seconds);
        }
        else
        {
            formattedTime = string.Format("{0}", seconds);
        }

        timeText.text = formattedTime;
    }
}