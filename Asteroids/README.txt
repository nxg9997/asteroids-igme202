Nathan Glick
IGME 202-02
Project 2 - Asteroids

Description:
	This is a game that simulates the original Asteroids game, created for the Atari.

User Responsibilities:
	The user controls a ship (looks like a triangle) by using the left and right arrow keys to rotate the ship, the up arrow key to accelerate, and the space bar to shoot bullets. Asteroids spawn every few seconds and travel acroos the screen. The user must navigate the ship to avoid the asteroids, and use its bullets to shoot and destroy the asteroids. If the ship is hit by asteroids 3 times, the game is over.

Above and Beyond:
	First, I created both starting and game over screens. Upon losing your last life, the score will be written to a binary file called "data", and the game over screen will read the file in order to display your final score. When the ship takes damage, there is a brief period of invincibilty, which is shown by the ship flashing (this also shows that the ship had taken damage). Finally, I added sound effects for when collisions occur.

Borrowed Assets:
	1) Hyperspace font from: https://www.dafont.com/hyperspace.font
	2) Sound Effects from: http://www.classicgaming.cc/classics/asteroids/sounds
	3) All other graphics were created by me.

Known Bugs/Issues:
	Occationally collisions won't be detected, I'm not sure why this happens, but it only happens once in a while and shouldn't affect gameplay too much. (Might be a side-effect from fixing an issue where the ship could only collide with the first instance of an asteroid)