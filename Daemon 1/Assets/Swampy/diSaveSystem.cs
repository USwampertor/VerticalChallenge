using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class diSaveSystem
{

  private static string m_saveFolder;
  private static string m_extension = ".data";
  private static string m_extensionType = "*.data";

  public static void SaveProfile() {

    BinaryFormatter formatter = new BinaryFormatter();
    string path = Path.Combine(m_saveFolder, m_extension);
    FileStream file = new FileStream(path, FileMode.Create);

    diProfile profile = new diProfile();

    formatter.Serialize(file, profile);
    file.Close();

  }

  public static void Initialize() {
    m_saveFolder = Path.Combine(Application.persistentDataPath, "/Saves/");
    if (!Directory.Exists(m_saveFolder)) {
      Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "/Saves"));
    }
  }

  public static void CreateProfile(string newName) {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Path.Combine(m_saveFolder,newName,m_extension);
    FileStream file = new FileStream(path, FileMode.Create);

    diProfile profile = new diProfile();

    formatter.Serialize(file, profile);
    file.Close();
  }

  public static List<string> GetProfiles() {

    List<string> profiles = new List<string>();

    DirectoryInfo directory = new DirectoryInfo(m_saveFolder);
    FileInfo[] files = directory.GetFiles(m_extensionType);

    foreach (FileInfo file in files) {
      profiles.Add(file.Name);
    }
    return profiles;
  }

  public static void DeleteProfile(string name) {
    string path = Path.Combine(m_saveFolder, name, m_extension);
    File.Delete(path);
  }

  public static diProfile LoadProfile(string name) {

    string path = Path.Combine(m_saveFolder, name, m_extension);

    if (File.Exists(path)) {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      diProfile profile;
      profile = formatter.Deserialize(stream) as diProfile;

      return profile;
    }
    throw new System.Exception("Couldn't Load given profile. Either it has " +
                               "been tampered with or it was corrupted during" +
                               "a saving state");
    

  }

}
