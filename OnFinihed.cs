using UnityEngine;

public class OnFinihed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }

      void  OnTriggerExit(Collider  other){
        if(other.name == "Tiger" ){
           GameManager gM  = GameObject.Find("GManager").GetComponent<GameManager>();
           gM.status = false;
         Debug.Log("Tiger finihed");
        }
      
    }
}
