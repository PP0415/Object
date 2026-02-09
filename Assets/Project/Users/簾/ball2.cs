using UnityEngine;
using Cysharp.Threading.Tasks;

public class SlipDamageBall : BallDirector
{
    public int slipCount = 5;        // ダメージ回数
    public float slipInterval = 0.5f;

    public override void BallCollisionEfect(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Block"))
        {
            BlockHP block = collision2D.gameObject.GetComponent<BlockHP>();

            // 通常ダメージ
            block.TakeDamage(damage);

            // スリップ開始
            SlipDamage(block).Forget();
        }
    }

    async UniTask SlipDamage(BlockHP block)
    {
        float slipDamage = damage / 10f;

        for (int i = 0; i < slipCount; i++)
        {
            await UniTask.Delay((int)(slipInterval * 1000));
            if(block==null)
                break;
            block?.TakeDamage(slipDamage);
        }
    }
}
