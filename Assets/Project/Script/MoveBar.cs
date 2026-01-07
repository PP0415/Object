using UnityEngine;
using UnityEngine.InputSystem;
public class MoveBar : MonoBehaviour
{
    [SerializeField] private InputActionReference _aimAction;//操作用InputAction
    [SerializeField] private Rigidbody2D myRB2D;
    public float speed = 100.0f;
    void FixedUpdate()
    {
        myRB2D.linearVelocity = new Vector2(_aimAction.action.ReadValue<Vector2>().x * speed, 0f);
    }
}