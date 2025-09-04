using UnityEngine;

public class Punk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    public float speed = 10;
    void Start()
    {
       Rigidbody rb = GetComponent<Rigidbody>();
    rb.linearDamping = 0.1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ballkick")){

        // Example: Applying a force for fun effects (ensure Rigidbody is attached to the ball)
       Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply a small upward force upon trigger entry
            Vector3 force =  other.transform.forward * speed ;
            rb.AddForce(force, ForceMode.Impulse);
        }
        }


    }
    
 
}

