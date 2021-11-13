using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //public static GameManagerScript Instance { get; private set; }

    [Header("Game Settings")]
    public float startSpeed = 2.0f;
    public float maxSpeed = 10.0f;
    public float speedToRespawnRatio = 5.5f;
    public float speedIncrease = 0.1f;

    [Header("Other GameObjects")]
    public ObstacleSpawner obstacleSpawner;
    public Score scoreScript;
    public GameObject gameOverScreen;
    public FinalScore finalScore;
    public GameObject player;
    public LivesContainer livesContainer;

    private int score;
    private int lives;
    private bool gameHasEnded = false;
    private AudioManager audioManager;


    // void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    void Start()
    {
        score = 0;
        scoreScript.scoreText.text = 0.ToString();
        lives = 3;
        ObstacleMovement.speed = startSpeed;
        obstacleSpawner.respawnTime = speedToRespawnRatio / ObstacleMovement.speed;
        audioManager = AudioManager.instance;
        gameOverScreen.SetActive(false); //naar gameScreens
    }

    void Update()
    {
        if (ObstacleMovement.speed < maxSpeed)
        {
            ObstacleMovement.speed += speedIncrease * Time.deltaTime;
            obstacleSpawner.respawnTime = speedToRespawnRatio / ObstacleMovement.speed;
        }
        //FindObjectsOfType<ObstacleMovement>() += speedIncrease * Time.deltaTime;

        if (score > 50)
        {
            audioManager.ChangeGameplayMusic();
        }
    }

    public void AddToScore(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreScript.scoreText.text = score.ToString();
        StartCoroutine(scoreScript.ScoreEffect(20, 0.2f));
    }

    public void ReduceLife()
    {
        lives--;
        livesContainer.ReduceLife();
        if (lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (!gameHasEnded)
        {
            audioManager.PlayPlayerDeathSound();
            audioManager.StopMusic();

            gameOverScreen.SetActive(true); // naar gameScreens miss
            finalScore.DisplayFinalScore(score);

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            ObstacleMovement.speed = 0.0f;
            speedIncrease = 0.0f;
            Destroy(player);
            gameHasEnded = true;
        }
    }
}
