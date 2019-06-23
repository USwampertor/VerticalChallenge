using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum eAudio
{
  NONE = 0,
  CHAPPEL,
  TRISTRAM,
  MENU,
  BARMAID_INTRO,
  BARMAID_GOSSIP,
  WALK_GRASS,
  ATTACK
}

[System.Serializable]
public enum eAudioType
{
  NONE = 0,
  MUSIC,
  SFX,
  VILLAGER,
  NARRATION
};


[System.Serializable]
public class diAudio
{
  public AudioClip m_clip;
  public eAudio m_name;
  public eAudioType m_type;
}
