using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BiomeData
{
    public string biomeName;
    public bool unlocked;
    public List<ItemManatee> manatees = new List<ItemManatee>();
}
