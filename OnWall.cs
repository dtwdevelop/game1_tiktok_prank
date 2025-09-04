using UnityEngine;

public class OnWall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other){
      Debug.Log(other.name);
      switch(other.name){
       case "Tiger" or "Deer" or "Chicken" or "Dog" or "Pinguin" or "Kitty" or "Bear" or "Wolf":
       Debug.Log(other.name);
       break;
          
        
      }
  }
}
