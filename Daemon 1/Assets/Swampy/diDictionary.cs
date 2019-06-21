using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System;
using System.Linq;


[Serializable]
public class UniqueID
{
  Guid _guid;
}

[Serializable]
public class diDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
  [SerializeField] private List<TKey> keys = new List<TKey>();
  [SerializeField] private List<TValue> values = new List<TValue>();

  public void OnBeforeSerialize() {
    keys.Clear();
    values.Clear();
    foreach ( KeyValuePair<TKey,TValue> pair in this) {
      keys.Add(pair.Key);
      values.Add(pair.Value);
    }
  }

  public void OnAfterDeserialize() {
    Clear();
    if(keys.Count != values.Count) {
      throw new Exception(String.Format("There are {0} and {1} keys", keys.Count, values.Count));
    }
    for(int i = 0; i < Keys.Count; ++i) {
      Add(keys[i], values[i]);
    }
  }
}
