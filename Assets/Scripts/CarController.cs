using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]private Rigidbody2D frontTireRb2D;
    [SerializeField]private Rigidbody2D backTireRb2D;
    [SerializeField]private Rigidbody2D vehicleRb2d;
    [SerializeField]private float speed = 150f;
    [SerializeField]private float rotationSpeed = 600f;
    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = InputController.Instance.HorizontalInput;
        AudioManager.Instance.ChangeEngineSound();
    }

    private void FixedUpdate()
    {
        frontTireRb2D.AddTorque(-_horizontalInput * speed * Time.fixedDeltaTime);
        backTireRb2D.AddTorque(-_horizontalInput * speed * Time.fixedDeltaTime);
        vehicleRb2d.AddTorque(_horizontalInput * rotationSpeed * Time.fixedDeltaTime);
    }
}
