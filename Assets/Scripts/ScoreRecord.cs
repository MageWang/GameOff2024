using UnityEngine;

public class ScoreRecord : MonoBehaviour
{
    [System.Serializable]
    public class Record
    {
        public int score = 0;
        public float time = 999999;
        public bool win = false;
    }

    public Record[] records = new Record[10];
    static public ScoreRecord instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Object.FindObjectsByType<ScoreRecord>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        Load();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(float time, int enemiesNum)
    {
        Record record = new Record();
        record.time = time;
        record.win = enemiesNum == 0;
        if (record.win)
        {
            record.score = 1000 + (int)(100000 / time);
        }
        else
        {
            record.score = 1000/enemiesNum;
        }

        // sort
        for (int i = 0; i < records.Length; i++)
        {
            if (record.score > records[i].score)
            {
                Record temp = records[i];
                records[i] = record;
                record = temp;
            }
        }

        // save records to file
        PlayerPrefs.SetString("records", JsonUtility.ToJson(records));
    }

    void Load()
    {
        string json = PlayerPrefs.GetString("records");
        if (json != "")
        {
            records = JsonUtility.FromJson<Record[]>(json);
        }
    }
}
