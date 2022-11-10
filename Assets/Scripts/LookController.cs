using UnityEngine;

public class LookController : MonoBehaviour
{
    [SerializeField] private float lookXSensitivity = 150f;
    [SerializeField] private float lookYSensitivity = 150f;

    [SerializeField] private Transform player;
    
    private Vector2 lookVector;
    private float xRotation = 0f;


    public void SetLookVector(Vector2 _lookVector)
    {
        lookVector = _lookVector;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = lookVector.x * lookXSensitivity * Time.deltaTime;
        float mouseY = lookVector.y * lookYSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        player.Rotate(Vector3.up * mouseX);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
