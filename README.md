#  Mana Tide

**Mana Tide** is a relaxing pixel art simulation game where players raise a growing colony of manatees in magical underwater lagoons. Inspired by *My Singing Monsters*, the game focuses on relaxation, exploration, and the natural beauty of the ocean, blending casual breeding mechanics with soft interaction and ambient storytelling.

---

##  Game Overview

In **Mana Tide**, players start with a small group of base manatees, each tied to specific elemental traits like sand, algae, light, mud, or magic. By feeding and leveling them up, players can breed them to discover unique combinations and expand their living ecosystem across multiple distinct underwater biomes.

---

##  Core Gameplay Features

###  Breeding System
- Start with 2 base manatees.
- Unlock 2 more via the shop using **Algaecoins** (in-game currency).
- Manatees must reach **Level 3** to breed.
- Breeding chances:
  - 2nd-tier: 75% success
  - 3rd-tier: 50% success
  - 4th-tier: 30% (only with 3rd-tier parents)
- If breeding fails, no offspring is produced.
- Successful breeding triggers a special animation and creates a new baby manatee.

###  Algae System
- Each biome starts with 2 algae bushes (feeding source).
- Players can purchase up to 3 additional bushes.
- Bush cost increases by 5 coins per new bush.
- Manatees feed autonomously when hungry.

###  Biomes
Each biome is a self-contained lagoon with its own creatures, background, music, and decor:
1. **Crystalline Lagoon**
   - Traits: Sand, Light, Algae, Magic
   - Creatures: Turtles, Clownfish, Starfish
   - Decor: Shells, Coral, Sand tray

2. **Kelp Forest**
   - Traits: Sand, Light, Algae, Mud
   - Creatures: Seahorses, Crabs, Shrimps
   - Decor: Seaweed, Logs, Mossy rocks

3. **Sunken Shipwreck**
   - Traits: Wreck, Mud, Magic, Algae
   - Creatures: Moonfish, Octopus, Rust Crabs
   - Decor: Ship debris, Rusty chests, Broken statues

### 🏝 Decorations
- Up to 3 purchasable decor items per biome.
- Adds ambiance and life to the lagoon.

### Passive Manatee Behavior
- Manatees move freely, sleep, and eat on their own.
- Occasional events (e.g., messages in bottles) appear in the environment.

---

##  Secondary Systems

- **Codex**: Displays discovered manatees with their traits, age, and appearance.
- **Shop UI**:
  - Lamantins
  - Algae bushes
  - Decor
  - Secondary creatures
- **Breeding Interface**:
  - Click the Breeder Spot to open UI.
  - Select two manatees to breed.
  - Success chance depends on parent tiers.
- **Biome Navigation**:
  - Switch between biomes using the HUD.

---

## 🧪Technical Overview (Unity)

- **Engine**: Unity 2D
- **Art Style**: Pixel Art
- **Project Structure**:
  - `Scripts/`: Gameplay logic (breeding, movement, AI)
  - `Prefabs/`: Manatees, bushes, decorations
  - `Scenes/`: Main menu + 3 biomes
  - `ScriptableObjects/`: Traits, manatee definitions
  - `UI/`: HUD, menus, codex, breeding interface
- **Saves**: Persistent world state (manatees, coins, decor, unlocked biomes)

---

##  Inspirations

- *My Singing Monsters*
- *Viridi*
- *ABZÛ*
- Ocean documentaries & manatee conservation

---

##  Future Plans

- More biomes with seasonal or rare manatees
- Weather or time-of-day effects
- Mobile version (iOS/Android)
- Accessibility options and sandbox mode

---

