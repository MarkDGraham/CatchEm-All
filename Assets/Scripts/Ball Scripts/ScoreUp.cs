using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                                  ScoreUp.cs
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

public class ScoreUp : Ball
{
    // Variables:
    private int _eventScore = 5;

    // POLYMORPHISM
    // Overrides base class Ball.
    public override void SpecialEvent()
    {        
        GameManager.instance.UpdateScoreValue(_eventScore);
    }
}
