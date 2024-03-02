using UnityEngine;
public class LevelEditorCameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float panSpeed = 1f;
    /// <summary>
    /// all these controls should be made into a scriptabe input object
    /// </summary>
    [SerializeField] private KeyCode panUp;
    [SerializeField] private KeyCode panDown;
    [SerializeField] private KeyCode panLeft;
    [SerializeField] private KeyCode panRight;
    void Update()
    {
        if (Input.GetKey(panUp)) 
        {
        cameraTransform.Translate(Vector3.up * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey(panDown))
        {
            cameraTransform.Translate(Vector3.down * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey(panLeft))
        {
            cameraTransform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey(panRight))
        {
            cameraTransform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
    }
}
