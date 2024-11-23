using UnityEngine;

public class DoorWithSizeLimit : MonoBehaviour
{
    public float limitSizeMin = 1;
    public float limitSizeMax = 1.1f;

    MC mC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mC = GameObject.FindGameObjectWithTag("Player").GetComponent<MC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mC.transform.localScale.x >= limitSizeMin && mC.transform.localScale.x <= limitSizeMax)
        {
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
            
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
