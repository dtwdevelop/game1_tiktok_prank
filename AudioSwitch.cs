using UnityEngine;
using UnityEngine.PlayerLoop;

public class AudioSwitch : MonoBehaviour
{
  public GameObject EngManager;
  public GameObject RuManager;
  public GameObject CNManager;
  public GameObject ESManager;
  public GameObject DEManager;
   public GameObject FRManager;
  public GameObject ITManager;
  public bool statusMg = true;
  public bool statusMg2 = true;
  public bool statusMg3 = true;
   public bool statusMg4 = true;
  public bool statusMg5 = true;
   public bool statusMg6 = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //  Instantiate(EngManager);
    }

    // Update is called once per frame
    void Update()
    {

         if(Input.GetKeyDown(KeyCode.Alpha1)){
          if(statusMg){
            EngManager.SetActive(false);
            CNManager.SetActive(false);
            RuManager.SetActive(true);
           statusMg = false;
          }

          else{
              EngManager.SetActive(true);
              RuManager.SetActive(false);
              statusMg = true;
            
          }

        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
          if(statusMg2 ){
            EngManager.SetActive(false);
            RuManager.SetActive(false);
            CNManager.SetActive(true);
           statusMg2 = false;
          }

          else{
              EngManager.SetActive(true);
              CNManager.SetActive(false);
              statusMg2 = true;
            
          }
        }

           if(Input.GetKeyDown(KeyCode.Alpha3)){
          if(statusMg3 ){
            EngManager.SetActive(false);
            RuManager.SetActive(false);
            CNManager.SetActive(false);
            ESManager.SetActive(true);
           statusMg3 = false;
          }

          else{
              EngManager.SetActive(true);
               ESManager.SetActive(false);
              statusMg3 = true;
            
          }
        }

          if(Input.GetKeyDown(KeyCode.Alpha4)){
          if(statusMg4 ){
            EngManager.SetActive(false);
            RuManager.SetActive(false);
            CNManager.SetActive(false);
            ESManager.SetActive(false);
            DEManager.SetActive(true);
           statusMg4 = false;
          }

          else{
              EngManager.SetActive(true);
              DEManager.SetActive(false);
              statusMg4 = true;
            
          }
        }

          if(Input.GetKeyDown(KeyCode.Alpha5)){
          if(statusMg5 ){
            EngManager.SetActive(false);
            RuManager.SetActive(false);
            CNManager.SetActive(false);
            ESManager.SetActive(false);
            DEManager.SetActive(false);
            FRManager.SetActive(true);
           statusMg5 = false;
          }

          else{
              EngManager.SetActive(true);
              FRManager.SetActive(false);
              statusMg5 = true;
            
          }
        }

         if(Input.GetKeyDown(KeyCode.Alpha6)){
          if(statusMg6 ){
            EngManager.SetActive(false);
            RuManager.SetActive(false);
            CNManager.SetActive(false);
            ESManager.SetActive(false);
            DEManager.SetActive(false);
            FRManager.SetActive(false);
            ITManager.SetActive(true);
           statusMg6 = false;
          }

          else{
              EngManager.SetActive(true);
              ITManager.SetActive(false);
              statusMg6 = true;
            
          }
        }
    }

 
}
