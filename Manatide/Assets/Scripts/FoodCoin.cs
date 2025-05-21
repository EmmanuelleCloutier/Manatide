using UnityEngine;

public class FoodCoin : MonoBehaviour
{
    public int foodValue = 10;
    public PlayerState playerState;

    void OnMouseDown()
    {
        if (playerState != null)
        {
            playerState.AddFood(foodValue);
            Destroy(gameObject);
        }
    }
}