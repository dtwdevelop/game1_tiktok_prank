using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera cam1;
    private Camera cam2;
    public GameObject Spawn;
    public GameObject SpawnPlatform;
    [SerializeField] AudioClip[] music;
     [SerializeField] AudioClip[] music2;
   
      public bool gameStatus = false;
      public float SpawnTime  = 45f;
       private AudioSource[] Audsources;
       private bool status = false;
       private bool status2 = false;
       private bool status3 = false;
       void Start()
    {
        cam1 = GameObject.Find("Camera").GetComponent<Camera>();
        cam2 = GameObject.Find("MyCamera").GetComponent<Camera>();
        cam1.enabled = true;
        cam2.enabled = false;
        Audsources = gameObject.GetComponentsInChildren<AudioSource>();
         
      
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.V)){
          HideVideo("CubeM");
          

         }

         if(Input.GetKeyDown(KeyCode.Alpha1)){
            HideVideo("CubeM");
              StartCoroutine(OnPlaySong(3));
           cam1.enabled = cam2.enabled;
           cam2.enabled = true;
           gameStatus = true;
           if(Spawn != null){
             Spawn.SetActive(true);
             StartCoroutine(OnSpanWait(SpawnTime));
           }
          

         }

           if(Input.GetKeyDown(KeyCode.Alpha2)){
           SceneManager.LoadScene("Island");

         }
              if(Input.GetKeyDown(KeyCode.Alpha3)){
                if(!status){
                   StartCoroutine(OnPlaySong(0));
                   status = !status;
                }
                else{
                  StartCoroutine(OnPlaySongStop(0));
                   status = !status;
                }
         

         }

          if(Input.GetKeyDown(KeyCode.Alpha4)){
            if(!status2){
              StartCoroutine(OnPlaySong(1));
              status2 = !status2;
            }
            else{
              StartCoroutine(OnPlaySongStop(1));
               status2 = !status2;
            }
        }

           if(Input.GetKeyDown(KeyCode.Alpha5)){
            if(!status3){
          
              StartCoroutine(OnPlaySongRandom(2));
              status3 = !status3;
            }
            else{
              StartCoroutine(OnPlaySongStop(2));
               status3 = !status3;
            }
        }

          
        
    }

    IEnumerator OnPlaySong(int n)
  {
    yield return new WaitForSeconds(0.1f);
      
      if (Audsources[n].clip == null)
        Audsources[n].clip = music[n];
        Audsources[n].Play();
  }

    IEnumerator OnPlaySongRandom(int n )
  {
    yield return new WaitForSeconds(0.1f);
      int  r =  Random.Range(0, music2.Length);
      if (Audsources[n].clip == null){
          Audsources[n].clip = music2[r];
         Audsources[n].Play();
      }
      
      else{
         Audsources[n].clip = null;
         Audsources[n].clip = music2[r];
         Audsources[n].Play();

      }
  }

   


    IEnumerator OnPlaySongStop(int n)
  {
    yield return new WaitForSeconds(0.1f);
      
      if (Audsources[n].clip != null)
       Audsources[n].Stop();
  }


      IEnumerator OnSpanWait(float t)
  {
    yield return new WaitForSeconds(t);
       SpawnPlatform.SetActive(true);
       Instantiate(SpawnPlatform, SpawnPlatform.gameObject.transform.position, Quaternion.identity);
  }

    

  void OnDestroy()
  {
    gameStatus = false;
  }

  void HideVideo(string name) {
        string VideoName = name;
     // Animator anim = target.GetComponent<Animator>();
      // if( GameObject.Find("Logo") != null ){
      //    GameObject.Find("Logo").SetActive(false);
      // }

       if( GameObject.Find(VideoName) != null ){
         GameObject.Find(VideoName).SetActive(false);
      }
    }
}
