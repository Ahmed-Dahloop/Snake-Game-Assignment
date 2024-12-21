using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    public Text gameOverText; 
    public Slider timeBar;
    private bool isGameOver = false;
    private int score = 0;
    private float timeRemaining = 30f;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    private int totalCoins;
    private int collectedCoins = 0; 

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("coin").Length;
        gameOverText.gameObject.SetActive(false); 
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime;
            timeBar.value = timeRemaining;

            if (timeRemaining <= 0)
            {
                GameOver();
            }
        }
    }

    public void IncrementScore()
    {
        if (isGameOver) return;
        score += 10; 
        collectedCoins++; 
        scoreText.text = "Score: " + score;

        
        if (collectedCoins == totalCoins)
        {
            GameOver();
        }
    }

   public void GameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
        isGameOver = true;
        gameOverText.gameObject.SetActive(true); 
        gameOverText.text = "Game Over!\nScore: " + score;
        Debug.Log("Game Over!");
    }
}
