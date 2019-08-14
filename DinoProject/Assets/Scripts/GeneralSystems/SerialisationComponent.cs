using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SerialisationComponent : MonoBehaviour
{

    // Deserialise the parent on enable
    private void OnEnable() {
        // Search for serialised data
        if(File.Exists(Application.persistentDataPath + PlayerPrefs.GetString("FarmosaurSave", "Default") +"_" + this.gameObject.name + ".pso")) {
            // Create new binary formatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            // Open file
            FileStream file = File.Open(Application.persistentDataPath + PlayerPrefs.GetString("FarmosaurSave", "Default") + "_" + this.gameObject.name + ".pso", FileMode.Open);
            // Deserialise from JSON
            JsonUtility.FromJsonOverwrite((string)binaryFormatter.Deserialize(file), this.gameObject);
            // Close file
            file.Close();
        } else {
            Debug.Log("No file for " + this.gameObject.name + " was found");
        }
    }


    // Save the object when disabled
    private void OnDisable() {
        // Create a binary formatter
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        // Create a filestream using the save path for this item
        FileStream file = File.Create(Application.persistentDataPath + PlayerPrefs.GetString("FarmosaurSave", "Default") + "_" + this.gameObject.name + ".pso");
        // Serialise object
        binaryFormatter.Serialize(file, JsonUtility.ToJson(this.gameObject));
        file.Close();
        // Remember to perform any deregistration as required for the attached object
    }

}
