using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameScreens : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private OptionsMenu optionsMenu;
    [SerializeField] private GameOverScreen gameOverScreen;

    void Start()
    {
        gameOverScreen.gameObject.SetActive(true);

        EventTrigger[] eventTriggers = GetComponentsInChildren<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Deselect;
        entry.callback.AddListener((eventData) => { AudioManager.instance.PlayMenuChangeSelectionSound(); });
        for (int i = 0; i < eventTriggers.Length; i++)
        {
            eventTriggers[i].triggers.Add(entry);
        }

        //add confirmSelection sound on onClick of all buttons
        Button[] buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(AudioManager.instance.PlayMenuConfirmSelectionSound);
        }

        gameOverScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        StartCoroutine(sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex));

        AudioManager.instance.StartGameplayMusic();
    }

    public void QuitToMainMenu()
    {
        StartCoroutine(sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1));
        //StartCoroutine(LoadSceneAsync(X, sceneTransitionDuration));

        AudioManager.instance.StartMenuMusic();
    }
}
