using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreNumber;
    [SerializeField] private GameObject firstButtonSelected;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);

        highScoreNumber.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
