using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text scoreText;

    private int remainingBlocks;
    private int score = 0;
    private bool isGameEnded = false;

    private void Start()
    {
        resultText.text = "";
        Time.timeScale = 1f;
        UpdateScoreText();
    }

    private void Update()
    {
        if (isGameEnded && Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void SetBlockCount(int count)
    {
        remainingBlocks = count;
    }

    public void BlockDestroyed()
    {
        if (isGameEnded)
            return;
        
        score += 100;
        UpdateScoreText();
        remainingBlocks--;

        if (remainingBlocks <= 0)
            Clear();
    }

    public void GameOver()
    {
        if (isGameEnded)
            return;

        isGameEnded = true;
        resultText.text = "GAME OVER\nPress R to Restart";
        Time.timeScale = 0f;
    }

    private void Clear()
    {
        isGameEnded = true;
        resultText.text = "CLEAR\nPress R to Restart";

        // 게임 전체 시간 정지 
        // - 공 멈춤, 물리 멈춤, Update 에서 Time.deltaTime 쓰는 이동 멈춤
        Time.timeScale = 0f;
        // 다시 시작하려면 나중에 Time.timeScale = 1 로 돌려야함
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
