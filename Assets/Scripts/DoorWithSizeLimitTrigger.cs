using UnityEngine;

public class DoorWithSizeLimitTrigger : MonoBehaviour
{
    public float limitSizeMin = 1;
    public float limitSizeMax = 1.1f;
    public SpriteRenderer spriteRenderer;
    public Color colorPass;
    public Color colorCantPass;
    private Color colorDefault;
    public Collider targetCollider;
    private bool passed = false;
    public GameObject [] hideObjects;

    MC mC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mC = GameObject.FindGameObjectWithTag("Player").GetComponent<MC>();
        colorDefault = spriteRenderer.color;
        foreach (GameObject hideObject in hideObjects)
        {
            hideObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (mC.transform.localScale.x >= limitSizeMin && mC.transform.localScale.x <= limitSizeMax)
            {
                Debug.Log("can pass " + other.gameObject.name);
                targetCollider.enabled = false;
                spriteRenderer.color = colorPass;
                spriteRenderer.gameObject.SetActive(false);
                foreach (GameObject hideObject in hideObjects)
                {
                    hideObject.SetActive(true);
                }
                passed = true;
            }
            else if (!passed)
            {
                Debug.Log("can't pass " + other.gameObject.name);
                targetCollider.enabled = true;
                spriteRenderer.color = colorCantPass;
            }
        }
    }
}
