using UnityEngine;
using Cysharp.Threading.Tasks;
class BallDirector : MonoBehaviour
{
    [SerializeField] private float speed = 200f;
    [SerializeField] private float minSpeed = 100f;
    [SerializeField] private float maxSpeed = 200f;
    [SerializeField] private float damage = 180;
    [SerializeField] private Rigidbody2D myRB2D;
    // Transformコンポーネントを保持しておくための変数を追加
    [SerializeField] private Transform myTF;
    [SerializeField] private GameObject ball;

    void Start()
    {
        myRB2D.linearVelocity = new Vector2(speed, speed);
        myTF = transform;
    }

    void Update()
    {
        myRB2D.linearVelocity = myRB2D.linearVelocity.normalized * Mathf.Clamp(myRB2D.linearVelocity.magnitude, minSpeed, maxSpeed); ;
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
            // 現在の速さを取得
            float speed = myRB2D.linearVelocity.magnitude;
            // 速度を変更
            myRB2D.linearVelocity = direction * speed;
        }

        // ブロックに当たったとき
        if (collision2D.gameObject.CompareTag("Block"))
        {
            collision2D.gameObject.GetComponent<BlockHP>().TakeDamage(damage);
        }
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
        ball.SetActive(false);
        await UniTask.Delay(5000);
        ball.transform.position = new Vector3(0, -300, 0);
        ball.SetActive(true);
        myRB2D.linearVelocity = new Vector2(speed, speed);
    }
}