using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstButtonSelected;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
    }
}
