using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
public class OnCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    void  OnCollisionEnter(Collision  other){
      
      
    }

    void OnTriggerEnter(Collider other){
     
      if(other.name == "Tiger" ){
         if(gameObject.tag == "apple"){
            Destroy(gameObject);
         GameManager gM  = GameObject.Find("GManager").GetComponent<GameManager>();
         GameObject obj = GameObject.Find("Info");
         gM.total += 1;
         TMP_Text txt = obj.GetComponentInChildren<TMP_Text>();
         txt.text = $"apples : {gM.total }";
         }
          
        
      }

      if(other.name == "Deer"){
        if(gameObject.tag == "strawberry")
           Destroy(gameObject);

      }
       if(other.name == "Pinguin"){
        if(gameObject.tag == "banana")
           Destroy(gameObject);

      }
       if(other.name == "Chicken"){
        if(gameObject.tag == "heart"){

        }
         

      }

        if(other.name == "Dog"){
        if(gameObject.tag == "watermelon")
           Destroy(gameObject);

      }

        if(other.name == "Kitty"){
        if(gameObject.tag == "orange")
           Destroy(gameObject);

      }

         if(other.name == "Bear"){
        if(gameObject.tag == "orange")
           Destroy(gameObject);

      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
