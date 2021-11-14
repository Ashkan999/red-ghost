using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject firstButtonSelected;
    private InputMaster inputMaster;
    private CanvasGroup canvasGroup;
    private bool alreadyOpen;

    void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.UI.OpenOptionsMenu.performed += context =>
        {
            if (!alreadyOpen)
            {
                OpenOptionsMenu();
            }
            else
            {
                CloseOptionsMenu();
            }
        };

        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // EventSystem.current.SetSelectedGameObject(firstButtonSelected);

        CloseOptionsMenu();
    }

    void OpenOptionsMenu()
    {
        StartCoroutine(LockAndHideCursor());

        playerController.DisablePlayerControls();
        Time.timeScale = 0f;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        alreadyOpen = true;

        Button[] buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
        }

        EventSystem.current.SetSelectedGameObject(firstButtonSelected);

        AudioManager.instance.PauseMusic();
    }

    private void CloseOptionsMenu()
    {
        StartCoroutine(LockAndHideCursor());

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        alreadyOpen = false;

        Button[] buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }

        AudioManager.instance.UnpauseMusic();

        playerController.EnablePlayerControls();
        Time.timeScale = 1f;
    }

    IEnumerator LockAndHideCursor()
    {
        yield return new WaitForSeconds(1.0f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EnableUIControls()
    {
        inputMaster.UI.Enable();
    }

    public void DisableUIControls()
    {
        inputMaster.UI.Disable();
    }

    void OnEnable()
    {
        EnableUIControls();
    }

    void OnDisable()
    {
        DisableUIControls();
    }
}
