using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CropSeed", menuName ="New Crop Seed", order = 51)]
public class Seed : Item
{
    [Header("Seed Properties")]
    public float m_fGrowthTime;
    public int m_uiCost;
    public float m_fBaseValue;
}
