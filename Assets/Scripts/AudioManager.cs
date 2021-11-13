using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private Animator animator;
    private bool GameplayMusic2Started; //update this outside this class when going to main menu from pause
    [SerializeField] private AudioSource playerMove;
    [SerializeField] private AudioSource playerDamage;
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private AudioSource menuSelection;
    [SerializeField] private AudioSource menuConfirm;
    [SerializeField] private AudioSource wind;
    [SerializeField] private string musicVolume;
    [SerializeField] private AudioMixer audioMixer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

            animator = GetComponent<Animator>();
            GameplayMusic2Started = false;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void StartMenuMusic()
    {
        animator.SetTrigger("startMenuMusic");
    }

    public void StartGameplayMusic()
    {
        animator.SetTrigger("startGameplayMusic");
    }


    public void StartGameplayMusicFromMainMenu()
    {
        animator.SetTrigger("StartGameplayMusicFromMainMenu");
    }

    public void ChangeGameplayMusic()
    {
        if (!GameplayMusic2Started)
        {
            animator.SetTrigger("startGameplayMusic2");
            GameplayMusic2Started = true;
        }
    }

    public void StopMusic()
    {
        animator.SetTrigger("stopMusic");
    }

    public void AdjustMusicVolume(float volume)
    {
        // AudioSource[] audioSources = AudioManager.instance.GetComponentsInChildren<AudioSource>(); //preferably we would want to be able to lower sources instead of the audio listener but 
        // sources that are animated can apparantly not be scripted anymore
        // for (int i = 0; i < audioSources.Length; i++)
        // {
        //     audioSources[i].volume = volume;
        // }

        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        audioMixer.SetFloat(musicVolume, Mathf.Log10(volume * masterVolume) * 20f);
    }

    public void PlayPlayerMoveSound()
    {
        playerMove.Play();
    }

    public void PlayPlayerDamageSound()
    {
        playerDamage.Play();
    }

    public void PlayPlayerDeathSound()
    {
        playerDeath.Play();
    }

    public void PlayMenuChangeSelectionSound()
    {
        menuSelection.Play();
    }

    public void PlayMenuConfirmSelectionSound()
    {
        menuConfirm.Play();
    }

    public void PlayWindSound()
    {
        // Debug.Log("wind");
        // wind.Play();
        // wind.volume = 1f;
    }
}
