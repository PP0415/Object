using UnityEngine;
public class BlockHP : MonoBehaviour
{
    public float curenntHP, maxHP;
    [SerializeField] private GameState gameState;
    void Start()
    {
        maxHP = 100 + gameState.passTime * 3;
        curenntHP = maxHP;
    }
    public void TakeDamage(float damage)
    {
        curenntHP -= damage;
        if (curenntHP <= 0)
        {
            gameState.blockDeleteCount++;
            if (gameState.blockDeleteCount % 8 == 0) gameState.deleteBlockEvent.Invoke();
            Destroy(gameObject);
        }
    }
}