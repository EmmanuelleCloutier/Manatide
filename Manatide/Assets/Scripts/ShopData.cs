using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ShopData", menuName = "Game/Shop Data")]
public class ShopData : ScriptableObject
{
    public string zoneName;
    public List<ShopItemOneTime> items;
}
