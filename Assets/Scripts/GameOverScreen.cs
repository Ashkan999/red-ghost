using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverScreen : MonoBehaviour
{
    public OptionsMenu optionsMenu;
    public GameObject firstButtonSelected;
    private bool animationHasFinishedForScore;

    void Start()
    {
        animationHasFinishedForScore = false;
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
        optionsMenu.DisableUIControls();
    }

    public void SetAnimationHasFinishedForScore(int flag)

    {
        animationHasFinishedForScore = flag == 1;
    }

    public bool GetAnimationHasFinishedForScore()
    {
        return animationHasFinishedForScore;
    }
}
