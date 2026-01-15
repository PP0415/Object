using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] Transform TF;
    [SerializeField] GameState gameState;
    void Update()
    {
        TF.Translate(0, -20f * Time.deltaTime, 0);
        if (TF.position.y < -285f && !gameState.isGameOver)
        {
            gameState.isGameOver = true;
            gameState.gameOverEvent.Invoke();
        }
    }
}