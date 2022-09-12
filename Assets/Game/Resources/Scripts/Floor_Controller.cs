using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Controller : MonoBehaviour
{
    [SerializeField]
    private float maxRotX = 0.6f;
    [SerializeField]
    private float maxRotZ = 0.6f;

    [SerializeField]
    private float mouseSensitivity = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Might want a toggle on-screen later for mobile equivalent of this
        if (!Input.GetMouseButton(1))
        {
            RotatePlatform();
        }
        /*
            - Check if RMB is held down (Maybe add a button later for mobile equivalent)
            - Limit rotation to X degrees in either direction (undo rotation before updating rotation if going over limit)
            - Alter rotation based on mouseX and mouseY
        */
    }

    void RotatePlatform()
    {
        
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");
        gameObject.transform.eulerAngles += new Vector3(-mY, 0, mX) * mouseSensitivity;
        Debug.Log(gameObject.transform.up);
        gameObject.transform.up = new Vector3(
            Mathf.Clamp(gameObject.transform.up.x, -maxRotX, maxRotX),
            gameObject.transform.up.y,
            Mathf.Clamp(gameObject.transform.up.z, -maxRotZ, maxRotZ));

    }
}
