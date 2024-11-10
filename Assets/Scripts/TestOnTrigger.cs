using UnityEngine;

public class TestOnTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // collision is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " OnTriggerEnter " + other.gameObject.name);
        // stop other trigger events
    }
}
