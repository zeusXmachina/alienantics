using UnityEngine;
using UnityEngine.UI;
using ZXM.UIController;

namespace ZXM.Managers
{
    public class MainMenuUIManager : MonoBehaviour, IUIController
    {
        /// <summary>
        /// dummy state for the menu
        /// </summary>
        [SerializeField] private int menuState;
        [SerializeField] Button startGameButton;
        [SerializeField] Button levelEditorButton;
        [SerializeField] Button creditsButton;
        [SerializeField] Button companyButton;
        /// <summary>
        /// Test objects for main menu, refactor later
        /// </summary>
        [Header("Test Menu Objects")]
        [SerializeField] private GameObject[] testObjects;
        private void Awake()
        {
            menuState = 0;
        }
        private void Start()
        {
            //set state
            SetState(menuState);
            SetupButtonActions();
        }
        public void SetupButtonActions()
        {
            startGameButton.onClick.AddListener(StartGame);
            levelEditorButton.onClick.AddListener(OpenLevelEditor);
            creditsButton.onClick.AddListener(OpenCredits);
            companyButton.onClick.AddListener(OpenCompanyPage);
        }
        /// <summary>
        /// Set the state of the menu, dummy version refator later
        /// </summary>
        /// <param name="state"></param>
        private void SetState(int state)
        {
            switch (state)
            {
                case 0:
                    foreach (GameObject go in testObjects)
                    {
                        SetObjectDisplay(go, false);
                    }
                    break;
                case 1:

                    break;
                case 2:

                    break;
                default:

                    break;
            }
        }
        private void StartGame()
        {
            Debug.Log("Start Game");
        }
        private void OpenLevelEditor()
        {
            Debug.Log("Open Level Editor");
        }
        private void OpenCredits()
        {
            Debug.Log("Open Credits");
        }
        private void OpenCompanyPage()
        {
            Debug.Log("Open Company Page");
        }
        public void SetObjectDisplay(GameObject go, bool value)
        {
            go.SetActive(value);
        }
    }
}