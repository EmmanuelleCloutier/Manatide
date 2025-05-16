using UnityEngine;
using System.Collections.Generic;


public class NameGenerator : MonoBehaviour
{
    public List<string> namePool = new List<string>()
    {
        "Bob", "Lulu", "Toto", "Mimi", "Kiki", "Zuzu", "Nono", "Bibi", "Polo", "Coco",
    	"Nini", "Lala", "Dodo", "Riri", "Fifi", "Gigi", "Titi", "Lili", "Didi", "Zizi",
    	"Jojo", "Nana", "Popo", "Momo", "Chacha", "Tata", "Dudu", "Bobo", "Pepe", "Lolo",
    	"Roro", "Cici", "Pipi", "Fafa", "Gogo", "Sisi", "Dada", "Zaza", "Tutu", "Lélo",
    	"Bubu", "Koko", "Yoyo", "Mumu", "Néné", "Foufou", "Poupou", "Tamtam", "Loulou", "Chichi",
    	"Didou", "Nonoé", "Bibou", "Mimou", "Zou", "Zouzou", "Lélé", "Gaga", "Baba", "Rara",
    	"Pépé", "Titou", "Ninou", "Moumi", "Doudou", "Louloute", "Minou", "Zinzin", "Choupette", "Bidou",
    	"Loupou", "Rikiki", "Poupette", "Lichou", "Pichou", "Bichou", "Doudoune", "Moumou", "Doudy", "Boubou",
    	"Totote", "Mimimi", "Lilou", "Ninette", "Loutre", "Bambou", "Zibou", "Toupie", "Mouchette", "Choupi",
    	"Coucou", "Poupi", "Bambinou", "Pompom", "Zoupette", "Toupti", "Moumoute", "Fifine", "Cacou", "Popette",
    	"Cachou", "Boubidou", "Tartine", "Pimousse", "Tralala", "Papouille", "Bouboule", "Foufoune", "Titine", "Moumoune",
    	"Bichonne", "Zoup", "Douce", "Moumoutte", "Papou", "Zinette", "Choupinou", "Pouf", "Tifou", "Doudi",
    	"Tifouille", "Chouf", "Pop", "Mouk", "Lilirose", "Doudinette", "Ninichou", "Kikou", "Bibiche", "Minouche",
    	"Toudou", "Pépoune", "Fifou", "Louchou", "Zoupinette", "Boubinou", "Pipou", "Doudinou", "Miniminou", "Chouquette",
    	"Titoune", "Pépou", "Lilotte", "Ninoucha", "Bambina", "Fafaou", "Miminette", "Moumoucha", "Loubibou", "Tamtoune",
    	"Choupinette", "Lalinou", "Foufounette", "Zinou", "Bichon", "Chouchou", "Chou", "Mimoucha", "Totoon", "Doudonette",
    	"Poupidou", "Boulou", "Titouf", "Poupoutte", "Fififou", "Loulounette", "Zazou", "Lalimou", "Ninouche", "Pouette",
    	"Bibounette", "Doudoune", "Tamtamou", "Chachou", "Loupi", "Boubounette", "Doudounette", "Poupounette", "Papinou", "Kikitte",
    	"Poutou", "Foufifou", "Ninifou", "Roudoudou", "Choupetta", "Mouchon", "Boubichon", "Choupinet", "Lilipop", "Poupop",
    	"Pompette", "Kikounette", "Poulet", "Doudoudi", "Choumi", "Tounette", "Bounette", "Toupinou", "Mimimou", "Boubinette",
    	"Lilili", "Zinzinou", "Minoutte", "Chachoute", "Popinette", "Cacounette", "Bambinette", "Zibounette", "Popoulou", "Tamtamette",
    	"Pépounette", "Bibibou", "Louloupette", "Trotinette", "Mouminou", "Zabou", "Rififi", "Boulette", "Chipie", "Pouloupou",
    	"Bidounette", "Popop", "Lafouine", "Chatoune", "Doudipouf", "Moumouton", "Nounoute", "Chiffon", "Foufouchka", "Bamboumou",
    	"Toupoutou", "Papinette", "Tartounette", "Mininette", "Roudou", "Patachou", "Chinou", "Zoubette", "Ninonou", "Louchoune",
    	"Lafifine", "Choupop", "Tifounette", "Poupiette", "Cocotte", "Zinzinette", "Mininou", "Popol", "Papounet", "Kikinet",
    	"Poutounette", "Titimou", "Bichonette", "Chachacha", "Poune", "Tontonou", "Timinou", "Doudoudounette", "Poupinou", "Tafouine",
    	"Cachounette", "Foufouinette", "Zoubinou", "Louloutef", "Lipop", "Bichoupop", "Nounou", "Poulinette", "Roudounette", "Zoupouf",
    	"Toupoutoune", "Poufette", "Mimipop", "Doudoudounou", "Bibouchou", "Kikipop", "Poupouf", "Ninipouf", "Minoupouf", "Toupoutoup",
    	"Foufouf", "Rourou", "Tamtamour", "Bambichou", "Lilipou", "Poufpouf", "Doudoupouf", "Touloup", "Kikichou", "Poupoulou",
    	"Kachou", "Zinzinpouf", "Mimouchette", "Zoubipouf", "Toupitou", "Popinou", "Ninoupouf", "Foufounettepop", "Choupopop", "Tatatou",
    	"Tontonchou", "Doudichou", "Titounechou", "Poupepouf", "Fafachou", "Pépépouf", "Zazapouf", "Miniminette", "Chachachou", "Zoulou"
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
