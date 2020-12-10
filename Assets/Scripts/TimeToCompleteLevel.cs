using UnityEngine;
using UnityEngine.UI;

public class TimeToCompleteLevel : MonoBehaviour
{

    public Text timeText;

    private float time;

    private void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //timeText.text = "Time: " + DisplayTime(UnityEngine.Time.time);
        timeText.text = "Time: " + DisplayTime(time);
    }

    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
