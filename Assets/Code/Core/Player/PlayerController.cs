using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// test player transform
    /// </summary>
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float h;
    [SerializeField] private float v;
    [SerializeField] private float speed;
    [SerializeField] private float torque;

    /// <summary>
    /// old input system 
    /// webgl controls?
    /// mobile controls?
    /// </summary>
    private void Update()
    {
        CheckInput();
    }
    public void CheckInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    public void Move()
    {
        playerTransform.Translate(Vector3.forward * v * speed * Time.deltaTime);
    }

}
