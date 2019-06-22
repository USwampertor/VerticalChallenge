using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eQuestState
{
  INACTIVE = 0,
  ACTIVE,
  COMPLETED,
  END
}

public class diQuest : MonoBehaviour
{
  string m_name;
  int m_ID;
  eQuestState m_state;
  [TextArea]
  string m_log;
}
