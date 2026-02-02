using UnityEngine;
public class sampleBall : BallDirector
{
    public override void BallCollisionEfect(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Block"))
        {
            collision2D.gameObject.GetComponent<BlockHP>().TakeDamage(damage);
        }
        else if (collision2D.gameObject.CompareTag("Bar"))
        {

        }
        else if (collision2D.gameObject.CompareTag("Wall"))
        {

        }
    }
}