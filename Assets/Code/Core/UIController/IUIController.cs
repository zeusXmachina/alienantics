using UnityEngine;
namespace ZXM.UIController
{
    /// <summary>
    /// Used in all UI Managers
    /// </summary>
    public interface IUIController
    {
        void SetupButtonActions();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="go"></param>
        /// <param name="value"></param>
        void SetObjectDisplay(GameObject go, bool value);
        

    }
}
