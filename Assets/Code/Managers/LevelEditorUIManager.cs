using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZXM.UIController;
using ZXM.World;

public class LevelEditorUIManager : MonoBehaviour, IUIController
{
    [SerializeField] private BuildMode buildMode;
    private const string mainMenu = "MainMenu";
    [SerializeField] private Button exitButton;
    [SerializeField] private Button removeButton;
    [SerializeField] private Button removeAllButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button selectBlockOpenButton;
    [SerializeField] private Button selectBlockCloseButton;
    [SerializeField] public EventTrigger toolbarEventTrigger;
    [SerializeField] private EventTrigger selectBlockPanelEventTrigger;
    [SerializeField] private GameObject selectBlockPanel;
    [SerializeField] private EditorUIState editorUIState;

    void Start()
    {
        editorUIState = EditorUIState.Default;
        SetupButtonActions();
        SetupEventTrigger();
    }
    public void SetObjectDisplay(GameObject go, bool value)
    {
        go.SetActive(value);
    }
    public void SetupButtonActions()
    {
        exitButton.onClick.AddListener(ExitGame);
        removeButton.onClick.AddListener(delegate { BuildModeWorld.Instance.RemoveBlock(); });
        removeAllButton.onClick.AddListener(delegate { BuildModeWorld.Instance.ClearAllBlocks(); });
        saveButton.onClick.AddListener(delegate { BuildModeWorld.Instance.SaveBlocks(); });
        loadButton.onClick.AddListener(delegate { BuildModeWorld.Instance.LoadBlocks(); });
        selectBlockOpenButton.onClick.AddListener(OnSelectBlockOpenButton);
        selectBlockCloseButton.onClick.AddListener(OnSelectBlockCloseButton);
    }
    private void SetupEventTrigger() 
    {
        // Create a new entry for the EventTrigger
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter; 
        entry.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data); }); 
        toolbarEventTrigger.triggers.Add(entry);
        selectBlockPanelEventTrigger.triggers.Add(entry);

        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerExit;
        entry1.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data); });
        toolbarEventTrigger.triggers.Add(entry1);
        selectBlockPanelEventTrigger.triggers.Add(entry1);
    }
    private void ExitGame()
    {
        Debug.Log("Exit Game");
        SceneManager.LoadScene(mainMenu);
    }
    private void OnPointerEnterDelegate(PointerEventData data)
    {
        Debug.Log("Pointer entered with EventTrigger: " + data.pointerEnter.name);
        buildMode.IsBuild = false;
    }

    private void OnPointerExitDelegate(PointerEventData data)
    {
        Debug.Log("Pointer exited with EventTrigger: " + data.pointerEnter.name);
        buildMode.IsBuild = true;
    }
    private void OnSelectBlockOpenButton()
    {
        SetObjectDisplay(selectBlockPanel, true);
        buildMode.IsBuild = false;
    }
    private void OnSelectBlockCloseButton()
    {
        SetObjectDisplay(selectBlockPanel, false);
        buildMode.IsBuild = true;
    }
}
