using UnityEngine;

public class BoatControl : MonoBehaviour
{
    public float speed = 50f; // Adjust for force-based movement
    public float turnSpeed = 50f; // Adjust for torque-based turning
    public float waterDrag = 2f; // Add some drag for water resistance
    public float angularWaterDrag = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = waterDrag; // Use drag for water resistance
        rb.angularDamping = angularWaterDrag;
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
         float currentSpeed = speed;
    if (Mathf.Abs(turnInput) > 0.5f) // Adjust threshold as needed
    {
        currentSpeed *= (1f - Mathf.Abs(turnInput) * 0.5f); // Reduce speed based on turn intensity
    }
        // Apply forward/backward force
        if (moveInput != 0)
        {
            rb.AddForce(transform.up * moveInput * currentSpeed, ForceMode.Force);
        }

        // Apply turning torque
        if (turnInput != 0)
        {
            rb.AddTorque(Vector3.up * turnInput * turnSpeed, ForceMode.Force);
        }

      
    }
}
