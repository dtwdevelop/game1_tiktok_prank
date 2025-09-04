using UnityEngine;
using UnityEngine.AI;
public class OnSeeAIPluck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("pluck")){
         var  agent  =  gameObject.GetComponentInParent<NavMeshAgent>();
         agent.destination = other.transform.position;
        //Debug.Log("See ball");
      
      
        }
    }
}
