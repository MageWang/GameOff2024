using UnityEngine;

public class Detecter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // draw gizmos in the scene view
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // rotate to match game object rotation
        Gizmos.matrix = transform.localToWorldMatrix;
        // draw triangle in xz plane from game object position
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(1, 0, 0));
        Gizmos.DrawLine(new Vector3(1, 0, 0), new Vector3(0.5f, 0, 1));
        Gizmos.DrawLine(new Vector3(0.5f, 0, 1), new Vector3(0, 0, 0));
        
    }
}
