using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                                  Ball.cs
 *                                Mark Graham      
 *                              December 11, 2022
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 */

/*
 * Modification History:
 *      2022:
 *          December:
 *              11: Base class method implmented.
 *              11: Script created.
 */
public class Ball : MonoBehaviour
{
    // Variables:
    private int _eventValue = 1;

    // POLYMORPHISM
    // Base method to be overrided in child classes.
    public virtual void SpecialEvent()
    {
        GameManager.instance.UpdateScoreValue(_eventValue);
    }
}
