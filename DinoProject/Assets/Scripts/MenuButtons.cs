using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void OpenScene(string _strLeveName)
    {
        SceneManager.LoadScene(_strLeveName);
    }

    public void ToggleInventoryPlantsSeeds()
    {

    }

    public void ToggleInventoryPlantsProduce()
    {

    }

    public void ToggleInventoryMeatSeeds()
    {

    }

    public void ToggleInventoryMeatProduce()
    {

    }

    public void ToggleSettings()
    {

    }
}
