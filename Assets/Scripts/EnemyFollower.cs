using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    public Transform target;
    public Vector3 relativePosition;
    public Vector3 relativeRotation;
    private Enemy enemy;
    private MC mc;
    void Start()
    {
        // get relative position and rotation
        relativePosition = transform.position - target.position;
        enemy = target.GetComponent<Enemy>();
        mc = GameObject.Find("MC").GetComponent<MC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform == null || target == null || enemy == null)
        {
            return;
        }
        transform.position = target.position + enemy.faceAt * relativePosition.magnitude;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name + " has entered the trigger " + gameObject.name);
            if (mc.transform.localScale.x > enemy.sizeToEscape)
            {
                print("Player is bigger than enemy");
                // change state to escape
                enemy.State = Enemy.EnemyState.ESCAPE;
            }
            else
            {
                print("Player is smaller than enemy");
                // change state to chase
                enemy.State = Enemy.EnemyState.CHASE;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemy.State == Enemy.EnemyState.CHASE)
            {
                // change state to patrol
                enemy.State = Enemy.EnemyState.PATROL;
            }
        }
    }
}
