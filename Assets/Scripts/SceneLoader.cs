using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool animationHasFinishedForSceneTransition;

    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        animationHasFinishedForSceneTransition = false;
    }

    public IEnumerator LoadSceneAsync(int buildIndex)
    {
        GetComponent<Animator>().SetTrigger("Start");
        float elapsedTime = 0.0f;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        while (!animationHasFinishedForSceneTransition)
        {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;

        //setactive(false)
    }

    public void SetAnimationHasFinishedForSceneTransition(int flag)
    {
        animationHasFinishedForSceneTransition = flag == 1;
    }
}
