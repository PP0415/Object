using UnityEngine;
using UnityEngine.Events;

public class GameState : ScriptableObject
{
    public float passTime;
    public int blockDeleteCount;
    public UnityEvent deleteBlockEvent;
}