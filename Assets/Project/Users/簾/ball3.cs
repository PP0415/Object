using UnityEngine;

public class NetBuffBall : BallDirector
{
    public void ApplyNetBuff()
    {
        speed *= 1.2f;
        damage *= 1.2f;
    }
}


public class PowerNet : MonoBehaviour
{
    public int maxUseCount = 3;
    int currentCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            NetBuffBall ball = other.GetComponent<NetBuffBall>();
            if (ball != null)
            {
                ball.ApplyNetBuff();
                currentCount++;

                if (currentCount >= maxUseCount)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
