using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstButtonSelected;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject highScoreMenu;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
    }

    public void StartGame()
    {
        StartCoroutine(sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void openHighScore()
    {
        Debug.Log("open highscore");
        highScoreMenu.SetActive(true);
        //gameObject.SetActive(false);
    }

    public void OpenSettings()
    {


    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
