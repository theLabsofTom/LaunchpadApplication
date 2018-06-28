Thank you for considering me for the Launchpad program.

This is my attempt at the third challenge: the game.

This project actually contains two attempts at the challenge. The first attempt controlled the bird through physics forces and required the player to tap 'Space' to flap their wings and use the second analogue stick on the controller to control the pitch and roll. The angle of the birds wings relative to the y plane effected how far you could glide without flapping and in which direction you would glide. The first analogue stick could be used to direct the force of the flap, allowing you to fly directly upwards on no input, purely in one direction on maximum input or any interpolation between the two using finer input
The resulting bird had a satisfying take off and straight line flight pattern but was very frustrating to maneuver while being pursued by a dragon through a cityscape. By making the player responsible for all the angles and force vectors, I'd actually made it more difficult to consistantly control.

The second attempt sees the bird constantly moving forward through simple lerps with no take off or landing mechanics. It uses the same movement script as the dragon but with a much higher maneuverability setting. This much simpler, much less accurate model of the bird's flight is much easier to control and could be ported to mobile with ease. The breif feels like it would be most comfortable on mobile, given it's simple nature and the similarities to "Temple Run" and other mobile, infinite runner games.

The total amount of time spent on this project is ~20 hours. That includes the redesign of the bird, the finding and implementing of external assets and the un-implementing of those assets after my aging laptop could not handle the increase load. There is also a CitySpawner script that randomly generates an arbitrarily large city and fills it with coins which I am particularly proud of. I did not make the game in a single sitting but rather lots of short sittings of 1-3 hours each with long gaps of several days between them due to my schedule. This undoubtably added to my development time as stopping and starting in this manner is always less efficient than focused work.


============Simple Bird===========
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


You constantly move forwards, making Pitch and Elevation interchangable. You change your elevation by changing your pitch and waiting for the bird to move.

The dragon chases you, always coming towards you in a straight line. If a building gets in the way, the dragon destroys it. The dragon flies significantly faster than you in a straight line and will catch up easily if you allow it to. It will slow down if it has to turn to face you so fly in an eratic pattern to win.



*the rotation is snapped to 90 degrees to match the grid layout of the city.

**you cannot stop but you can slow down to make turning easier. It is a "slow down" button rather than a "go faster" button as, this being a race for your life, you will want to go fast more often than slow.



===============Original Bird=================
If you want to try your hand at the original bird design, there is a level in the project set up specially for that purpose. Unfortunately, there is no follow camera that follows the original bird so use both the editor tab and the game tab to watch the birds movement.

It only supports keyboard controls as controller support was added later.

::KEYBOARD CONTROLLS::
Space --- Flap wings and go directly up (tap rapidly to take off)
WASD + Space --- Flap wings and go in the direction specified. (tap space rapidly to take off. WASD does nothing unless you also tap Space)
Arrow Keys --- change pitch and yaw. (This changes which way you glide begween flaps, how quickly you decend without flapping and changes the direction your flaps propel you in. Flaps always propel you along your relative "up" vector)
