using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Inscribed")]
    public GameObject startPanel;
    public GameObject endPanel;
    public TMP_Text livesText;
    public TMP_Text endText;
    public int lives = 3;

    bool started = false;
    bool gameOver = false;

    void Awake()
    {
        instance = this;
        Time.timeScale = 0;              // freeze the game until Enter is pressed
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        UpdateLivesText();
    }

    void Update()
    {
        if (!Keyboard.current.enterKey.wasPressedThisFrame) return;

        if (!started)
        {
            started = true;
            startPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else if (gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText();
        if (lives <= 0) EndGame(false);
    }

    public void EndGame(bool won)
    {
        if (gameOver) return;
        gameOver = true;
        Time.timeScale = 0;
        endPanel.SetActive(true);
        endText.text = won ? "YOU WIN!\nPress Enter to restart" : "GAME OVER\nPress Enter to restart";
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}