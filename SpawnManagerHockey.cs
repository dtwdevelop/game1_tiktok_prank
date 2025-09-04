
using UnityEngine;

public class SpawnManagerHockey : MonoBehaviour
{
   public GameObject pluck;

   public GameObject AiPingin;
    public GameObject AiBear;

 
  public int TotalSizeW  = 99;
  public int TotalSizeH  = 99;
  public int TotalBall  =  150 ;
  public float Xspace = 0;
  public float Yspace = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        RamdomElement(pluck , TotalBall);
      
          RamdomElement(AiPingin , TotalBall );
            RamdomElement(AiBear , TotalBall );
    }

    // Update is called once per frame
    void Update()
    {
       // Invoke("RandomElement" , 1f * Time.deltaTime);
      
    }

    void RamdomElement(GameObject name , int total){
       for(int i =0 ; i < total ; i++){
        float x  = Random.Range(0, TotalSizeW);
        float z = Random.Range(0, TotalSizeH);
        var pos = new Vector3(x + Xspace, 1.6f, z + Yspace);
        Instantiate(name, pos, Quaternion.identity);
       // Debug.Log(pos);

       }
     
    }
}
