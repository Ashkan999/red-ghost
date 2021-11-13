using UnityEngine;
using UnityEngine.EventSystems;

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
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);

        CloseOptionsMenu();
    }

    void OpenOptionsMenu()
    {
        playerController.DisablePlayerControls();
        Time.timeScale = 0f;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        alreadyOpen = true;

        AudioManager.instance.AdjustVolume(0.4f);
    }

    private void CloseOptionsMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        alreadyOpen = false;

        AudioManager.instance.AdjustVolume(1.0f);

        playerController.EnablePlayerControls();
        Time.timeScale = 1f;
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
