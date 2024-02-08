using UnityEngine;
namespace ZXM.Theme
{
    [System.Serializable]
    public class ThemeSet
    {
        public Color PrimaryColor;
        public Color SecondaryColor;
        public Color TertiaryColor;

        /// <summary>
        /// constructor for theme set
        /// </summary>
        /// <param name="primary"></param>
        /// <param name="secondary"></param>
        /// <param name="tertiary"></param>
        public ThemeSet(Color primary, Color secondary, Color tertiary)
        {
            PrimaryColor = primary;
            SecondaryColor = secondary;
            TertiaryColor = tertiary;
        }
    }
}