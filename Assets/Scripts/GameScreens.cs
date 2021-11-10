using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreens : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;

    public void RestartGame()
    {
        StartCoroutine(sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex));
    }

    public void QuitToMainMenu()
    {
        StartCoroutine(sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1));
        //StartCoroutine(LoadSceneAsync(X, sceneTransitionDuration));
    }
}
