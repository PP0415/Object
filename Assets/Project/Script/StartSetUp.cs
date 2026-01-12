using UnityEngine;

public class StartSetUp : MonoBehaviour
{

    [SerializeField] private GameState gameState;
    void Start()
    {
        gameState.passTime = 0f;
        gameState.blockDeleteCount = 0;
    }
}
