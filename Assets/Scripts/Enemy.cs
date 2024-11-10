using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System;

public class Enemy : MonoBehaviour
{
    public float sizeToEscape = 0.5f;
    public Transform [] targets;
    public int targetIndex = -1;
    private GameplayManager gameplayManager;
    private NavMeshAgent navMeshAgent;
    public Vector3 faceAt;
    private MC mc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum EnemyState
    {
        ESCAPE,
        PATROL,
        CHASE,
    }

    public EnemyState State  = EnemyState.PATROL;
    public float escapeCountdown = 3.0f;

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
        mc = GameObject.Find("MC").GetComponent<MC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (State == EnemyState.PATROL)
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
        if (State == EnemyState.CHASE)
        {
            navMeshAgent.SetDestination(mc.transform.position);
        }
        if (State == EnemyState.ESCAPE)
        {
            // escape from player
            navMeshAgent.SetDestination(transform.position + (transform.position - mc.transform.position).normalized * 10);
            escapeCountdown -= Time.deltaTime;
            if (escapeCountdown < 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
        if (navMeshAgent.velocity.magnitude > 0.01f)
        {
            faceAt = navMeshAgent.velocity.normalized;
        }
    }

    // collision is called when the Collider2d other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the trigger 2d " + gameObject.name);
            if (other.gameObject.GetComponent<Transform>().localScale.x > sizeToEscape)
            {
                //GameObject.Destroy(gameObject);
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
            if (other.gameObject.GetComponent<Transform>().localScale.x > sizeToEscape)
            {
                //GameObject.Destroy(gameObject);
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
