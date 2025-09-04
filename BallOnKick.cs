using UnityEngine;

public class BallOnKick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    public float speed = 8;
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("boat")){
      Debug.Log("boat kick ball");

        // Example: Applying a force for fun effects (ensure Rigidbody is attached to the ball)
      Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply a small upward force upon trigger entry
            Vector3 force = other.transform.up *  -speed ;
            rb.AddForce(force, ForceMode.Impulse);
        }
        }
    }
}
