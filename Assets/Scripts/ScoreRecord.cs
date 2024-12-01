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

    public class Records
    {
        public Record[] records = new Record[10];
    }

    private Records records = new Records();
    public Records GetRecords()
    {
        return records;
    }
    
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
        if (time < 0.0001) return;
        Debug.Log("Save record: " + time + " " + enemiesNum);
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
        for (int i = 0; i < records.records.Length; i++)
        {
            // Debug.Log("Record: " + JsonUtility.ToJson(records.records[i]));
            if (record.score > records.records[i].score)
            {
                Record temp = records.records[i];
                records.records[i] = record;
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
            try
            {
                records = JsonUtility.FromJson<Records>(json);
            }
            catch (System.Exception e)
            {
                Debug.Log("Error loading records: " + e.Message);
            }
            finally
            {
                if (records == null)
                {
                    records = new Records();
                }
            }
            for (int i = 0; i < records.records.Length; i++)
            {
                if (records.records[i] == null)
                {
                    records.records[i] = new Record();
                }
            }
        }
    }
}
