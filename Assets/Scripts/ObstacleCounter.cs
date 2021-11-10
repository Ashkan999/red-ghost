using UnityEngine;

public class ObstacleCounter : MonoBehaviour
{
    public GameManagerScript gameManagerScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        CheckWaveAlreadyTriggered();
        Destroy(other.gameObject, 2.0f);
        //obstacleDestroyer.DestroyObstacle(other.gameObject); if particleEffects are wanted
    }

    private void CheckWaveAlreadyTriggered()
    {
        if (!this.IsInvoking())
        {
            this.Invoke("UpdateScore", Time.fixedDeltaTime);
        }
    }

    private void UpdateScore()
    {
        gameManagerScript.AddToScore(1);
    }
}
