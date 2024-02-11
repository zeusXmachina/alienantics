using UnityEngine;
using ZXM.Theme;

namespace ZXM.Managers.ThemeManagers
{
    public class ThemeModule : MonoBehaviour
    {
        [SerializeField] private ThemeModuleScriptable theme;
        public static ThemeModule Instance { get; private set; }
        public bool UseThemes;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        /// <summary>
        /// supports theme module / editor issues
        /// </summary>
        /// <returns></returns>
        public ThemeSet GetThemes()
        {
            ThemeSet cols = new ThemeSet(theme.primaryColor, theme.secondaryColor, theme.tertiaryColor);
            return cols;
        }
    }
}