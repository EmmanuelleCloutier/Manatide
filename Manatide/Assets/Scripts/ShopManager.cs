using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [Header("Manatees")]
    public Button btnManatee1;
    public int PriceM1;
    public GameObject prefabManateeType1;
    public Button btnManatee2;
    public int PriceM2;
    public GameObject prefabManateeType2;
    public Button btnManatee3;
    public int PriceM3;   
    public GameObject prefabManateeType3;
    
    
    [Header("Creatures")]
    public Button btnCreatures1;
    public int PriceC1;
    public GameObject prefabCreaturesType1;
    public Button btnCreatures2;
    public int PriceC2;
    public GameObject prefabCreaturesType2;
    public Button btnCreatures3;
    public int PriceC3;
    public GameObject prefabCreaturesType3;
    
    
    [Header("Decorations")]
    public Button btnDecoration1;
    public int PriceD1;
    public GameObject prefabDecorationType1;
    public Button btnDecoration2;
    public int PriceD2;
    public GameObject prefabDecorationType2;
    public Button btnDecoration3;
    public int PriceD3;
    public GameObject prefabDecorationType3;
  

   
    
    
    
    public void BuyItem(ItemData item)
    {
        if (GameUIManager.Instance.playerState.coins >= item.price)
        {
            GameUIManager.Instance.AddCoins(-item.price);
            Debug.Log("Achat effectué : " + item.name);
        }
        else
        {
            Debug.Log("Pas assez de coins");
        }
    }
}

[System.Serializable]
public class ItemData
{
    public string name;
    public int price;

}