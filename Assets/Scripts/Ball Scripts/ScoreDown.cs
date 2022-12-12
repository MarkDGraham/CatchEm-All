using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                                ScoreDown.cs
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

// INHERITANCE
public class ScoreDown : Ball
{
    // Variables:
    private int _eventScore = -5;

    // POLYMORPHISM
    // Overrides base class in Ball.cs
    public override void SpecialEvent()
    {        
        GameManager.instance.UpdateScoreValue(_eventScore);
    }
}
