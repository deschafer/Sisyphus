using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PU_HUD_HANDLER : MonoBehaviour
{
    /* The PU_HUD_HANDLER is an abstract class so that all of the subclasses of this class can and are required to overwrite unwritten functions and to prevent the
     * script from being directly applied to any game object as unity does not allow abstract classe to be attached to a gameObject.
     */
    public const float maxAlpha = 1.00f;
    public const float minAlpha = 0.00f;
    public const float duration = 3.00f;
    public int flag = 1;
   
    public TimeOut timeOut;
    /*The floats maxAlpha, minAlpha, and duration are all floats that are accessed by both subclasses and unrelated classes.  The min and max alpha values 
     * are the minimum and maximum visibility value for the sprites specified.  The values must be between 0 and 1.  They are set from the beginning such that
     * the maximum is fully visible and the minimum is fully transparent.  The duration is a float that reflects the number of seconds that 
     * it takes for the powerup icons to either go from fully visible to fully transparent.  This value can be anything greater than 0, however, numbers greater than 1000 
     * tend to cause the program to slow beyond being able to see the powerup.
     * The flag variable is used to tag whether or not a powerup is visible to the player
     * The TimeOut timeOut variable is a reference to the powerup script TimeOut.  This reference allows the class to see the type variable of the TimeOut class
     * dictating which powerup is active and allows the subclasses to see the timeActive which is the duration of the powerup.\
     */

    public SpriteRenderer powerUp;
    /* The sprite renderer powerUp is the powerup sprite that is displayed to the player. It is a default unityengine.ui type.
     */

    // Start is called before the first frame update
    void Start()
    {
        powerUp.color = new Color(1f, 1f, 1f, 0.0f);
        timeOut = FindObjectOfType<TimeOut>();
    }
    /* At start the powerup color is set to the default colors (1f) and the alpha value is set to 0.0f so that the powerup sprites are fully
     * transparent.  The values entered into the new color() function must all be floats.
     */

    // Update is called once per frame
    public abstract void Update();
    /* The Update function is different for each of the powerups and thus is abstract to allow the function to be overwritten by any and all subclasses.
     */

    /*public void powerUpTimer()
    {
        timer.text = " " + timeOut.timerActive;
    }*/
}
