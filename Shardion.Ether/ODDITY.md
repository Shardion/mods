# The Oddity fight

## Music
Oddity is slated to use World Fragments, World Fragments 2 and World Fragments 3 by xi.
These songs will be played in order during the fight and loop back to the first one after the last one ends, as if they were one song.

## Oddity Sky
During the Oddity fight, the background becomes entirely black, with many small white particles flying from the left side of the screen to the right.
*TODO: This is too boring, but I'm not sure how I could make it nicer while keeping it clean for the fight.*

## Projectiles
Most projectiles in the Oddity fight, including seals, have thin yellow outlines and yellow motion trails.
The only exceptions are "stationary" projectiles, such as the weapons Oddity wields during certain attacks (excluding the Ultimate Truth).

## Death
When Oddity dies, unlike the Siblings, and like most other bosses, they explode into a pile of gores.
Oddity drops no money or potions, but always drops their signature weapon, the Ultimate Truth.

## Stats
Oddity is slated to have 400,000 health in Normal Mode, 600,000 in Expert Mode, and 800,000 in Master Mode.
All contact damage is disabled while Oddity is alive.

## Phase 2
While there are plans for Oddity to have two phases, this will likely prove too time-consuming to implement.

When Oddity gets a second phase, their initial max health will be reduced to 100,000 (150,000 in Expert Mode, and 200,000 in Master Mode).

In the first phase, when their health is brought down to 25,000 (37,500 in Expert Mode, and 50,000 in Master Mode), they will become invincible.
(As opposed to standard invincibility, Oddity can still take damage, but all forms of attack phase through them. This is to keep boss health bars on screen.)

After becoming invincible, Oddity will gain 300,000 extra max health (450,000 in Expert Mode, and 600,000 in Master Mode).
Oddity will then, as a separate step, heal themselves by the amount of max health gained.

Once this process is finished, Oddity will become vulnerable, and the second phase begins.

## Attacks
All attacks are only named internally.

### Dance
Oddity creates a square device out of 2 Charged Blaster Cannons which fires a deathray from the left and right faces.
Oddity then grabs this device from below (moving towards the top of the arena), and dashes around while carrying it, rotating the device and the deathrays it fires.
This device's bottom face always rotates towards where it was created initially.

### Labyrinth
Oddity, using an Electrosphere Launcher, shoots ~6 electrospheres around the arena, quickly flying to the left of the player to lock the arena before they explode.
When the arena is locked, the player is extremely close to the middle-right barrier.
As the arena is locked, the electrospheres immediately explode and create many electric rings, leaving a tight passageway from one side of the arena to the other.

Then, Oddity heads outside of the arena, sitting outside of it vertically, and the closest to the player they can get while still being outside horizontally.
Oddity then fires a deathray, moving to the opposite side of the arena at a steady pace.
To dodge this attack, the player must maneuver to the opposite side of the arena before the deathray hits them.

### Light In Descending Darkness
The background goes completely dark.
Oddity summons the Ultimate Truth.

Oddity quickly dashes towards the player. A beam of light appears in the background, initially vertical and centered on Oddity's position at the time of the dash.
This beam quickly rotates towards the direction Oddity dashes in.
As Oddity gets closer to their target, the beam of light gets wider, reaching ~10 tiles in width when Oddity reaches their target.
When the target's position at the time of the dash starting is reached, the beam disappears and everything inside it takes damage.

This attack's main phase repeats 10 times.

### Rainfall
Oddity creates many Crystal Shard projectiles above the arena, which fall into it as soon as they are created.
These projectiles freeze in place at a (predictable, but seemingly) random position, and create a skewed line, as well as a perfectly vertical line, through themselves.
Crystal Shards start violently shaking once frozen.
After a second of shaking, the Crystal Shards and their lines explode and damage whatever is inside them.

### Shattered
The background goes completely dark.

Oddity creates many randomly-scattered lines inside the arena, with an extremely short delay between the creation of each one.
One second after they are all created, everything inside them takes damage.

### Lightless Eyes
Oddity places many target reticles in the arena, completely covering it except for three circular areas on the edge of the arena.
After three seconds, these circular areas gain seals, and everything outside them takes massive damage.
After another second, these seals start rotating clockwise around the arena at a fast pace, and Oddity starts firing projectiles at players inside them.

# Design

## Player Interactions with Oddity
Oddity is intended to be difficult enough to dodge to where attacking them is risky.
The player should be forced to choose which to prioritize.
Neither choice is beneficial for the player; do they focus on dodging and drag out the fight, or attack and risk dying?
