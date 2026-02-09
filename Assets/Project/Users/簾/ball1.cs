using UnityEngine;

public class PowerUpWallBall : BallDirector
{
    public float powerRate = 1.1f;
    public float maxRate = 1.3f;

    public float baseSpeed=200;
    public float baseDamage=180;
    public float currentRate = 1f;


    public override void BallCollisionEfect(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Wall"))
        {
            // 倍率を更新（上限つき）
            currentRate = Mathf.Min(currentRate * powerRate, maxRate);
            Debug.Log(Mathf.Min(currentRate * powerRate, maxRate));
            speed  = baseSpeed  * currentRate;
            damage = baseDamage * currentRate;
            Debug.Log(speed);
            Debug.Log(damage);
            // 速度反映
            myRB2D.linearVelocity = myRB2D.linearVelocity.normalized * speed;
        }
        else if (collision2D.gameObject.CompareTag("Block"))
        {
            collision2D.gameObject
                .GetComponent<BlockHP>()
                .TakeDamage(damage);
        }
    }
}
