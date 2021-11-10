using UnityEngine;
using UnityEngine.UI;

public class LivesContainer : MonoBehaviour
{

    private int currentLive;
    private Image[] lives;

    void Start()
    {
        lives = GetComponentsInChildren<Image>();
        currentLive = lives.Length - 1;
    }

    public void ReduceLife()
    {
        lives[currentLive].enabled = false;
        currentLive--;
    }
}
