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

	[Header("Manatees")]
    public GameObject prefabType1;
    public GameObject prefabType2;
    public GameObject prefabType3;
	public GameObject prefabType12;
 	public GameObject prefabType13;
 	public GameObject prefabType23;
 	public GameObject prefabType123;

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
	
	public void DeleteManatee(ItemManatee manateeToDelete)
	{
		if (ownedManatees.Contains(manateeToDelete))
		{
			ownedManatees.Remove(manateeToDelete);
			GameObject toDestroy = null;
			
			foreach (GameObject go in spawnedManatees)
			{
				var ai = go.GetComponent<AIManatee>();
				if (ai != null && ai.data == manateeToDelete)
				{
					toDestroy = go;
					break;
				}
			}

			if (toDestroy != null)
			{
				spawnedManatees.Remove(toDestroy);
				Destroy(toDestroy);
			}

			SaveManatees();
			Debug.Log("Manatee deleted: " + manateeToDelete.itemName);
		}

		// Met à jour l’UI
		if (manateeInfoUI != null)
		{
			manateeInfoUI.RefreshUI();
		}
	}


    public void SaveManatees()
    {
        string json = JsonUtility.ToJson(new ManateeListWrapper { manatees = ownedManatees });
        PlayerPrefs.SetString("SavedManatees", json);
        PlayerPrefs.Save();
		//Debug.Log("ManateeSaved");
	
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
		    GameObject prefab = GetPrefabForType(manatee.type);
		    if (prefab != null)
		    {
			    // ❗️On n’instantie que si c’est le biome actuel
			    if ((int)manatee.biome == playerState.lvl)
			    {
				    GameObject instance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
				    spawnedManatees.Add(instance);

				    AIManatee ai = instance.GetComponent<AIManatee>();
				    if (ai != null)
				    {
					    ai.data = manatee;

					    Sprite sprite = GetSpriteForType(manatee.type);
					    ai.sprite = sprite;
				    }
			    }
		    }
		    else
		    {
			    Debug.LogWarning($"Prefab is null for type: {manatee.type}");
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
		//Debug.Log("Manateeadded into manateemanager");
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
			 case ManateeType.Type12:
                return prefabType12;
			 case ManateeType.Type13:
                return prefabType13;
			 case ManateeType.Type23:
                return prefabType23;
			 case ManateeType.Type123:
                return prefabType123;
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
