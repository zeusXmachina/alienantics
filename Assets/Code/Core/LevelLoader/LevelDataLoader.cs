using System.Collections.Generic;
using UnityEngine;
using ZXM.Development;

public class LevelDataLoader : MonoBehaviour
{
    public List<DummyLevel> levels;
    //UI Manager for Demo Level
    [SerializeField] private DemoLevelUIManager demoLevelUIManager;
    private void Awake()
    {
        SetLevelData();
    }
    private void Start()
    {
        LoadLevelData();
    }
    private void SetLevelData()
    {
        levels.Add(new DummyLevel(1, 1));
        levels.Add(new DummyLevel(2, 1));
        levels.Add(new DummyLevel(3, 2));
    }

    private void LoadLevelData()
    {
        foreach (var level in levels)
        {
            ZXMLogger.Instance.Log("Level Number: " + level.number + " Difficulty: " + level.difficulty);
            demoLevelUIManager.AddLevelDataUI(level);
        }
    }
}
/// <summary>
/// move later for debug only, load from JSON and Deserialize
/// </summary>
[System.Serializable]
public class DummyLevel
{
    public int number;
    public int difficulty;
    public DummyLevel(int number, int difficulty)
    {
        this.number = number;
        this.difficulty = difficulty;
    }
}
