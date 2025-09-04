using UnityEngine;

public class OnBoartHockey : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnCollisionEnter(Collision collision)
  {
    
      
           if(collision.gameObject.CompareTag("pluck")){
     
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
           Vector3 directionToOtherObject = collision.transform.position - gameObject.transform.position;
           float angle = Vector3.Angle(gameObject.transform.forward, directionToOtherObject);
            // Apply a small upward force upon trigger entry
            Vector3 angledDirection = Quaternion.Euler(0, angle, 0) * gameObject.transform.forward;
            Vector3 force =  angledDirection  * - 8f;
            
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
           
        
    
   
  }
}
