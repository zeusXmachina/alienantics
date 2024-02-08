using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZXM.Managers
{
    public class ThemeModule : MonoBehaviour
    {
        [SerializeField] private ThemeModuleScriptable theme;
        public static ThemeModule Instance { get; private set; }

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
        public Color[] GetThemes()
        {
            var col = new Color[3];
            col[0] = theme.primaryColor;
            col[1] = theme.secondaryColor;
            col[2] = theme.tertiaryColor;

            return col;
        }
    }
}