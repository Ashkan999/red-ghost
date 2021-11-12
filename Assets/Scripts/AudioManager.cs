using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private bool GameplayMusic2Started = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void StartGameplayMusic()
    {
        AudioManager.instance.GetComponent<Animator>().SetTrigger("startGameplayMusic");
    }

    public void ChangeGameplayMusic()
    {
        if (!GameplayMusic2Started)
        {
            AudioManager.instance.GetComponent<Animator>().SetTrigger("startGameplayMusic2");
            GameplayMusic2Started = true;
        }
    }
}
