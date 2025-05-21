using UnityEngine;
using System.Collections;

public class MoneyCoin : MonoBehaviour
{
    public int coinValue = 2; 
    public PlayerState playerState; 

    void OnMouseDown()
    {
             playerState.AddCoins(coinValue); 
            Destroy(gameObject);
    }
}