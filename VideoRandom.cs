using UnityEngine;
using UnityEngine.Video;
using System.Collections;
public class VideoRandom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] VideoClip[] clips;
    VideoPlayer video ;
     VideoPlayer video1 ;
    VideoPlayer video2 ;
    void Start()
    {
      video =  GameObject.Find("VideoScreen").GetComponent<UnityEngine.Video.VideoPlayer>();
      video1 =  GameObject.Find("VideoScreen1").GetComponent<UnityEngine.Video.VideoPlayer>();
      video2 =  GameObject.Find("VideoScreen2").GetComponent<UnityEngine.Video.VideoPlayer>();
      
      StartCoroutine(PlayVideos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator PlayVideos()
  {
    yield return new WaitForSeconds(1f);
    video.clip = clips[Random.Range(0, clips.Length)];
     video1.clip = clips[Random.Range(0, clips.Length)];
     video2.clip = clips[Random.Range(0, clips.Length)];
    video.Play();
    video1.Play();
    video2.Play();
  }
}
