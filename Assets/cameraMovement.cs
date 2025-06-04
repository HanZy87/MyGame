    using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3 (0, 2, -4);
    public float sensivitas = 4.0f;
    public float smothSpeed = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensivitas;
        rotationY -= Input.GetAxis("Mouse Y") * sensivitas;
        rotationY = Mathf.Clamp(rotationY, -30f , 60f );
        
        Quaternion rotation = Quaternion.Euler ( rotationY, rotationX, 0 );
        Vector3 desiredPosition = target.position + (rotation * offset);  

        transform.position = Vector3.Lerp (transform.position, desiredPosition, smothSpeed * Time.deltaTime);
        transform.LookAt (target.position);
    }

}
