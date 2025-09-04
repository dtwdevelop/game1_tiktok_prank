
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject apple;
  public GameObject banana;
  public GameObject watermelon;
  public GameObject football;
  public GameObject orange;
   public GameObject AiPingin;
    public GameObject AiBear;

  public GameObject strawberry;
  public int TotalSizeW  = 99;
  public int TotalSizeH  = 99;
  public int TotalBall  =  150 ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  RamdomElement(apple , 80);
      //  RamdomElement(orange , 80);
      //  RamdomElement(banana , 50);
      //  RamdomElement(watermelon , 80);
        RamdomElement(football , TotalBall);
      //   RamdomElement(strawberry , 80);
          RamdomElement(AiPingin , 20);
            RamdomElement(AiBear , 20);
    }

    // Update is called once per frame
    void Update()
    {
       // Invoke("RandomElement" , 1f * Time.deltaTime);
      
    }

    void RamdomElement(GameObject name , int total){
       for(int i =0 ; i < total ; i++){
        float x  = Random.Range(0,TotalSizeW);
        float z = Random.Range(0,TotalSizeH);
        var pos = new Vector3(x, 0.6f, z);
        Instantiate(name, pos, Quaternion.identity);
       // Debug.Log(pos);

       }
     
    }
}
