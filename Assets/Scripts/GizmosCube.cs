using UnityEngine;

public class GizmosCube : MonoBehaviour
{
    public Color color = Color.red;
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
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
