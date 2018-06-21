Thank you for considering me for the Launchpad program.

This is my attempt at the third challenge: the game.

This project actually contains two attempts at the challenge. The first attempt controlled the bird through physics forces and required the player to tap 'Space' to flap their wings. The second attempt sees the bird constantly moving through simple lerps. The physics driven bird was unfortunately too complex to control in high stress situations, such as being chased by a dragon, hence the development of the second, simpler control scheme which is what I present now.

The total amount of time spent on this project is ~20 hours. That includes the redesign of the bird, the finding and implementing of external assets and the un-implementing of those assets after my aging laptop could not handle the increase load. There is also a CitySpawner script that randomly generates an arbitrarily large city and fills it with coins which I am particularly proud of.


::KEYBOARD CONTROLS::
W/S --- Pitch up and down (hold)
A/D --- Yaw (tap to rotate 90 degrees)*
Q/E --- Roll (hold to rotate up to 100 degrees)
Left Shift --- Slow down**


::CONTROLLER CONTROLS::
D-PAD Y Axis --- Pitch (hold)
D-PAD X Axis --- Yaw (tap to rotate 90 degrees*)
Right Stick X Axis --- Roll
LB --- Slow Down***


You constantly move forwards, making Pitch and Elevation interchangable. You change your elevation by changing your pitch.

The dragon chases you, always coming towards you in a straight line. If a building gets in the way, the dragon destroys it. The dragon flies significantly faster than you in a straight line and will catch up easily if you allow it to. It will slow down if it has to turn to face you so fly in an eratic pattern to win.



*the rotation is snapped to 90 degrees to match the grid layout of the city.

**you cannot stop but you can slow down to make turning easier. It is a "slow down" button rather than a "go faster" button as, this being a race for your life, you will want to go fast more often than slow.