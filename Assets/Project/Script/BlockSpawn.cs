using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameObject blockPrefab;
    private float preTime = 0;
    void Update()
    {
        if (gameState.passTime > preTime + 6f)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(blockPrefab, new Vector3(-180f + 120f * i, 400f, 0), Quaternion.identity);
            }
            preTime = gameState.passTime;
        }
    }
}