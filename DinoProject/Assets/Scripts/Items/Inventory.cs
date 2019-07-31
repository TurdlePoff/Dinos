using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum EInventoryType
    {
        e_Seed,
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
        Seed someObject = _ItemToAdd as Seed;
        if(someObject)
        {
            AddInventoryItem(_ItemToAdd, m_SeedInventory);
        }
        else
        {
            AddInventoryItem(_ItemToAdd, m_ProduceInventory);
        }
        
        print("Added " + _ItemToAdd.name);
    }

    private void AddInventoryItem(Item _ItemToAdd, List<List<ItemHarness>> _ListToAddTo)
    {
        // Add item to Harness
        ItemHarness newItem = gameObject.AddComponent<ItemHarness>();
        newItem.SetItem(_ItemToAdd);

        // See if any current plant in seed inventory has the same name
        int iPositionToPlaceAt = 0;
        bool bFoundPositionToAddTo = false;
        foreach (List<ItemHarness> items in _ListToAddTo)
        {
            print("Size: " + items.Count);
            if (items[0].name == newItem.name)
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

    public Sprite GetUIImageOfSeedsAtPosition(int _iPosition, EInventoryType _eInventoryType)
    {
        List<List<ItemHarness>> ListToLookAt;
        switch (_eInventoryType)
        {
            case EInventoryType.e_Produce:
                {
                    ListToLookAt = m_ProduceInventory;
                    break;
                }
            case EInventoryType.e_Seed:
                {
                    ListToLookAt = m_SeedInventory;
                    break;
                }
            default:
                ListToLookAt = m_SeedInventory;
                break;
        }

        if (ListToLookAt.Count < _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + ListToLookAt[_iPosition][0].GetItem().name);
        return (ListToLookAt[_iPosition][0].GetItem().m_2DSprite);
    }

    public ItemHarness GetFirstItemAtPosition(int _iPosition, EInventoryType _eInventoryType)
    {
        List<List<ItemHarness>> ListToLookAt;
        switch (_eInventoryType)
        {
            case EInventoryType.e_Produce:
                {
                    ListToLookAt = m_ProduceInventory;
                    break;
                }
            case EInventoryType.e_Seed:
                {
                    ListToLookAt = m_SeedInventory;
                    break;
                }
            default:
                ListToLookAt = m_SeedInventory;
                break;
        }

        if (ListToLookAt.Count <= _iPosition)
        {
            print("OutOfArray");
            return null;
        }
        print("Name of item = " + ListToLookAt[_iPosition][0].GetItem().name);
        return (ListToLookAt[_iPosition][0]);
    }

    public void RemoveFirstItemAtPositon(int _iPosition, EInventoryType _eInventoryType)
    {
        List<List<ItemHarness>> ListToRemoveFrom; 
        switch (_eInventoryType)
        {
            case EInventoryType.e_Produce:
                {
                    ListToRemoveFrom = m_ProduceInventory;
                    break;
                }
            case EInventoryType.e_Seed:
                {
                    ListToRemoveFrom = m_SeedInventory;
                    break;
                }
            default:
                ListToRemoveFrom = m_SeedInventory;
                break;
        }

        if (ListToRemoveFrom.Count <= _iPosition)
        {
            print("OutOfArray... Can not delete");
            return;
        }
        print("Name of item = " + ListToRemoveFrom[_iPosition][0].GetItem().name);

        Destroy(ListToRemoveFrom[_iPosition][0]);

        ListToRemoveFrom[_iPosition].RemoveAt(0);

        if (0 >= ListToRemoveFrom[_iPosition].Count)
        {
            ListToRemoveFrom.RemoveAt(_iPosition);
        }

        switch (_eInventoryType)
        {
            case EInventoryType.e_Produce:
                {
                    m_ProduceInventory = ListToRemoveFrom;
                    break;
                }
            case EInventoryType.e_Seed:
                {
                    m_SeedInventory = ListToRemoveFrom;
                    break;
                }
            default:
                m_SeedInventory = ListToRemoveFrom;
                break;
        }

        return;
    }

    public void TestPrintGetItemAtPosition(int _iPosition, EInventoryType _eInventoryType)
    {
        List<List<ItemHarness>> ListToRemoveFrom;
        switch (_eInventoryType)
        {
            case EInventoryType.e_Produce:
                {
                    ListToRemoveFrom = m_ProduceInventory;
                    break;
                }
            case EInventoryType.e_Seed:
                {
                    ListToRemoveFrom = m_SeedInventory;
                    break;
                }
            default:
                ListToRemoveFrom = m_SeedInventory;
                break;
        }
        if (ListToRemoveFrom.Count <= _iPosition)
        {
            print("OutOfArray");
            return;
        }
        print("Name of item = " + ListToRemoveFrom[_iPosition][0].GetItem().name);
        return;
    }
}
