using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Farming/Crop"), Serializable]
public class CropSO : ScriptableObject
{
    public string cropName;
    public Sprite[] cropSprites;
    [Tooltip("Unit: second(s)")]
    public float grownTime;
}
