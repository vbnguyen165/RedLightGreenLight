# Red Light, Green Light

This project is a simple implementation of the game **Red Light, Green Light** from the TV show *Squid Game*. In this single-player game, the goal is to move from the starting position to the finish line. To move, player simply presses the arrow key corresponding to the direction that they wants to move. One special constraint is that **the player is only allowed to move when the green light is on and has to stop/stand still when the light turns red**.

A *Giant Doll* is used to track the movements of the player. During the duration of green light, the doll stands still with its back facing the player. The player should move toward the finish line during this time, which is located near the doll. The duration of green light is the duration of the song played by the doll. When red light starts, the doll turns around and detects any movement occurring during this time. The light switches from red to green when the doll has turned back to its original position with its back facing the player.

The player has to reach the finish line within 7 green lights in order to win this game. If the player is moving when the red light is on, enters the dead zone by running away from the doll, or has not reached the finish line after 7 green lights, the player is shot immediately. The game ends when either the player wins or have been shot.

## Graphics Credits
3D Giant Doll Model: [2Konseil on Sketchfab](https://sketchfab.com/3d-models/squid-game-giant-doll-6f9049e47c4e4e7cb3e6dcf9535d46fa)
3D Player Model: [Character Amy from Mixamo](https://www.mixamo.com/)
Walls Texture: [588ku on Pngtree](https://pngtree.com/freebackground/color-cartoon-flat-six-children-s-day-banner-background_1075779.html)
Floor Texture: [Wesley Tingey on Unsplash](https://unsplash.com/photos/ZdOW9Qd8mQo)
## Sound Credits
Doll Song and Turning Sound are adapted from Squid Game, directed by Hwang Dong-hyuk.
Walking Sound Effects: [Sneaker Shoe On Concrete Floor Fast Pace 1 by fesliyan Studios](https://www.fesliyanstudios.com/royalty-free-sound-effects-download/footsteps-31)
Gun Shot Sound Effect: [12 Gauge Pump Action Shotgun Close Gunshot B by fesliyan Studios](https://www.fesliyanstudios.com/royalty-free-sound-effects-download/gun-shooting-300)
