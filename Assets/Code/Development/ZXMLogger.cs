using UnityEngine;
namespace ZXM.Development
{
    public class ZXMLogger : MonoBehaviour
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static ZXMLogger Instance;
        [Tooltip("Use to Toggle Debugs")]
        [SerializeField]private bool isLogging = true;
        public bool IsLogging
        {
            get { return isLogging; }
            set { isLogging = value; }
        }
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
            //persistent
            DontDestroyOnLoad(gameObject);
        }
        /// <summary>
        /// test logger 
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            if (isLogging)
            {
                Debug.Log(message);
            }
        }   

    }
}