using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

public class SerialisationComponent : MonoBehaviour
{
    
    // Deserialise the parent on enable
    private void OnEnable() {
        DeserialiseSelf();
    }


    // Save the object when disabled
    private void OnDisable() {
        SerialiseSelf();
    }

    // Serialise
    public void SerialiseSelf() {
        // Create a binary formatter
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        // Determine Path name
        string path = Path.Combine(Application.persistentDataPath, PlayerPrefs.GetString("FarmosaurSave", "Default"), "_" + this.gameObject.name + ".pso");

        // Create a filestream using the save path for this item
        FileStream file = File.Create(path);

        // Serialise object
        binaryFormatter.Serialize(file, EditorJsonUtility.ToJson(this.gameObject));
        file.Close();
        // !Remember to perform any deregistration as required for the attached object!
    }

    public void DeserialiseSelf() {
        // Determine Path name
        string path = Path.Combine(Application.persistentDataPath, PlayerPrefs.GetString("FarmosaurSave", "Default"), "_" + this.gameObject.name + ".pso");

        // Search for serialised data
        if (File.Exists(path)) {
            // Create new binary formatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            // Open file
            FileStream file = File.Open(path, FileMode.Open);

            // Deserialise from JSON
            EditorJsonUtility.FromJsonOverwrite((string)binaryFormatter.Deserialize(file), this.gameObject);

            // Close file
            file.Close();
        } else {
            Debug.Log("No file for " + this.gameObject.name + " was found");
        }
    }
}
