using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float RotationSpeed = 2.0f;

    public bool InverseCamera = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        var rotateValue = new Vector3(InverseCamera ? mouseY : -mouseY,
            -mouseX, 0f);

        transform.eulerAngles += rotateValue * RotationSpeed;
    }
}
