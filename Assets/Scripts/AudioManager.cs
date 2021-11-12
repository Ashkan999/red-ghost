using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private bool GameplayMusic2Started = false; //uopdate this outside this class when going to main menu from pause

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

    public void StartMenuMusic()
    {
        AudioManager.instance.GetComponent<Animator>().SetTrigger("startMenuMusic");
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

    public void StopMusic()
    {
        AudioManager.instance.GetComponent<Animator>().SetTrigger("stopMusic");
    }

    public void AdjustVolume(float volume)
    {
        // AudioSource[] audioSources = AudioManager.instance.GetComponentsInChildren<AudioSource>(); //preferably we would want to be able to lower sources instead of the audio listener but 
        // sources that are animated can apparantly not be scripted anymore
        // for (int i = 0; i < audioSources.Length; i++)
        // {
        //     audioSources[i].volume = volume;
        // }

        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        AudioListener.volume = volume * masterVolume;

    }
}
