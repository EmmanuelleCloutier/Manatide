using UnityEngine;
using System.Collections.Generic;


public class NameGenerator : MonoBehaviour
{
    public List<string> namePool = new List<string>()
    {
        "Bob", "Lulu", "Toto", "Mimi", "Kiki", "Zuzu", "Nono", "Bibi", "Polo", "Coco"
    };

    private HashSet<string> usedNames = new HashSet<string>();

    public string GenerateName()
    {
        if (namePool.Count == 0)
        {
            return "Manatee"; 
        }

        int index = Random.Range(0, namePool.Count);
        string name = namePool[index];
        
        int suffix = 2;
        while (usedNames.Contains(name))
        {
            name = namePool[index] + $" ({suffix})";
            suffix++;
        }

        usedNames.Add(name);
        return name;
    }
}
