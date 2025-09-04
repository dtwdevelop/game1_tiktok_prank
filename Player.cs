using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Live.Stream;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
  float speed = 10f;
  public float jumpForce = 10f;
  private float vinput;
  private float hinput;
  Animator animator;
  Rigidbody rbBody;
  public float rotate;
  public float rotateSpeed = 150f;

  public bool moveStatus = false;
   private bool isGrounded;

//Repeat Unity Engine
  void Start()
  {
    animator = GetComponent<Animator>();
    rbBody = gameObject.GetComponentInChildren<Rigidbody>();
    animator.SetTrigger("walk");
  }

  void Destroy()
  {


    moveStatus = false;

  }



  // Update is called once per frame
  void Update()
  {
   
    

  /** transform.Rotate(Vector3.up * hinput * Time.deltaTime);
     transform.Translate(Vector3.forward * vinput * Time.deltaTime);
  **/

  }
  void FixedUpdate()
  {
    vinput = Input.GetAxis("Vertical") * speed;
    hinput = Input.GetAxis("Horizontal") * rotateSpeed;
    if (Input.GetButtonDown("Vertical"))
    {

      animator.SetTrigger("run");
    }

    if (Input.GetButtonUp("Vertical"))
    {
      animator.SetTrigger("walk");
    }

     if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    Vector3 rotation = Vector3.up * hinput;
    Quaternion angle = Quaternion.Euler(rotation * Time.deltaTime);
    rbBody.MovePosition(transform.transform.position + transform.forward * vinput * Time.deltaTime);
    rbBody.MoveRotation(rbBody.rotation * angle);

  }

   private void Jump()
    {
        rbBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            isGrounded = false;
        }
    }



}
