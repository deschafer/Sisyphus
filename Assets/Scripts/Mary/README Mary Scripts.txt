README Mary Scripts Folder

Right now in the scripts folder I have 5 scripts—a superclass for powerup, a temporary and permanent subclass of powerup, a poweruptimer manager, and a player manager proxy.

The permanent and temporary powerups both work right now (though they only affect health.) The permanent powerup (triggered by collision with the player) adds 10 to health. 
The temporary powerup adds 10 (there's a bug right now that actually adds 20—I'm working on it), then after 10 seconds, decreases the health by 10 again. 

The temporary powerup needs another object in the scene that has the PowerUpTimer script attached to it, because the temporary powerup is destroyed when touched.
This way, the timerobject carries out the actual powerup timer after the powerup has been destroyed. 

Right now, the powerups work with Max's player health script. (Not the proxy I was using before). 
