using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public GameObject timer1;
    public GameObject timer2;

    private SliderTimer timer1Script;
    private SliderTimer timer2Script;

    void Start()
    {
        timer1Script = timer1.GetComponent<SliderTimer>();
        timer2Script = timer2.GetComponent<SliderTimer>();

        timer1.SetActive(true);
        timer2.SetActive(false);
    }

    void Update()
    {
        // A 타이머가 끝나면 B 타이머로 전환
        if (timer1.activeSelf && timer1Script.IsFinished())
        {
            timer1.SetActive(false);
            timer2.SetActive(true);
            timer2Script.StartTimer();
        }
    }
}
