using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public PlatformMovement playerPlatform;
    public GameObject spawnerObject;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    private float currentTime = 0;
    private float startingTime = 60;
    private bool isGameActive = true;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (isGameActive == false) return;

        currentTime -= Time.deltaTime;
        timerText.text = ((int)currentTime).ToString();

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerText.text = "0";
            EndGame();
        }
    }

    void EndGame()
    {
        isGameActive = false;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameOverText != null && playerPlatform != null)
        {
            gameOverText.text = "Game Over:\nYou got " + playerPlatform.currentScore + " points";
        }
    }
}
