using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CropProduce", menuName = "New Crop Produce", order = 51)]
public class Produce : Item
{
    [Header("Produce Properties")]
    public float m_fValue;
    public float m_fDecayTime;
}
