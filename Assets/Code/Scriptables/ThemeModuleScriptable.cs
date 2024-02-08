using UnityEngine;

[CreateAssetMenu(fileName = "ThemeModuleScriptable", menuName = "ScriptableObjects/ThemeModule")]
public class ThemeModuleScriptable : ScriptableObject
{
    public Color primaryColor;
    public Color secondaryColor;
    public Color tertiaryColor;
}
