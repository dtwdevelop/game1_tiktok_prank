using UnityEngine;

public class OceanBuoyancy : MonoBehaviour
{
    [Tooltip("How far above the water the object's submerged point floats.")]
    public float floatHeight = 1.5f;
    [Tooltip("How much the bouncing motion is dampened.")]
    public float bounceDamp = 0.05f;
    [Tooltip("Offset of the submerged point(s) relative to the object's center.")]
    public Vector3 submergedOffset = Vector3.down; // Assuming a point below the center is a good starting point
    [Tooltip("The Y-level of the ocean surface.")]
    public float oceanLevel = 0f; // Adjust this to your ocean's Y-position

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on this object.");
            enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        Vector3 worldSubmergedPosition = transform.TransformPoint(submergedOffset);
        float depth = worldSubmergedPosition.y - oceanLevel;

        if (depth < 0) // Object is submerged at this point
        {
            float displacementMultiplier = Mathf.Clamp01(-depth / floatHeight);
            Vector3 buoyancyForce = -Physics.gravity * rb.mass * displacementMultiplier;
            rb.AddForceAtPosition(buoyancyForce, worldSubmergedPosition);

            // Apply damping to reduce bouncing
            float dampVelocity = rb.GetPointVelocity(worldSubmergedPosition).y * -bounceDamp;
            rb.AddForceAtPosition(Vector3.up * dampVelocity * rb.mass, worldSubmergedPosition);
        }
    }
}