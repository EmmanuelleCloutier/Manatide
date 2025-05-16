using UnityEngine;

[System.Serializable]
public class ShopItemOneTime
{
    public string itemName;
	public int price;
	
	public ItemPurchaseType purchaseType;
	public int maxPurchases = 1;
	public int timesBought = 0;

	public bool CanBuy()
	{
		switch (purchaseType)
		 {
            case ItemPurchaseType.OneTime:
                return timesBought == 0;
            case ItemPurchaseType.Unlimited:
                return true;
            case ItemPurchaseType.Limited:
                return timesBought < maxPurchases;
            default:
                return false;
        }
    }

    public void Buy()
    {
        timesBought++;
    }
}

public enum ItemPurchaseType
{
    OneTime,     // une seule fois
    Unlimited,   // autant que voulu
    Limited      // ex. 3 fois max
}
			

