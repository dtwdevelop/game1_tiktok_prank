

using UnityEngine;

public class CubeControll : MonoBehaviour
{
  public float rotateSpeed = 160f;
  private float yinput ;
   private float xinput ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      yinput = Input.GetAxis("Vertical") * rotateSpeed;
      xinput = Input.GetAxis("Horizontal") * rotateSpeed;
      Vector3 xvector =  Vector3.up * xinput * Time.deltaTime;
      Vector3 yvector =  Vector3.forward * yinput * Time.deltaTime;
      transform.Rotate(xvector);
       transform.Rotate(yvector);
        
    }
}
