using System.Collections;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public GameObject finalScoreEffectPrefab;
    private float duration = 1.0f;

    public void DisplayFinalScore(int finalScore)
    {
        StartCoroutine(DisplayFinalScoreCoroutine(finalScore, duration));
    }

    IEnumerator DisplayFinalScoreCoroutine(int finalScore, float duration)
    {
        TextMeshProUGUI scoreDisplay = this.GetComponent<TextMeshProUGUI>();
        scoreDisplay.text = 0.ToString();

        while (!GetComponentInParent<GameOverScreen>().GetAnimationHasFinishedForScore())
        {
            yield return null;
        }

        float numbersPerSecond = finalScore / duration;
        float currentScore = 0.0f;

        AudioManager.instance.PlayFinalScoreSound();

        while (currentScore < finalScore)
        {
            scoreDisplay.text = currentScore.ToString("0");
            currentScore += numbersPerSecond * Time.deltaTime;

            yield return null;
        }

        scoreDisplay.text = finalScore.ToString();
        Destroy(Instantiate(finalScoreEffectPrefab, scoreDisplay.transform.position, Quaternion.identity), 2.0f);

        AudioManager.instance.StopPlayigFinalScoreSound();
    }
}
