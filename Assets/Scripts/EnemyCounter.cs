using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCounterText;
    public GameplayManager gameplayManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameplayManager = GameObject.FindFirstObjectByType<GameplayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCounterText.text = "Enemies: " + gameplayManager.enemyCount;

    }
}
