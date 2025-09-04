using UnityEngine;

public class OnLandCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter(Collision collision)
  {
    if(collision.gameObject.CompareTag("pluck")){
      float Xterainpos  = collision.gameObject.transform.position.x;
      float Zterainpos  = collision.gameObject.transform.position.z;
      float x  = gameObject.transform.position.x;
      float z = gameObject.transform.position.z;
      if(x > Xterainpos || x < Xterainpos  || z > Zterainpos || z < Zterainpos ){
        if(collision.gameObject != null){
         // Destroy(collision.gameObject);
        }
       
      }
    }
    
  }
}
