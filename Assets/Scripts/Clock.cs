using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // min:sec:ms
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", Time.time / 60, Time.time % 60, Time.time * 100 % 100);
    }
}
