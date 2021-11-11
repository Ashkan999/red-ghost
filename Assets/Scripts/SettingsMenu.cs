using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    [SerializeField] private GameObject firstButtonSelected;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
    }

    public void AdjustVolume()
    {
        // AudioListener.volume = volumeSlider.value;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
