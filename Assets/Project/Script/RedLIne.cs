using UnityEngine;

public class RedLIne : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Block")
        {
            Debug.Log("Game Over");
        }
    }
}