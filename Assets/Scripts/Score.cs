using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject scoreEffectPrefab;

    private float startingFontSize;

    void Start()
    {
        startingFontSize = scoreText.fontSize;
    }

    public IEnumerator ScoreEffect(int increaseFont, float duration)
    {
        Destroy(Instantiate(scoreEffectPrefab, scoreText.transform.position, Quaternion.identity), 2f);

        float step = increaseFont * 2 / duration;
        float elapsed = 0f;
        while (elapsed < duration / 2f)
        {
            scoreText.fontSize += step * Time.deltaTime;

            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < duration / 2f)
        {
            scoreText.fontSize -= step * Time.deltaTime;

            elapsed += Time.deltaTime;
            yield return null;
        }

        scoreText.fontSize = startingFontSize;

        // int step = increaseFont * 2 / duration;
        // for (int i = 0; i < duration / 2; i++)
        // {
        //     scoreText.fontSize += step;
        //     yield return null;
        // }
        // for (int i = 0; i < duration / 2; i++)
        // {
        //     scoreText.fontSize -= step;
        //     yield return null;
        // }
    }
}
