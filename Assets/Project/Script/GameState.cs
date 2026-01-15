using UnityEngine;
using UnityEngine.Events;

public class GameState : ScriptableObject
{
    public float passTime;
    public int blockDeleteCount;
    public bool isGameOver;
    public UnityEvent deleteBlockEvent, gameOverEvent;

    public void GameStateReset()
    {
        passTime = 0f;
        blockDeleteCount = 0;
        isGameOver = false;
    }
}