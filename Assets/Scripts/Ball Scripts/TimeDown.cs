using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                                 TimeDown.cs
 *                                 Mark Graham      
 *                              December 11, 2022
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 */

/*
 * Modification History:
 *      2022:
 *          December:
 *              11: Child class method implmented.
 *              11: Script created.
 */

public class TimeDown : Ball
{
    // Variables:
    private float _eventTime = -3.0f;

    // POLYMORPHISM
    // Overrides base class in Ball.
    public override void SpecialEvent()
    {
        GameManager.instance.UpdateTimeValue(_eventTime);
    }
}
