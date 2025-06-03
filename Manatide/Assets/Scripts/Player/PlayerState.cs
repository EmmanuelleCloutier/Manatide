using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Game/PlayerState")]
public class PlayerState : ScriptableObject
{
    [Header("Coins")]
    public int coins;
    public int food;

	[Header("Biomes")]
    public int lvl;
    public bool BiomeKelp;
    public bool BiomeEpave;

	[Header("Plantes - Lagoon")]
	public bool PlanteL1;
	public bool PlanteL2;
	public bool PlanteL3;

	[Header("Plantes - Kelp")]
	public bool PlanteK1;
	public bool PlanteK2;
	public bool PlanteK3;

	[Header("Plantes - Epave")]
	public bool PlanteE1;
	public bool PlanteE2;
	public bool PlanteE3;

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

	public void SpendFood(int amount)
	{
    	food -= amount;
    	OnFoodChanged?.Invoke();
	}
    
    public void ResetPlayerState()
    {
        coins = 0;
        food = 0;
        lvl = 1;               
        BiomeKelp = false;
        BiomeEpave = false;
		PlanteL1 = false;
		PlanteL2 = false;
		PlanteL3 = false;
		PlanteK1 = false;
		PlanteK2 = false;
		PlanteK3 = false;
		PlanteE1 = false;
		PlanteE2 = false;
		PlanteE3 = false;


        OnCoinsChanged?.Invoke();
        OnFoodChanged?.Invoke();
    }
}