using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float sizeToDestroy = 0.5f;
    public Transform target;
    private GameplayManager gameplayManager;
    private NavMeshAgent navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameplayManager =  GameObject.Find("Managers").GetComponent<GameplayManager>();
        gameplayManager.EnemySpawned();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the trigger " + gameObject.name);
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
