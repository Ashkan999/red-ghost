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
    [SerializeField] private AudioSource finalScore;
    [SerializeField] private AudioSource finalScoreFinish;
    [SerializeField] private string musicVolume;
    [SerializeField] private string effectsVolume;
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

    public void PauseMusic()
    {
        audioMixer.FindSnapshot("paused").TransitionTo(0f);
    }

    public void UnpauseMusic()
    {
        audioMixer.FindSnapshot("start").TransitionTo(0f);
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

    public void PlayFinalScoreSound()
    {
        finalScore.Play();
    }

    public void StopPlayigFinalScoreSound()
    {
        finalScore.Stop();
        finalScoreFinish.Play();
    }
}
