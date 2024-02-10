using UnityEngine;
using UnityEngine.UI;

namespace ZXM.Managers
{
    public class DemoLevelThemeEditor : MonoBehaviour, IThemeEditor
    {
        [SerializeField] private Image[] primaryImages;
        [SerializeField] private Image[] secondaryImages;
        [SerializeField] private Image[] tertiaryImages;
        public void SetTheme()
        {
            if (!ThemeModule.Instance.UseThemes) return;
            foreach (var image in primaryImages)
            {
                image.color = ThemeModule.Instance.GetThemes().PrimaryColor;
            }
            foreach (var image in secondaryImages)
            {
                image.color = ThemeModule.Instance.GetThemes().SecondaryColor;
            }
            foreach (var image in tertiaryImages)
            {
                image.color = ThemeModule.Instance.GetThemes().TertiaryColor;
            }
        }

        private void Start()
        {
            SetTheme();
        }
    }
}