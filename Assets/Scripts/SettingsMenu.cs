using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button firstButtonSelected;

    public UnityEngine.UI.Slider VolumeSlider { get => volumeSlider; set => volumeSlider = value; }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected.gameObject);

        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
    }

    public void AdjustVolumeSlider()
    {
        PlayerPrefs.SetFloat("MasterVolume", volumeSlider.value);
        AudioListener.volume = volumeSlider.value;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
