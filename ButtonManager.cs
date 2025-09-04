using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
  private GameObject target;
  private bool  SceneIsForest  = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      DeletePlayerControll();
    }
    public void OnTigerBtnClick() {
      
      SetComponent("Tiger");
      
    }

     public void OnBearBtnClick() {
      
      SetComponent("Bear");
      
    }

     public void OnDeerBtnClick() {
       SetComponent("Deer");
    }

     public void OnPinguinBtnClick() {
       SetComponent("Pinguin");
    }

     public void OnDogBtnClick() {
       SetComponent("Dog");
    }

     public void OnChickenBtnClick() {
       SetComponent("Chicken");
    }

      public void OnHorseBtnClick() {
       SetComponent("ElephantWalk");
    }

       public void OnKittyBtnClick() {
       SetComponent("Kitty");
    }

       public void OnWolfBtnClick() {
       SetComponent("WolfOld");
    }

      public void OnUserClick() {
       SetComponentUser("Tiger");
    }

      public void OnUserStopUserClick() {
       DeletePlayerControllUser();
    }

    public void ResetScene(){
      
         SceneManager.LoadScene("SampleScene1");
       
      
    }

    public void SendCommandClick(){
      TMP_InputField Ttext = GameObject.Find("CommandInput").GetComponentInChildren<TMP_InputField>();
       GameManager Gm =  GameObject.Find("GManager").GetComponent<GameManager>();
       Gm.msm  = Ttext.text;
       Gm.MsChange();

    }

    private void SetComponent(string name){
      string VideoName = "CubeVideo";
     // Animator anim = target.GetComponent<Animator>();
      // if( GameObject.Find("Logo") != null ){
      //    GameObject.Find("Logo").SetActive(false);
      // }

       if( GameObject.Find(VideoName) != null ){
         GameObject.Find(VideoName).SetActive(false);
      }
     
       DeletePlayerControll();
       target = GameObject.Find(name);
       target.AddComponent<Player>();
       
       CameraFollow cam = GameObject.Find("MyCamera").AddComponent<CameraFollow>();
         FrontCamera camFront  = GameObject.Find("FrontCamera").AddComponent<FrontCamera>();
       if(name == "ElephantWalk"){
        cam.CamOffset  = new Vector3(0, 0.0500000007f, -0.25999999f );
        camFront.CamOffset = new Vector3(0, 0.0500000007f, 0.25999999f );
       }
     
       cam.Tname = name;
       camFront.Tname = name;
      // Debug.Log($"Controll now on animal {name}");
    
    }

     private void SetComponentUser(string name){
     // Animator anim = target.GetComponent<Animator>();
      
       DeletePlayerControllUser();
       target = GameObject.Find(name);
       target.AddComponent<UserControll>();
       
       CameraFollow cam = GameObject.Find("MyCamera").AddComponent<CameraFollow>();
       cam.Tname = name;
       Debug.Log($"Controll now on animal {name}");
    
    }

    

    
    

    private void DeletePlayerControll(){
      if(target != null){
        Player scr =  target.GetComponent<Player>();
       CameraFollow camSc = GameObject.Find("MyCamera").GetComponent<CameraFollow>();
       FrontCamera camFront  = GameObject.Find("FrontCamera").GetComponent<FrontCamera>();
       if(scr != null){
         Destroy(scr);
         Destroy(camSc);
          if (camFront != null){
        Destroy(camFront);
       }
       }
      
       }
     
    }

    private void DeletePlayerControllUser(){
      if(target != null){
         UserControll scr =  target.GetComponent<UserControll>();
       CameraFollow camSc = GameObject.Find("MyCamera").GetComponent<CameraFollow>();
       if(scr != null){
         Destroy(scr,1f);
         Destroy(camSc);
       }
       }
     
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
