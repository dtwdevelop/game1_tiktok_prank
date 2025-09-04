using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMove : MonoBehaviour
{
  public Transform patrolRoute;
  public List<Transform> locations;
  private int locationIndex = 0;
  private NavMeshAgent agent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitRouteMove();
        agent  = GetComponent<NavMeshAgent>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.3f && !agent.pathPending){
          MoveAIPlayerNext();
        }
    }
    void InitRouteMove(){
      foreach (Transform child in patrolRoute){
        locations.Add(child);
      }

    }

  

  void  MoveAIPlayerNext(){
    if(locations.Count == 0)
      return;
     agent.destination  = locations[locationIndex].position;
     locationIndex = (locationIndex +1) % locations.Count;
  }

  private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ball")){
        if (agent != null){
           agent.destination = other.transform.position;
        }
       }
    }
}
