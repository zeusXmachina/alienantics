using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZXM.UIController;
using ZXM.World;

public class LevelEditorUIManager : MonoBehaviour, IUIController
{
    private const string mainMenu = "MainMenu";
    [SerializeField] private Button exitButton;
    [SerializeField] private Button removeButton;
    void Start()
    {
        SetupButtonActions();
    }
    public void SetObjectDisplay(GameObject go, bool value)
    {
        go.SetActive(value);
    }
    public void SetupButtonActions()
    {
        exitButton.onClick.AddListener(ExitGame);
        removeButton.onClick.AddListener(delegate { BuildModeWorld.Instance.RemoveBlock(); });
    }
    private void ExitGame()
    {
        Debug.Log("Exit Game");
        SceneManager.LoadScene(mainMenu);
    }
}
