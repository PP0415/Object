using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class RedLIne : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject gameOverText;
    void Start()
    {
        gameState.gameOverEvent.AddListener(GameOver);
    }
    void GameOver()
    {
        Debug.Log("GameOver");
        GameOverWait().Forget();
    }

    async UniTask GameOverWait()
    {
        if (gameState.isGameOver == false) return;
        Time.timeScale = 0;
        gameOverText.SetActive(true);
        await UniTask.WaitUntil(() => Keyboard.current.rKey.wasPressedThisFrame);
        SceneManager.LoadScene("SampleScene");
    }
}