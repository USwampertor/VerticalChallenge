using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class diSoundModule : MonoBehaviour
{

  public static diSoundModule _instance = null;

  public int m_poolSize;

  public List<diAudio> m_SFX;
  public List<diAudio> m_MUSIC;

  private Dictionary<eAudio, AudioClip> m_sfxList = new Dictionary<eAudio, AudioClip>();
  private Dictionary<eAudio, AudioClip> m_musicList = new Dictionary<eAudio, AudioClip>();

  private AudioSource m_musicSource;
  private List<AudioSource> m_audioSourcePool = new List<AudioSource>();
  private Dictionary<eAudio, AudioClip> m_narrationList = new Dictionary<eAudio, AudioClip>();
  private Dictionary<eAudio, AudioClip> m_villagerList = new Dictionary<eAudio, AudioClip>();

  /// <summary>
  /// Initializes the Module
  /// </summary>
  void
  Start() {

    if (!Debug.isDebugBuild) {
      GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
    LoadSceneMusic();
  }

  /// <summary>
  /// Checks if the module has been already started up
  /// </summary>
  /// <returns></returns>
  public bool IsStarted() {
    return _instance != null;
  }

  /// <summary>
  /// When destroying the module, it sets the instance to null, to be able to be created again
  /// </summary>
  private void OnDestroy() {
    _instance = null;
  }

  /// <summary>
  /// Starts up the module and checks if it is already created or not
  /// </summary>
  private void Awake() {

    if (diSoundModule._instance != null) {
      Destroy(gameObject);
      Debug.LogWarning("Object is already built, There shouldn't be another instance");
      return;
    }

    _instance = this;
    DontDestroyOnLoad(gameObject);


    m_musicSource = gameObject.AddComponent<AudioSource>();
    for(int i = 0; i < m_SFX.Count; ++i) {
      m_sfxList.Add(m_SFX[i].m_name, m_SFX[i].m_clip);
    }
    for (int i = 0; i < m_MUSIC.Count; ++i) {
      m_musicList.Add(m_MUSIC[i].m_name, m_MUSIC[i].m_clip);
    }
    for (int i = 0; i < m_poolSize; ++i) {
      GameObject child = new GameObject();
      AudioSource tmp = child.gameObject.AddComponent<AudioSource>();
      child.transform.SetParent(gameObject.transform);
      m_audioSourcePool.Add(tmp);
    }
    m_villagerList.Clear();
    m_narrationList.Clear();
  }

  /// <summary>
  /// Update used for fading and changing audio sources
  /// </summary>
  void Update() {

  }


  /// <summary>
  /// Gives the requester an audio source if it doesn't have one, and plays the Effect given
  /// </summary>
  /// <param name="name"> the name of the audio to play</param>
  /// <param name="position"> the position of the audiosource to be played for 3D</param>
  /// <param name="source"> the transform of the requester </param>
  public void PlaySFX(eAudio name) {
    //Checks for the ENUM if it is registered on the AUDIONAME
    //Should be, but just in case
    if (m_sfxList[name] != null) {
      for (int i = 0; i < m_audioSourcePool.Count; ++i) {
        if (!m_audioSourcePool[i].isPlaying) {
          m_audioSourcePool[i].PlayOneShot(m_sfxList[name]);
        }
      }
    }
  }

      
  /// <summary>
  /// Gives the requester an audio source if it doesn't have one, and plays the Effect given
  /// </summary>
  /// <param name="name"> the name of the audio to play</param>
  /// <param name="position"> the position of the audiosource to be played for 3D</param>
  /// <param name="source"> the transform of the requester </param>
  public void PlaySFXLoop(eAudio name){
    //Checks for the ENUM if it is registered on the AUDIONAME
    //Should be, but just in case
    if (m_sfxList[name] != null){
      for (int i = 0; i < m_audioSourcePool.Count; ++i){
        if (!m_audioSourcePool[i].isPlaying){
          m_audioSourcePool[i].clip = m_sfxList[name];
          m_audioSourcePool[i].loop = true;
          m_audioSourcePool[i].Play();
        }
      }
    }
  }

  public void StopSFX(eAudio name){
    if (m_villagerList[name] != null){
      for (int i = 0; i < m_audioSourcePool.Count; ++i){
        if (m_audioSourcePool[i].clip == m_sfxList[name]){
          m_audioSourcePool[i].Stop();
        }
      }
    }
  }


  /// <summary>
  /// Loads the music of the level by Unity Scene index
  /// </summary>
  private void LoadSceneMusic() {
    if (SceneManager.GetActiveScene().buildIndex == 2) { PlayMusic(eAudio.MENU); }
    else if (SceneManager.GetActiveScene().buildIndex == 4) { PlayMusic(eAudio.TRISTRAM); }
    else if (SceneManager.GetActiveScene().buildIndex == 5) { PlayMusic(eAudio.CHAPPEL); }
  }

  /// <summary>
  /// Plays The catchphrase of the villager
  /// </summary>
  /// <param name="name"></param>
  public void PlayVillager(eAudio name) {
    if (m_villagerList[name] != null) {
      for (int i = 0; i < m_audioSourcePool.Count; ++i) {
        if (!m_audioSourcePool[i].isPlaying) {
          m_audioSourcePool[i].loop = false;
          m_audioSourcePool[i].clip = m_villagerList[name];
          m_audioSourcePool[i].Play();
        }
      }
    }
  }

  public void StopVillager(eAudio name)
  {
    if (m_villagerList[name] != null) {
      for (int i = 0; i < m_audioSourcePool.Count; ++i) {
        if (m_audioSourcePool[i].clip == m_villagerList[name]) {
          m_audioSourcePool[i].Stop();
        }
      }
    }
  }

  /// <summary>
  /// Plays a music name from the music source object
  /// </summary>
  /// <param name="name"> the name of the music to perform </param>
  /// <param name="crossfade"> the time to crossfade 
  /// between the active music and the new one </param>
  public void PlayMusic(eAudio name) {
    if (m_musicList[name] != null) {
      if (m_musicSource.clip != m_musicList[name] && !m_musicSource.isPlaying) {
        m_musicSource.clip = m_musicList[name];
        m_musicSource.Play();
      }
    }
  }

  /// <summary>
  /// Stops a music name from the music source object
  /// </summary>
  /// <param name="name"> the name of the music to perform </param>
  /// <param name="crossfade"> the time to crossfade 
  /// between the active music and the new one </param>
  public void StopMusic(eAudio name) {
    if (m_musicList[name] != null) {
      if (m_musicSource.clip == m_musicList[name] && m_musicSource.isPlaying) {
        m_musicSource.Stop();
      }
    }
  }

  /// <summary>
  /// Plays a music name from the music source object
  /// </summary>
  /// <param name="name"> the name of the music to perform </param>
  /// <param name="crossfade"> the time to crossfade 
  /// between the active music and the new one </param>
  public void PlayNarration(eAudio name)
  {
    if (m_narrationList[name] != null) {
      for (int i = 0; i < m_audioSourcePool.Count; ++i) {
        if (!m_audioSourcePool[i].isPlaying) {
          m_audioSourcePool[i].loop = false;
          m_audioSourcePool[i].clip = m_narrationList[name];
          m_audioSourcePool[i].Play();
        }
      }
    }
  }

  public void StopNarration(eAudio name)
  {
    if (m_narrationList[name] != null) {
      for (int i = 0; i < m_audioSourcePool.Count; ++i) {
        if (m_audioSourcePool[i].clip == m_narrationList[name]) {
          m_audioSourcePool[i].Stop();
        }
      }
    }
  }

  /// <summary>
  /// This is the function that objects that want to use a specific music or sound effect in the
  /// level will use to register the sound in the sound manager.
  /// </summary>
  /// <param name="audio"> The audio object to register </param>
  public void RegisterToManager(diAudio audio)
  {
    if (eAudioType.NONE == audio.m_type || audio.m_name == eAudio.NONE) {
      return;
    }
    else if (eAudioType.MUSIC == audio.m_type) {
      if(m_musicList.Count == 0) {
        m_musicList.Add(audio.m_name, audio.m_clip);
      }
      else if (!m_musicList.ContainsKey(audio.m_name)) {
        m_musicList.Add(audio.m_name, audio.m_clip);
      }
    }
    else if (eAudioType.VILLAGER == audio.m_type) {
      if(m_villagerList.Count == 0) {
        m_villagerList.Add(audio.m_name, audio.m_clip);
      }
      else if (!m_villagerList.ContainsKey(audio.m_name)) {
        m_villagerList.Add(audio.m_name, audio.m_clip);
      }
    }
    else if (eAudioType.NARRATION == audio.m_type) {
      if(m_narrationList.Count == 0) {
        m_narrationList.Add(audio.m_name, audio.m_clip);
      }
      else if (!m_narrationList.ContainsKey(audio.m_name)) {
        m_narrationList.Add(audio.m_name, audio.m_clip);
      }
    }
    else if (eAudioType.SFX == audio.m_type) {
      if(m_sfxList.Count == 0) {
        m_sfxList.Add(audio.m_name, audio.m_clip);
      }
      else if (!m_sfxList.ContainsKey(audio.m_name)) {
        m_sfxList.Add(audio.m_name, audio.m_clip);
      }
    }
  }

}
