using UnityEngine;

[System.Serializable]
public class ItemManatee
{
    public string itemName;
    public int lvl;
    
    public ManateeType type;
    public Biome biome;
}

public enum ManateeType
{
    Type1 = 1,
    Type2 = 2,
    Type3 = 3,
    Type12 = 12,
    Type13 = 13,
    Type23 = 23,
    Type123 = 123
}

public enum Biome
{
    Langune = 1,
    Kelp = 2,
    Epave = 3
}