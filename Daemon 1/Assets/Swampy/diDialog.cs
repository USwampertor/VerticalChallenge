using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum eDialogType
{
  NONE = 0,
  ROOT,
  GOSSIP,
  PURCHASE,
  SELDOM,
  SYSTEM,
  ITEM,
  ACTION,
  NARRATION,
  HEALING,
  EXIT
}


[System.Serializable]
public class diDialog
{
  public int id;
  public string m_name;
  public AudioClip m_audio;
  public eDialogType m_type;
  [TextArea]
  public string m_gossip;
  public List<diDialog> m_options;
  public diItem m_item;
}
