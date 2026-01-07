using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameObject blockPrefab;
    void Start()
    {
        gameState.passTime = 0f;
    }
    void Update()
    {
        gameState.passTime += Time.deltaTime;
    }
}