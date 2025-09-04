using UnityEngine;

public class PlayerWater : MonoBehaviour
{
    public float swimSpeed = 0.5f;
    public float waterDrag = 0.8f;
    public float waterUpwardForce = 2f;

    private Rigidbody rb;
    private bool isInWater = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Убедитесь, что у вашего объекта воды есть тег "Water"
        {
            isInWater = true;
            rb.useGravity = false;
            rb.linearDamping = waterDrag;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
            rb.useGravity = true;
            rb.linearDamping = 0f; // Верните стандартное сопротивление
        }
    }

    void FixedUpdate()
    {
        if (isInWater)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            float moveUpward = 0f;

            if (Input.GetKey(KeyCode.Space))
            {
                moveUpward = 1f;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveUpward = -1f;
            }

            Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal + transform.up * moveUpward;
            rb.AddForce(movement * swimSpeed, ForceMode.VelocityChange);
            rb.AddForce(Vector3.up * waterUpwardForce, ForceMode.Acceleration); // Небольшая постоянная выталкивающая сила
        }
    }
}