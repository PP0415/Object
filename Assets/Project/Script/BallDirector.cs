using UnityEngine;
using Cysharp.Threading.Tasks;
public class BallDirector : MonoBehaviour
{
    public float speed = 200f;
    public float damage = 180;
    public float preTime = 0f;
    public Rigidbody2D myRB2D;
    // Transformコンポーネントを保持しておくための変数を追加
    public Transform myTF;
    public GameObject ball;
    public GameState gameState;

    void Start()
    {
        myRB2D.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1) * speed;
    }

    void Update()
    {
        myRB2D.linearVelocity = myRB2D.linearVelocity.normalized * speed;
    }

    // 衝突したときに呼ばれる
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        // プレイヤーに当たったときに、跳ね返る方向を変える 
        if (collision2D.gameObject.CompareTag("Bar"))
        {
            // プレイヤーの位置を取得
            Vector3 playerPos = collision2D.transform.position;
            // ボールの位置を取得
            Vector3 ballPos = myTF.position;
            // プレイヤーから見たボールの方向を計算
            Vector3 direction = (ballPos - playerPos).normalized;
            // 速度を変更
            myRB2D.linearVelocity = direction * speed;
        }
        BallCollisionEfect(collision2D);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BallArea"))
        {
            RemoveBall().Forget();
        }
    }

    async UniTask RemoveBall()
    {
        BallRemoveEfect();
        ball.SetActive(false);
        if (await UniTask.Delay((int)(gameState.passTime * preTime), cancellationToken: this.GetCancellationTokenOnDestroy()).SuppressCancellationThrow())
        { return; }
        ball.transform.position = new Vector3(0, -300, 0);
        ball.SetActive(true);
        myRB2D.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1) * speed;
    }
    // 衝突したときに呼ばれる
    public virtual void BallCollisionEfect(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Block"))
        {
            collision2D.gameObject.GetComponent<BlockHP>().TakeDamage(damage);
        }
    }

    public virtual void BallRemoveEfect()
    {

    }
}