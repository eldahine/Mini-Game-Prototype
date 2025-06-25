![App Icon Kenney Tiny Dungeon Soldier Tile 128x128 CC0 1](https://github.com/user-attachments/assets/5df01695-fad2-40a8-bc6d-921aaf4aa72b)
# Web Build
[Play Web Build on GitHub Pages](https://eldahine.github.io/Mini-Game-Prototype)

# Introduction
### Game Summary Pitch

Tiny Dungeon is an action roguelike RPG where players, solo or in a party, venture into a cursed dungeon to save a doomed village.
### Inspiration, Lufia II: Rise of the Sinistrals

| Lufia is the main inspiration for this game. Lufia is a RPG with puzzle elements, featuring the Ancient Cave, a randomly generated dungeon with 99 floors. The cave is introduced as a side quest in the town of Gruberik. Each time the player enters, a new layout is generated, similar to roguelikes.<br><br>Inside the cave, characters are reset to zero experience points and lose almost all equipment and items. The player must progress through the floors, collecting gear, discovering magic spells, and leveling up, all with the goal of reaching the final floor of the Ancient Cave. | ![Screenshot 2025-06-25 212121](https://github.com/user-attachments/assets/bce3138d-02ff-4240-9416-5fc044436e24)<br>![Screenshot 2025-06-25 212244](https://github.com/user-attachments/assets/2847e2e3-23d2-4630-9d54-eabdf3d7dbb3)<br>Master Jelly final boss of the Ancient Cave |
| -- | -- |
### Player Experience
In both single-player and multiplayer modes, each run throws you into an ever changing dungeon where you dash through procedurally generated floors, stockpile weapons, rest at campsites, battle mini bosses and revive by watching advertisements. Every death presents a fresh opportunity to refine your tactics and push toward the 100th floor.
### Platform
The game is developed to be released on Desktop, Web and Android
### Development Software
- Unity 6
### Genre
Single player, Co-Op, RPG, roguelike, puzzle
### Target Audience

This game marketed to fans of Single player and Co Op experiences who crave bitesize runs, RPG lovers drawn to weapon loadouts and campsite upgrades, roguelike purists eager to refine tactics through permadeath, and puzzle seekers who thrive on ever changing procedurally generated floors all wrapped in accessible gameplay.
## Concept
### Gameplay overview
The player can dash through objects, attack enemies, or trick them into walking into a well timed trap. They can use the environment to their advantage. The world may be out to get them, but with enough ingenuity, the dungeon's traps can become a powerful tool in their favor.
### Primary Mechanics

| Mechanic | Gameplay Recording<br><br>(not necessarily final)  |
| ---| --- |
| **Dash** <br>An alternative to sprinting, helps the player to quickly move around obstacles and enemies. | ![Dash](https://github.com/user-attachments/assets/4e5bad1d-b160-43fc-b695-e271c3548215)   |
| **Dash Ramming**<br>When a player dashes into enemies they deal damage, or when they run into objects they break them. | ![Dash Ramming](https://github.com/user-attachments/assets/805dfb3b-195f-4bba-9278-f2ce4e2991ce) |
| **Dash Jump**<br>The player can jump over obstacles that are none traversable like rivers. | TBD ⚠️ |
### Secondary Mechanics

| Mechanic  | Gameplay Recording <br><br>(not necessarily final)  |
| -- | -- |
| **Revive using Ads**  <br>When the player eventually dies they can either start over or revive and continue using the super rate items found in the dungeon or watching a quick advertisement. | ![Revive](https://github.com/user-attachments/assets/04d91bac-bf40-4c5e-a45c-459843f3add4) |
## Art
### Theme Interpretation
Pixel with limited colors
### Design
Minimalist retro
## Audio
### Music
TBD ⚠️
### Sound Effects
TBD ⚠️

## Game Experience
### UI
A minimal UI with no more than a handful of elements, ensuring easy adaptation for mobile ports.
### Controls

| Input Type | Movement      | Dashing         |
| ---------- | ------------- | --------------- |
| Keyboard   | WASD          | Space Bar       |
| Gamepad    | Left Joystick | Left Button / X |
| Touch      | Left Joystick | Dash Button     |

## Development Timeline

- Started at: 12:00 on Monday, 23 June 2025 
- Deadline: 12:00 on Thursday, 26 June 2025
- Approximately 72 hours or 24 work hours
### 23 June 2025 (+8 hours)

Brainstorming, Market Research & Considerations
- Focus on 2D or 2.5D/isometric visuals to cut dev time and reach casual audiences.
- Reinterpret the Title: One Mechanic, One Level as One Mech One Life (evokes a Doom-style vibe)
- Sci-fi turret/tower-defense idea
- Giant walking machines mining, upgrading weapons, fighting critters.
- Mashup: Factorio + Mortal Engines + tower defense
- Roguelike RPG concept: Dungeon of Tiny Village
- 100-floor dungeon, runs reset on death
- Single or co-op play, party revives via potions, shop-bought crystals, or ads.
- Procedural levels, fresh layouts each run
- Compressed runs (10–90 min)
- Monetization:
	- Rewarded ads for revives or temporary buffs
	- In-App Purchases (IAPs) for potions, Crystals of Immortality, cosmetics
- Copy Game Design Doc from develop.games and modify it for the current project

Initial Development
- Install Unity Hub modules: WebGL Build Support + Android Build Support
- Create a new project and configure target platforms (Android & WebGL)
- Create a quick and dirty test scene as the scaffolding for the prototype
- Browse kenney.nl (and similar) for free assets
- Run quick builds on Windows, WebGL, and Android to confirm cross-platform setup
### 24 June 2025 (+10 hours)
- File GitHub issues
- Spent ~10 min troubleshooting IntelliSense
- Install and configure the Unity Input System package
- Scaffold a basic PlayerController
- Switch public variables to private and use [SerializeField] to make them appear in the inspector.
- Removed actions such as crouch, sprint, and jump: These actions don’t significantly impact gameplay. Their removal simplifies porting to mobile. Keeping only interact, move, dash, and attack streamlines mechanics.
- Obstacle interactions: 
	- Light builds auto-jump when dashing. 
	- Heavy builds break obstacles. 
	- Mages phase through obstacles like ghosts.
- Fixed gaps between tiles using sprite atlas, resolving issues caused by unpadded textures.
- Updated the level and added a river to test the dash jump mechanic.
- Updated the player controller to dash jump over the river, but it failed. I couldn’t get the jump to form a nice arc or properly toggle the collision layers. I suspect I need to handle the colliders in 3D. specifically accounting for the player’s z-position, which would be time consuming. I’ll skip this for now.
- Implemented a dash ramming mechanic to break objects and attack enemies.
- Developed a health system.
- Created an object pool for displaying damage points.
### 25 June 2025 (+12 hours)
- Enhance game UI and menus using UI Toolkit, including sound effects
- Expand the level design
- Add breakable barrels, bombs, and area-of-effect (AOE) damage
- Implement game-over UI and reviving mechanics
- Add mobile touch input and movement controls
- Adjust player dash speed and timing
- Update the game design document
- Added version number to the UI
