using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float sizeToDestroy = 0.5f;
    public Transform [] targets;
    public int targetIndex = -1;
    private GameplayManager gameplayManager;
    private NavMeshAgent navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameplayManager =  GameObject.Find("Managers").GetComponent<GameplayManager>();
        gameplayManager.EnemySpawned();
        // get nearest target
        float minDistance = float.MaxValue;
        for (int i = 0; i < targets.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, targets[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetIndex = i;
            }
        }
        if (targetIndex != -1)
        {
            navMeshAgent.SetDestination(targets[targetIndex].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetIndex == -1)
        {
            return;
        }
        Transform target = targets[targetIndex];
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.position.x, 0, target.position.z)) < 0.1f)
        {
            targetIndex = (targetIndex + 1) % targets.Length;
            target = targets[targetIndex];
            navMeshAgent.SetDestination(target.position);
        }
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
            Debug.Log(other.gameObject.name + " has entered the trigger " + gameObject.name);
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
