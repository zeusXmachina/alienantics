using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuItem : MonoBehaviour
{
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text levelDifficulty;
    [SerializeField] private Button levelButton;
    /// <summary>
    /// Initialise method , used on instantiation of the level menu item, follows menu item rules and requirements, see MenuItem for more details
    /// </summary>
    /// <param name="num"></param>
    /// <param name="dif"></param>
    public void Initialise(int num, int dif){}
}
