using UnityEngine;

public class UILeaderboard1 : MonoBehaviour
{
    ScoreRecord scoreRecord;
    TMPro.TextMeshProUGUI [] texts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreRecord = ScoreRecord.instance;
        if (scoreRecord == null)
        {
            Debug.LogError("ScoreRecord.instance is null");
            return;
        }
        texts = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        for (int i = 0; i < scoreRecord.GetRecords().records.Length; i++)
        {
            texts[i].text = "" + (i+1).ToString() + ":" + scoreRecord.GetRecords().records[i].score.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
