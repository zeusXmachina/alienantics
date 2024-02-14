using UnityEngine;

namespace ZXM.Development
{
    public class CustomCursor : MonoBehaviour
    {
        public Texture2D cursorTexture;
        public Vector2 hotSpot = Vector2.zero;

        void Start()
        {
            // Set the cursor to the custom cursor
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }
    }
}