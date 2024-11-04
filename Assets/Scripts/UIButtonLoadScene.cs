using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonLoadScene : MonoBehaviour
{
    public string sceneName = "GoodEnding0010";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        SceneManager.LoadScene(sceneName);
    }
}
