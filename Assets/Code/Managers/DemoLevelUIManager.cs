using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZXM.UIController;
using ZXM.Development;
public class DemoLevelUIManager : MonoBehaviour, IUIController
{
    private const string mainMenu = "MainMenu";
    [SerializeField] private Button exitButton;
    //level loader container
    [Header("Level Loader Related")]
    [SerializeField] private Transform levelLoaderContainerContent;
    [SerializeField] private GameObject levelLoaderPrefab;
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
    }
    private void ExitGame()
    {
        ZXMLogger.Instance.Log("Exiting Game");
        SceneManager.LoadScene(mainMenu);
    }
}
