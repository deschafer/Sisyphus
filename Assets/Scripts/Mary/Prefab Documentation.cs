using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Prefab_Documentation : MonoBehaviour
{
}

/*
 *       This script serves at the documentation for the PowerUpManager Prefab.
 *       
 *       PURPOSE:
 *       The PowerUpManager serves the purpose of controlling the behavior of the PowerUps at runtime for the game Sisyphus. The Manager
 *       decides when and where the PowerUps will be generated, as well as how often they are generated, and what types will be made.
 *       
 *       COMPONENTS:
 *       The PowerUp Manager requires several scripted classes, though it doesn't require any physics or material objects (it is attached  
 *       to an empty game object.)
 *       
 *       The PowerUp Manager is composed of the following scripts:
 *       
 *      The main control script (implemented with singleton pattern):
 *       -The PowerUpManager Script 
 *       
 *      The PowerUp action cripts, subclasses of the PowerAction class
 *       -PowerDrop
 *       -TimeOut
 *       
 *      The PowerUp Factory scripts, subclasses of the PowerUpFactory script (implemented with the factory pattern)
 *       -TemporaryFactory
 *       -PermanentFactory
 *       
 *       The PowerUpManager prefab also includes audio source child objects, to make the powerup sounds. On the prefab, these sounds are:
 *          -twang
 *          -????
 *          
 *       In the PowerUpManager prefab, there are also some preloaded assets into slots on the corresponding scripts. For instance,
 *       the Factory scripts both have an array of sprites, where (from 1st to 4th) the elements are Gold Apple, Winged Sandal, Lightning,
 *       and Trident. The Action scripts have the twang sound both loaded into their corresponding audio source. 
 *       
 *       
 *       BEHAVIOR:
 *       The basic behavior of the prefab is as follows:
 *              1. At the beginning, the PowerUpManager script links the other scripts together and creates an inital powerup. 
 *              2. In the Manager's update function, the manager keeps track of the time. Every 15 seconds (changeable if desired) a 
 *                 new, random powerup is generated and placed in the scene based on an offset of player position. The powerup creation
 *                 is handled by the two factory functions.
 *              3. When a powerup collides with a player, a signal is sent to the action scripts of the PowerUpManager. These scripts handle
 *                 the action by communicating with the player and adjusting the player's statistics as necessary. 
 *              4. The PowerUp uses an algorithm to increase difficulty by adjusting (at runtime) the Temporary Powerup's timing, and the
 *                 the Permanent PowerUp's boost amount
 *                 
 *       WHAT CAN BE CHANGED?
 *          There are several ways this prefab can be adapted to suit your purposes:
 *              -The sprites can be changed in the Factory scripts by simply dragging and dropping your preferred sprites into the corresponding 
 *               variable slots
 *              -The audio clips can be changed by adding the new audio as a child component, and selecting that audio child component inside the
 *               audio slots on the Action scripts.
 *              -The variables for seconds the powerup lasts and the boost amount the powerup gives can be changed inside the Action scripts. They
 *               can also be changed at runtime using the setTime() and setAmount() functions, respectively.
 *              -The difficulty can be changed using the algorithm variables located in the PowerUpManager singleton class. The variables are named 
 *               intutively to control the update and time variables. 
 *       
 *     Advanced Prefab Documentation:
 *     
 *       
 *       
 *       
 */
