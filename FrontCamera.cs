using UnityEngine;

public class FrontCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 CamOffset  = new Vector3(0 , 3.48f , 7.82f);
    private Transform target;
    public string Tname = "Tiger" ;
    void Start()
    {
      target = GameObject.Find(Tname).transform;
        
    }

    void Destroy() {
      Tname = "Tiger";
    }

    // Update is called once per frame
   

    void LateUpdate() {
      this.transform.position = target.TransformPoint(CamOffset);
      this.transform.LookAt(target);
    }
}
