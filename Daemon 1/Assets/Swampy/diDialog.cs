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
  SHOP,
  SELL,
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
  public diAudio m_audio;
  public eDialogType m_type;
  [TextArea]
  public string m_gossip;
  public List<diDialog> m_options;
  public diItem m_item;

  public void RegisterAudio() {
    diSoundModule._instance.RegisterToManager(m_audio);
    foreach(diDialog dialog in m_options) {
      dialog.RegisterAudio();
    }
  }

}
