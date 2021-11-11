using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstButtonSelected;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject highScoreMenu;
    [SerializeField] private GameObject settingsMenu;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
    }

    public void StartGame()
    {
        StartCoroutine(sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void OpenHighScore()
    {
        highScoreMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
