using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float sizeToDestroy = 0.5f;
    private GameplayManager gameplayManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameplayManager =  GameObject.Find("Managers").GetComponent<GameplayManager>();
        gameplayManager.EnemySpawned();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // collision is called when the Collider2d other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the trigger 2d " + gameObject.name);
            if (other.gameObject.GetComponent<Transform>().localScale.x > sizeToDestroy)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                gameplayManager.Lose();
            }
        }
    }

    void OnDestroy()
    {
        Debug.Log("Enemy destroyed " + gameObject.name);
        gameplayManager.EnemyDestroyed();
    }
}
