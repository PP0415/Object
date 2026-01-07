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
            Destroy(gameObject);
        }
    }
}