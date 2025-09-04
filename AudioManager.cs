using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  private AudioSource ASor;
  [SerializeField] AudioClip[] clips;
  [SerializeField] AudioClip[] clipsAnimal;
  [SerializeField] AudioClip clip;
  [SerializeField] AudioClip clipSup;
  [SerializeField] AudioClip bye;
  [SerializeField] AudioClip hiIm;
  [SerializeField] AudioClip techno;
   [SerializeField] AudioClip[] MYname;
   [SerializeField] AudioClip MYTeam;
    [SerializeField] AudioClip plan;
    [SerializeField] AudioClip live;
    [SerializeField] AudioClip from;
    public bool LangFlag = true;

  void Start()
  {
    string name = LangFlag == true ? "AudioSong" : "AudioSongCN";
    // ASor = GameObject.Find(name).GetComponentInChildren<AudioSource>();
     ASor = gameObject.GetComponentInChildren<AudioSource>();



  }

  // Update is called once per frame
  void Update()
  {

    if (Input.GetKeyDown(KeyCode.P))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = clip;
      StartCoroutine(OnPlaySongWhen(true));

    }


    if (Input.GetKeyDown(KeyCode.L))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = clipSup;
      StartCoroutine(OnPlaySongWhen(true));

    }

    if (Input.GetKeyDown(KeyCode.I))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = bye;
      StartCoroutine(OnPlaySongWhen(true));

    }

    if (Input.GetKeyDown(KeyCode.Y))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = hiIm;
      StartCoroutine(OnPlaySongWhen(true));

    }

    if (Input.GetKeyDown(KeyCode.T))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = live;
      StartCoroutine(OnPlaySongWhen(true));

    }
    if (Input.GetKeyDown(KeyCode.H))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = techno;
      StartCoroutine(OnPlaySongWhen(true));

    }
       if (Input.GetKeyDown(KeyCode.U))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = MYname[Random.Range(0, MYname.Length)];
     
      StartCoroutine(OnPlaySongWhen(true));

    }
       if (Input.GetKeyDown(KeyCode.J))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = MYTeam;
      StartCoroutine(OnPlaySongWhen(true));

    }

        if (Input.GetKeyDown(KeyCode.Q))
    {
      ASor.Stop();
      ASor.clip = null;
      ASor.clip = plan;
      StartCoroutine(OnPlaySongWhen(true));

    }

    if (Input.GetKeyDown(KeyCode.O))
    {
      ASor.Stop();
      ASor.playOnAwake = false;
      ASor.clip = null;

    }

    if (Input.GetKeyDown(KeyCode.R))
    {
      ASor.Stop();
      ASor.clip = null;
      StartCoroutine(PlayVoiceAnimal());

    }



    if (Input.GetKeyDown(KeyCode.K))
    {
      ASor.Stop();
      ASor.clip = null;
      StartCoroutine(PlayVoice());
    }

     if (Input.GetKeyDown(KeyCode.E))
    {
     ASor.Stop();
      ASor.clip = null;
      ASor.clip = from;
      StartCoroutine(OnPlaySongWhen(true));
    }


  }

  IEnumerator OnPlaySongWhen(bool status)
  {
    yield return new WaitForSeconds(0.1f);
    if (status)
    {
      if (ASor.clip == null)
        ASor.clip = clip;

      ASor.Play();
      // ASor.playOnAwake = true;
      // StartCoroutine(Clear());
    }
  }

  IEnumerator PlayVoice()
  {
    yield return new WaitForSeconds(0.1f);
    ASor.clip = clips[Random.Range(0, clips.Length)];
    ASor.Play();
  }

  IEnumerator PlayVoiceAnimal()
  {
    yield return new WaitForSeconds(0.1f);
    ASor.clip = clipsAnimal[Random.Range(0, clipsAnimal.Length)];
    ASor.Play();
  }

  IEnumerator Clear()
  {
    yield return new WaitForSeconds(0.1f);
    ASor.clip = null;
  }

}
