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
  ATTACK,
  ADRIA_INTRO,
  ADRIA_GOSSIP,
  CAIN_INTRO,
  CAIN_GOSSIP,
  GRIMWOLD_INTRO,
  GRIMWOLD_GOSSIP,
  OGDEN_GOSSIP,
  WOUNDED_GOSSIP,
  PEGLEG_INTRO,
  PEGLEG_GOSSIP,
  PEPPY_GOSSIP
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
