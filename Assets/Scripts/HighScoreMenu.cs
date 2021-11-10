using UnityEngine;
using UnityEngine.EventSystems;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstButtonSelected;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
        gameObject.SetActive(false);
    }
}
