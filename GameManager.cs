using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using  System.Text.RegularExpressions ;
// using System;
// using System.Diagnostics;
public class GameManager : MonoBehaviour
{
  public int total = 0;
  public string msm = "";
  public bool status = false;
  public bool say = false;
  private GameObject obj;
  private GameObject obj2;
   private Camera cam1;
  private Camera cam2;
  private Camera cam3;
  private Camera aicam;
  private GameObject SoundMg;
   private GameObject SoundMg2;
  private bool isLogo = false;
  
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      obj  = GameObject.Find("UserBtn");
      obj2   = GameObject.Find("UserBtnStop");
     // MsChange();
    cam1 = GameObject.Find("Camera").GetComponent<Camera>();
    cam2 = GameObject.Find("MyCamera").GetComponent<Camera>();
    cam3 = GameObject.Find("FrontCamera").GetComponent<Camera>();
    aicam = GameObject.Find("AICameraAnimal").GetComponent<Camera>();
   


    // var p = new Process() ;
    // p.StartInfo.Arguments = "/C python fileWithCommands.js";

    }

    void buttonClick(){
      Button btn =  obj.GetComponent<Button>();
      btn.onClick.AddListener(Clicked);
      btn.onClick.Invoke();

    }

    void buttonStopClick(){
      Button btn =  obj2.GetComponent<Button>();
      btn.onClick.AddListener(Clicked);
      btn.onClick.Invoke();

    }
    
    
    public void Clicked(){
      Debug.Log("Btn user clicked");
    }

    // Update is called once per frame
    void Update()
    {
       // MsChange();
         if(Input.GetKeyDown(KeyCode.V)){
      cam1.enabled = !cam1.enabled;
       cam2.enabled = !cam2.enabled;
     
    }
         if(Input.GetKeyDown(KeyCode.B)){
       cam2.enabled = !cam2.enabled;
      cam3.enabled = !cam3.enabled;
     
    }

  

     if (Input.GetKeyDown(KeyCode.M))
    {
       isLogo  = !isLogo;
       if( GameObject.Find("Logo") != null ){
         GameObject.Find("Logo").SetActive(false);
       }
      
      
    }

      if (Input.GetKeyDown(KeyCode.Z))
    {
      
       if ( GameObject.Find("AICameraAnimal").GetComponent<AICamera>() != null){
          Destroy(GameObject.Find("AICameraAnimal").AddComponent<AICamera>());
       }
       else{
          GameObject.Find("AICameraAnimal").AddComponent<AICamera>();
       }
        aicam.enabled = !aicam.enabled;
     
      
    }

    }
    void Destroy(){
      msm = "";
       say = false;
        cam1.enabled = true;
       cam2.enabled = false;
    }

    public void MsChange(){
    //  msm = "tiger run";
      string command = @"tiger\s+run";
      string command2 = @"tiger\s+stop";
      string command3 = @"tiger\s+say";
      Regex regex = new Regex(command);
      Regex regex2 = new Regex(command2);
       Regex regex3 = new Regex(command3);
     

      if(regex.IsMatch(msm)){
        Debug.Log($"run {msm}");
        buttonClick() ;
        status = true;
      
      }
       else if(regex2.IsMatch(msm)){
        Debug.Log($"stop {msm}");
        buttonStopClick() ;
         status = false;
         say = false;
      }
       else if(regex3.IsMatch(msm)){
        Debug.Log($"say {msm}");
        buttonClick() ;
         say = true;
      }

      else{
        Debug.Log($"invalid command {msm}");
          say = false;
      }
    }
}
