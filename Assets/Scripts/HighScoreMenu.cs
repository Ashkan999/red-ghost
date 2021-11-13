using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using UnityEngine.UI;


public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreNumber;
    [SerializeField] private Button firstButtonSelected;

    void OnEnable()
    {
        StartCoroutine(SelectFirstButtonAfterOneFrame());

        highScoreNumber.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    IEnumerator SelectFirstButtonAfterOneFrame() //this was probably a bug or it relates to the lifcycle but we need to skip 1 frame before selecting start to get the highlight right (see mainMenu)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(firstButtonSelected.gameObject);
    }
}
