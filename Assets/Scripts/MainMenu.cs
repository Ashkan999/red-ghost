using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button firstButtonSelected;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject highScoreMenu;
    [SerializeField] private GameObject settingsMenu;

    // void Start() // use this if start does not get selected at start of game
    // {
    //     StartCoroutine(SelectFirstButtonAfterOneFrame());
    // }
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
        audioManager.StartGameplayMusic();
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
