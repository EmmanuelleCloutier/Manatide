using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Game/PlayerState")]
public class PlayerState : ScriptableObject
{
    [Header("Ressources")]
	public int coins;
	public int food;

	public int lvl;

	public bool BiomeKelp;
	public bool BiomeEpave;
}
