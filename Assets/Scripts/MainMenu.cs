using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button firstButtonSelected;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject highScoreMenu;
    [SerializeField] private GameObject settingsMenu;
    private AudioManager audioManager;

    // void Start() // use this if start does not get selected at start of game
    // {
    //     StartCoroutine(SelectFirstButtonAfterOneFrame());
    // }

    void Start()
    {
        audioManager = AudioManager.instance;

        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);

        Time.timeScale = 1f; //Because if we come from pause menu time could still be paused
        audioManager.AdjustMusicVolume(1.0f);

        //add eventriggers to all buttons for changeSelection sound on deselect
        highScoreMenu.SetActive(true);
        settingsMenu.SetActive(true);

        EventTrigger[] eventTriggers = transform.parent.gameObject.GetComponentsInChildren<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Deselect;
        entry.callback.AddListener((eventData) => { audioManager.PlayMenuChangeSelectionSound(); });
        for (int i = 0; i < eventTriggers.Length; i++)
        {
            eventTriggers[i].triggers.Add(entry);
        }

        //add confirmSelection sound on onClick of all buttons
        Button[] buttons = transform.parent.gameObject.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(audioManager.PlayMenuConfirmSelectionSound);
        }

        highScoreMenu.SetActive(false);
        settingsMenu.SetActive(false);

    }

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(SelectFirstButtonAfterOneFrame());
    }

    IEnumerator SelectFirstButtonAfterOneFrame() //this was probably a bug or it relates to the lifcycle but we need to skip 1 frame before selecting start to get the highlight right
    { //either first 2 lines of last 2 lines works
        yield return null;
        // EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButtonSelected.gameObject);
        // firstButtonSelected.gameObject.SetActive(true);
        // firstButtonSelected.Select();
    }

    public void StartGame()
    {
        StartCoroutine(sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));

        audioManager.PlayMenuConfirmSelectionSound();
        audioManager.StartGameplayMusicFromMainMenu();
    }

    public void OpenHighScore()
    {
        audioManager.PlayMenuConfirmSelectionSound();
        highScoreMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        audioManager.PlayMenuConfirmSelectionSound();
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        audioManager.PlayMenuConfirmSelectionSound();
        Application.Quit();
    }
}
