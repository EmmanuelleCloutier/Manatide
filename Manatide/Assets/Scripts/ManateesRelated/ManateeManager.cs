using System.Collections.Generic;
using UnityEngine;

public class ManateeManager : MonoBehaviour
{
    public List<ItemManatee> ownedManatees = new List<ItemManatee>();
	public List<GameObject> spawnedManatees = new List<GameObject>();

	[Header("UI")]
	public ManateeInfoUI manateeInfoUI;
	
    [Header("Dependencies")]
    public PlayerState playerState;

    public Transform spawnPoint;

    public GameObject prefabType1;
    public GameObject prefabType2;
    public GameObject prefabType3;

    private void Start()
    {
        LoadManatees();
    }

	private void Update()
	{
    	if (Input.GetKeyDown(KeyCode.D))
    	{
        	DeleteAllManatees();
    	}
	}

	public void DeleteAllManatees()
	{
    	foreach (GameObject manatee in spawnedManatees)
    	{
        	if (manatee != null)
        	{
        	    Destroy(manatee);
        	}
    	}
    	spawnedManatees.Clear();

    	ownedManatees.Clear();
    	PlayerPrefs.DeleteKey("SavedManatees");
    	PlayerPrefs.Save();

    	Debug.Log("All manatees deleted from memory and scene.");
	}


    public void SaveManatees()
    {
        string json = JsonUtility.ToJson(new ManateeListWrapper { manatees = ownedManatees });
        PlayerPrefs.SetString("SavedManatees", json);
        PlayerPrefs.Save();
		Debug.Log("ManateeSaved");
	
    }

    public void LoadManatees()
    {
        if (!PlayerPrefs.HasKey("SavedManatees"))
            return;

        string json = PlayerPrefs.GetString("SavedManatees");
        ManateeListWrapper wrapper = JsonUtility.FromJson<ManateeListWrapper>(json);
        ownedManatees = wrapper.manatees;

        foreach (var manatee in ownedManatees)
        {
            // Ne charge que les manatees du biome actuel
            if ((int)manatee.biome == playerState.lvl)
            {
                GameObject prefab = GetPrefabForType(manatee.type);
                if (prefab != null)
                {
                    GameObject instance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
					spawnedManatees.Add(instance);
					
					AIManatee ai = instance.GetComponent<AIManatee>();
					if (ai != null)
					{
						ai.data = manatee;

						// Récupère le bon sprite à partir du type
						Sprite sprite = GetSpriteForType(manatee.type);
						ai.sprite = sprite;
					}

                }
				else {
						Debug.LogWarning($"Prefab is null for type: {manatee.type}");
				}
            }
        }
    }
    
   public Sprite GetSpriteForType(ManateeType type)
	{
    	foreach (var pair in manateeInfoUI.spriteByTypeList)
    	{
        	if (pair.type == type)
            	return pair.sprite;
    	}
    	return null;
	}


    public void AddManatee(ItemManatee newManatee)
    {
        ownedManatees.Add(newManatee);
		Debug.Log("Manateeadded into manateemanager");
        SaveManatees();
    }

    private GameObject GetPrefabForType(ManateeType type)
    {
        switch (type)
        {
            case ManateeType.Type1:
                return prefabType1;
            case ManateeType.Type2:
                return prefabType2;
            case ManateeType.Type3:
                return prefabType3;
            default:
                return null;
        }
    }

    [System.Serializable]
    private class ManateeListWrapper
    {
        public List<ItemManatee> manatees;
    }
}
