using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] TMP_Text timeText;
    void Start()
    {
        gameState.passTime = 0f;
    }
    void Update()
    {
        gameState.passTime += Time.deltaTime;
        timeText.text = gameState.passTime.ToString("0.00");
    }
}