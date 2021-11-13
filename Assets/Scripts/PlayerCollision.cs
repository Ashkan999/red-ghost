using System.Collections;
using UnityEngine;
using EZCameraShake;

public class PlayerCollision : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public ObstacleDestroyer obstacleDestroyer;
    private float invincibleDuration = 2.0f;
    private float alphaChangeSpeed = 1.5f;

    void OnCollisionEnter2D(Collision2D other)
    {
        AudioManager.instance.PlayPlayerDamageSound();
        CameraShaker.Instance.ShakeOnce(8f, 13f, 0f, 0.7f);
        obstacleDestroyer.DestroyObstacle(other.gameObject);
        StartCoroutine(PlayerIsInvincible(invincibleDuration));
        gameManagerScript.ReduceLife();
    }

    IEnumerator PlayerIsInvincible(float duration)
    {
        GetComponent<BoxCollider2D>().enabled = false;

        SpriteRenderer player = GetComponent<SpriteRenderer>();
        float elapsed = 0.0f;
        bool increasing = false;
        Color color;
        while (elapsed < duration)
        {
            color = player.color;
            if (increasing)
            {
                color.a += alphaChangeSpeed * Time.deltaTime;
                if (color.a >= 1.0)
                {
                    increasing = false;
                }
            }
            else
            {
                color.a -= alphaChangeSpeed * Time.deltaTime;
                if (color.a <= 0.35)
                {
                    increasing = true;
                }
            }
            player.color = color;

            elapsed += Time.deltaTime;
            yield return null;
        }

        color = player.color;
        color.a = 1;
        player.color = color;

        GetComponent<BoxCollider2D>().enabled = true;
    }
}
