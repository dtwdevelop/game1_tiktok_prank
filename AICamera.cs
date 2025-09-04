using UnityEngine;
using System.Collections;
public class AICamera : MonoBehaviour
{
  private string[] AnimalsAI = {"DeerAI" , "TigerAI" , "BearAI" , "ChickenAI" , "KittyAI" , "PinguinAI"};
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 CamOffset  =  new Vector3(0 , 1.48f , -6.32f);
    private Transform target;
    public string Tname = "TigerAI" ;
    public float timeRemaining = 10;
    void Start()
    {
    
      target = GameObject.Find(Tname).transform;
      
    }

   void  RandomAnimal()
  {
  
    string animal = AnimalsAI [Random.Range(0, AnimalsAI.Length)];
     Tname  = animal;
      target = GameObject.Find(Tname).transform;
      timeRemaining  = 10f;
  }


    void Destroy() {
      Tname = "TigerAI";
    }

    // Update is called once per frame
   

    void LateUpdate() {
      this.transform.position = target.TransformPoint(CamOffset);
      this.transform.LookAt(target);
    }

  void Update()
  {   
      if(timeRemaining > 0){
        timeRemaining -= Time.deltaTime;
      }
      else{
         RandomAnimal();
      }
     
  }
}
