using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Live.Stream;
using UnityEngine.UI;
using TMPro;

public class UserControll : MonoBehaviour
{
  float speed = 20f;
  float move = 5f;

  private float vinput;
  private float hinput;
  Animator animator;
  Rigidbody rbBody;
  public float rotate;
  public float rotateSpeed = 150f;

  private bool moveStatus = false;

 
  private  GameManager gM;

  //Repeat Unity Engine
  void Start()
  {
    animator = GetComponent<Animator>();
    rbBody = gameObject.GetComponentInChildren<Rigidbody>();
    animator.SetTrigger("walk");
   
    gM  = GameObject.Find("GManager").GetComponent<GameManager>();
   
  }

  void Destroy()
  {

   
    moveStatus = false;
   
  }



  // Update is called once per frame
  void Update()
  {
    vinput = 0.0f * speed;
    hinput = 0 * rotateSpeed;
   

  

    
    if(gM.say){
      animator.SetTrigger("say");
    }
    else{
       animator.SetTrigger("idle");
    }
      MoveAnimal ();

    

   /** transform.Rotate(Vector3.up * hinput * Time.deltaTime);
    transform.Translate(Vector3.forward * vinput * Time.deltaTime);
 **/

  }

 


  void FixedUpdate(){
  
    Vector3 rotation = Vector3.up * hinput;
    Quaternion angle  = Quaternion.Euler(rotation * Time.deltaTime);
    rbBody.MovePosition(transform.transform.position + transform.forward * vinput * Time.deltaTime);
    rbBody.MoveRotation(rbBody.rotation * angle);

  }

 private void MoveAnimal (){
    if(gM.status){
        vinput += move;
        animator.SetTrigger("run");
    }
    else{
       animator.SetTrigger("walk");
    }
  }

}
