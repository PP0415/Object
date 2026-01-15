using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] TMP_Text timeText;
    void Start()
    {
        Time.timeScale = 1;
        gameState.GameStateReset();
    }
    void Update()
    {
        gameState.passTime += Time.deltaTime;
        timeText.text = gameState.passTime.ToString("0.00");
    }
}