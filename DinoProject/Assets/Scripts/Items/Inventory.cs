using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public enum EInventoryType
    {
        e_Seed = 0,
        e_Produce,
    }

    static private List<List<ItemHarness>> m_SeedInventory = new List<List<ItemHarness>>();
    static private List<List<ItemHarness>> m_ProduceInventory = new List<List<ItemHarness>>();


    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToInventory(Item _ItemToAdd)
    {
        Seed isSeed = _ItemToAdd as Seed;
        Produce isProduce = _ItemToAdd as Produce;
        if (isSeed)
        {
            AddInventoryItem(_ItemToAdd, ref m_SeedInventory);
        }
        else if( isProduce)
        {
            AddInventoryItem(_ItemToAdd, ref m_ProduceInventory);
        }
        else
        {
            print("Error: Unknown Type ");
        }
        
        print("Added " + _ItemToAdd.name);
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
    //public Image GetUIImageOfSeedsAtPosition(int _iPosition)
    //{
    //    if (m_SeedInventory.Count < _iPosition)
    //    {
    //        print("OutOfArray");
    //        return null;
    //    }
    //    print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name);
    //    return (m_SeedInventory[_iPosition][0].GetItem().m_2DSprite);
    //}

    //public Image GetUIImageOfProduceAtPosition(int _iPosition)
    //{
    //    if (m_ProduceInventory.Count < _iPosition)
    //    {
    //        print("OutOfArray");
    //        return null;
    //    }
    //    print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name);
    //    return (m_ProduceInventory[_iPosition][0].GetItem().m_2DSprite);
    //}

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
        return;
    }

    public void TestPrintGetOfSeedAtPosition(int _iPosition)
    {
        if (m_SeedInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return;
        }
        print("Name of item = " + m_SeedInventory[_iPosition][0].GetItem().name);
        return;
    }

    public void TestPrintGetOfProduceAtPosition(int _iPosition)
    {
        if (m_ProduceInventory.Count <= _iPosition)
        {
            print("OutOfArray");
            return;
        }
        print("Name of item = " + m_ProduceInventory[_iPosition][0].GetItem().name);
        return;
    }
}
