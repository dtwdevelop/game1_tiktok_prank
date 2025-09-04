using UnityEngine;

public class PlaneFloat : MonoBehaviour
{
    public float waterLevel = 0f;
    public float floatHeightOffset = 0.1f;
    public float swaySpeed = 1f;
    public float swayAmount = 0.02f;
    public float rotationSpeed = 0.5f;
    public float rotationAmount = 5f;

    private Rigidbody rb;
    private float initialY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is required.");
            enabled = false;
            return;
        }
        rb.useGravity = false;
        initialY = waterLevel + floatHeightOffset;
    }

    void FixedUpdate()
    {
        float targetY = initialY + Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        rb.MovePosition(new Vector3(transform.position.x, targetY, transform.position.z));

        float rotationX = Mathf.Sin(Time.time * rotationSpeed * 0.5f) * rotationAmount;
        float rotationZ = Mathf.Sin(Time.time * rotationSpeed * 0.7f + 1f) * rotationAmount;
        rb.MoveRotation(Quaternion.Euler(rotationX, transform.eulerAngles.y, rotationZ));
    }
}
