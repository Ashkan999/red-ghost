using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HighScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreNumber;
    [SerializeField] private GameObject firstButtonSelected;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
        gameObject.SetActive(false);

        highScoreNumber.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
