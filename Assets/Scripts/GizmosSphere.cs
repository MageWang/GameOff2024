using UnityEngine;

public class GizmosSphere : MonoBehaviour
{
    public Color color = Color.red;
    public SphereCollider sphereCollider;
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
        Gizmos.DrawWireSphere(transform.position, sphereCollider.radius * transform.localScale.x);
    }
}
