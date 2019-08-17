using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Inventory : MonoBehaviour
{
    public enum EInventoryType
    {
        e_Seed = 0,
        e_Produce,
        e_Dino,
    }

    static private List<ItemHarness> m_Dinos = new List<ItemHarness>();
    static private List<List<ItemHarness>> m_SeedInventory = new List<List<ItemHarness>>();
    static private List<List<ItemHarness>> m_ProduceInventory = new List<List<ItemHarness>>();

    private bool m_bStartRunning = true;

    // Start is called before the first frame update
    void Start() 
    {
        // Temporary play save state
        if(0 < PlayerPrefs.GetInt("NumberOfWatermelon_Seed"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("NumberOfWatermelon_Seed"); ++i)
            {
                Item Item = (Item)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Items/Crops and Produce/Watermelon_Seed.asset", typeof(Item));
                AddItemToInventory(Item);
            }
        }
        if (0 < PlayerPrefs.GetInt("NumberOfWheat_Seed"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("NumberOfWheat_Seed"); ++i)
            {
                Item Item = (Item)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Items/Crops and Produce/Wheat_Seed.asset", typeof(Item));
                AddItemToInventory(Item);
            }
        }
        if (0 < PlayerPrefs.GetInt("NumberOfWheat_Produce"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("NumberOfWheat_Produce"); ++i)
            {
                Item Item = (Item)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Items/Crops and Produce/Wheat_Produce.asset", typeof(Item));
                AddItemToInventory(Item);
            }
        }
        if (0 < PlayerPrefs.GetInt("NumberOfTestDino"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("NumberOfTestDino"); ++i)
            {
                Item Item = (Item)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Items/Crops and Produce/TestDino.asset", typeof(Item));
                AddItemToInventory(Item);
            }
        }
        m_bStartRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToInventory(Item _ItemToAdd)
    {
        Seed isSeed = _ItemToAdd as Seed;
        Dinos isDino = _ItemToAdd as Dinos;
        Produce isProduce = _ItemToAdd as Produce;
        if (isSeed)
        {
            AddInventoryItem(_ItemToAdd, ref m_SeedInventory);
        }
        else if( isProduce)
        {
            AddInventoryItem(_ItemToAdd, ref m_ProduceInventory);
        }
        else if(isDino)
        {
            AddInventoryItem(_ItemToAdd, ref m_Dinos);
        }
        else
        {
            print("Error: Unknown Type ");
        }

        // Just to make sure it doesn't set inventory to one upon starting (and adding items to inventory)
        if (!m_bStartRunning)
        {
            ResetPlayPrefData();
        }

        print("Added " + _ItemToAdd.name);
    }

    public void ResetPlayPrefData()
    {
        foreach (List<ItemHarness> items in m_SeedInventory)
        {
            string strPlayerPrefLable = "NumberOf" + items[0].GetItem().name;
            PlayerPrefs.SetInt(strPlayerPrefLable, items.Count);
        }
        foreach (List<ItemHarness> items in m_ProduceInventory)
        {
            string strPlayerPrefLable = "NumberOf" + items[0].GetItem().name;
            PlayerPrefs.SetInt(strPlayerPrefLable, items.Count);
        }

        PlayerPrefs.SetInt("NumberOfTestDino", m_Dinos.Count);
    }

    private void AddInventoryItem(Item _ItemToAdd, ref List<ItemHarness> _ListToAddTo)
    {
        // Add item to Harness
        ItemHarness newItem = gameObject.AddComponent<ItemHarness>();
        newItem.SetItem(_ItemToAdd);

        _ListToAddTo.Add(newItem);
    }
    private void AddInventoryItem(Item _ItemToAdd, ref List<List<ItemHarness>> _ListToAddTo)
    {
        // Add item to Harness
        ItemHarness newItem = gameObject.AddComponent<ItemHarness>();
        newItem.SetItem(_ItemToAdd);

        // See if any current plant in seed inventory has the same name
        int iPositionToPlaceAt = 0;
        bool bFoundPositionToAddTo = false;
        foreach (List<ItemHarness> items in _ListToAddTo)
        {
            if (items[0].GetItem().name == newItem.GetItem().name)
            {
                bFoundPositionToAddTo = true;
                break;
            }
            ++iPositionToPlaceAt;
        }

        if (bFoundPositionToAddTo)
        {
            // Add item to that item type
            _ListToAddTo[iPositionToPlaceAt].Add(newItem);

            print("Added to existing array");
        }
        else
        {
            // Create a new list and add item to that type
            List<ItemHarness> tempList = new List<ItemHarness>();
            tempList.Add(newItem);
            _ListToAddTo.Add(tempList);

            print("Added to new array");
        }
    }

    public Sprite GetUIImageOfSeedsAtPosition(int _iPosition)
    {
        if (m_SeedInventory.Count < _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name);
        return (m_SeedInventory[_iPosition][0].GetItem().m_2DSprite);
    }

    public Sprite GetUIImageOfProduceAtPosition(int _iPosition)
    {
        if (m_ProduceInventory.Count < _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name);
        return (m_ProduceInventory[_iPosition][0].GetItem().m_2DSprite);
    }

    public Sprite GetUIImageOfDinoAtPosition(int _iPosition)
    {
        if (m_Dinos.Count < _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_Dinos[_iPosition].GetItem().name);
        return (m_Dinos[_iPosition].GetItem().m_2DSprite);
    }

    public GameObject GetModelOfSeedsAtPosition(int _iPosition)
    {
        if (m_SeedInventory.Count < _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name);
        return (m_SeedInventory[_iPosition][0].GetItem().m_3DModel);
    }

    public GameObject GetModelOfProduceAtPosition(int _iPosition)
    {
        if (m_ProduceInventory.Count < _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name);
        return (m_ProduceInventory[_iPosition][0].GetItem().m_3DModel);
    }

    public GameObject GetModelOfDinoAtPosition(int _iPosition)
    {
        if (m_Dinos.Count < _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_Dinos[_iPosition].GetItem().name);
        return (m_Dinos[_iPosition].GetItem().m_3DModel);
    }

    public ItemHarness GetFirstSeedItemAtPosition(int _iPosition)
    {
        if (m_SeedInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name);
        return (m_SeedInventory[_iPosition][0]);
    }

    public ItemHarness GetFirstProduceItemAtPosition(int _iPosition)
    {
        if (m_ProduceInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name);
        return (m_ProduceInventory[_iPosition][0]);
    }

    public ItemHarness GetFirstDinoAtPosition(int _iPosition)
    {
        if (m_Dinos.Count <= _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + m_Dinos[_iPosition].GetItem().name);
        return (m_Dinos[_iPosition]);
    }

    public int GetNumberOfSeedItemsAtPosition(int _iPosition) 
    {
        if (m_SeedInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return 0;
        }
        print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name + "... Number: " + m_SeedInventory[_iPosition].Count);
        return (m_SeedInventory[_iPosition].Count);
    }

    public int GetNumberOfProduceItemsAtPosition(int _iPosition)
    {
        if (m_ProduceInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return 0;
        }
        print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name + " Number: " + m_ProduceInventory[_iPosition].Count);
        return (m_ProduceInventory[_iPosition].Count);
    }

    public int GetNumberOfDinosAtPosition(int _iPosition)
    {
        if (m_Dinos.Count <= _iPosition)
        {
            print("OutOfArray");
            return 0;
        }
        print("Name of item Dinos, Number: " + m_Dinos.Count);
        return (m_Dinos.Count);
    }

    public int GetTotalNumberOfSeeds()
    {
        return m_SeedInventory.Count;
    }

    public int GetTotalNumberOfProduce()
    {
        return m_ProduceInventory.Count;
    }

    public int GetTotalNumberOfDinos()
    {
        return m_Dinos.Count;
    }

    public void RemoveFirstSeedItemAtPositon(int _iPosition)
    {
        if (m_SeedInventory.Count <= _iPosition)
        {
            print("OutOfArray... Can not delete");
            return;
        }
        print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name);

        Destroy(m_SeedInventory[_iPosition][0]);

        m_SeedInventory[_iPosition].RemoveAt(0);

        if (0 >= m_SeedInventory[_iPosition].Count)
        {
            m_SeedInventory.RemoveAt(_iPosition);
        }

        ResetPlayPrefData();
        return;
    }

    public void RemoveFirstProduceItemAtPositon(int _iPosition)
    {
        if (m_ProduceInventory.Count <= _iPosition)
        {
            print("OutOfArray... Can not delete");
            return;
        }
        print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name);

        Destroy(m_ProduceInventory[_iPosition][0]);

        m_ProduceInventory[_iPosition].RemoveAt(0);

        if (0 >= m_ProduceInventory[_iPosition].Count)
        {
            m_ProduceInventory.RemoveAt(_iPosition);
        }

        ResetPlayPrefData();
        return;
    }

    public void RemoveFirstDinoAtPositon(int _iPosition)
    {
        if (m_Dinos.Count <= _iPosition)
        {
            print("OutOfArray... Can not delete");
            return;
        }
        print("Name of item = " + m_Dinos[_iPosition].GetItem().name);

        Destroy(m_Dinos[_iPosition]);

        m_Dinos.RemoveAt(_iPosition);

        ResetPlayPrefData();
        return;
    }

    public void TestPrintGetNameOfSeedAtPosition(int _iPosition)
    {
        if (m_SeedInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return;
        }
        print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name);
        return;
    }

    public void TestPrintGetNameOfProduceAtPosition(int _iPosition)
    {
        if (m_ProduceInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return;
        }
        print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name);
        return;
    }

    public void TestPrintGetNameOfDinoAtPosition(int _iPosition)
    {
        if (m_Dinos.Count <= _iPosition)
        {
            print("OutOfArray");
            return;
        }
        print("Name of item = " + m_Dinos[_iPosition].GetItem().name);
        return;
    }
}
