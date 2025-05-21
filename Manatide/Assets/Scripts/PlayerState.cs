using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Game/PlayerState")]
public class PlayerState : ScriptableObject
{
    [Header("Ressources")]
    public int coins;
    public int food;

    public int lvl;

    public bool BiomeKelp;
    public bool BiomeEpave;

    // Ajout d'un événement
    public event Action OnCoinsChanged;
    public event Action OnFoodChanged;

    public void AddCoins(int amount)
    {
        coins += amount;
        OnCoinsChanged?.Invoke();
    }

    public void SpendCoins(int amount)
    {
        coins -= amount;
        OnCoinsChanged?.Invoke();
    }

    public void AddFood(int amount)
    {
        food += amount;
        OnFoodChanged?.Invoke();
    }
}