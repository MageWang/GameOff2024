using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    int enemyCount = 0;
    enum GameState
    {
        Playing,
        Win,
        Lose
    }
    GameState gameState = GameState.Playing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("BadEnding0010");
    }
}
