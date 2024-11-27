using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public int enemyCount = 0;
    enum GameState
    {
        Playing,
        Win,
        Lose
    }
    GameState gameState = GameState.Playing;
    float startTime = 0;
    float timeElapsed
    {
        get
        {
            return Time.time - startTime;
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawned()
    {
        enemyCount++;
    }

    public void EnemyDestroyed()
    {
        enemyCount--;
        Debug.Log("Enemy destroyed. Remaining enemies: " + enemyCount);
        if (enemyCount <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        if (gameState != GameState.Playing)
        {
            return;
        }
        
        gameState = GameState.Win;
        Debug.Log("You win!");
        // goto happy end. unity loads the scene with the name "GoodEnding0010"
        ScoreRecord.instance.Save(timeElapsed, enemyCount);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GoodEnding0010");
    }

    public void Lose()
    {
        if (gameState != GameState.Playing)
        {
            return;
        }
        
        gameState = GameState.Lose;
        Debug.Log("You lose!");
        ScoreRecord.instance.Save(timeElapsed, enemyCount);
        UnityEngine.SceneManagement.SceneManager.LoadScene("BadEnding0010");
    }
}
