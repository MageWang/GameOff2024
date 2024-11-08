using UnityEngine;

public class Ally : MonoBehaviour
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
        if (other.gameObject.tag == "Player")
        {
            //Destroy(other.gameObject);
            Debug.Log("Player has entered the trigger");
            other.gameObject.GetComponent<MC>().Grow();
            Destroy(gameObject);
        }
    }
}
