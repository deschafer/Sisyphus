using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Parent class for classes that need to update the UI regularly such as the
   level progress bar.
*/
public abstract class UpdateUIElements : MonoBehaviour
{
    abstract public void UpdateUIElement(float info);
}
