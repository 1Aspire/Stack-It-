using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlatformMovement : MonoBehaviour
{
    public float xBorder = 6f;
    public float speed = 10f;
    public int currentScore = 0;
    
    public TextMeshProUGUI scoreTextDisplay;
    
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        UpdateScoreUI(); 
    }

    void Update()
    {
        var velocity = rb2d.linearVelocity;
        
        if (Keyboard.current.rightArrowKey.isPressed && transform.position.x < xBorder) 
        {
            velocity.x = speed;
        } 
        else if (Keyboard.current.leftArrowKey.isPressed && transform.position.x > -xBorder)
        {
            velocity.x = -speed;
        }
        else
        {
            velocity.x = 0;
        }
        rb2d.linearVelocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectible collectible = other.GetComponent<Collectible>();

        if (collectible != null)
        {
            currentScore = currentScore + collectible.pointValue;
            UpdateScoreUI();
            Destroy(other.gameObject);
        }
    }

    public void LoseHalfPoints(int missedValue)
    {
        int penalty = missedValue / 2;
        currentScore = currentScore - penalty;
        
        if (currentScore < 0)
        {
            currentScore = 0;
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreTextDisplay != null)
        {
            scoreTextDisplay.text = "Score: " + currentScore;
        }
    }
}
