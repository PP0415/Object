using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] Transform TF;
    void Update()
    {
        TF.Translate(0, -5f * Time.deltaTime, 0);
    }
}