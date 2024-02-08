using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZXM.UIController;

public class DemoLevelUIManager : MonoBehaviour, IUIController
{
    private const string mainMenu = "MainMenu";
    [SerializeField] private Button exitButton;


    // Start is called before the first frame update
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
        Debug.Log("Exit Game");
        SceneManager.LoadScene(mainMenu);
    }
}
