using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Farming/Crop"), Serializable]
public class CropSO : ScriptableObject
{
    [field: SerializeField]
    public string cropName { get; private set; }
    [field: SerializeField]
    public Sprite[] cropSprites { get; private set; }
    [field: SerializeField, Tooltip("Unit: second(s)")]
    public float grownTime { get; private set; }
}
