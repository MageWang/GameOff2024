using UnityEngine;

public class MC : MonoBehaviour
{
    float size = 0.4f;
    public float sizeIncrement = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        size = GetComponent<Transform>().localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grow()
    {
        size+=sizeIncrement;
        GetComponent<Transform>().localScale = new Vector3(size, size, 1);
    }
}
