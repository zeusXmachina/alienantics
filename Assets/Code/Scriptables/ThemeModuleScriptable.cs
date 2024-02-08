using UnityEngine;

[CreateAssetMenu(fileName = "ThemeModuleScriptable", menuName = "ScriptableObjects/ThemeModule")]
public class ThemeModuleScriptable : ScriptableObject
{
    [SerializeField] private Color primaryColor;
    [SerializeField] private Color secondaryColor;
    [SerializeField] private Color tertiaryColor;
}
