using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Game/PlayerState")]
public class PlayerState : ScriptableObject
{
    [Header("Ressources")]
	public int coins;
	public int food;

	public bool LVL_Kelp;
	public bool LVL_Epave;
}
