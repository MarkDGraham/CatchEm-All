using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                              PlayerMechanics.cs
 *                               December 11, 2022
 *                                  Mark Graham
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 */

/*
 * Modification History:
 *      2022:
 *          December:
 *              12: Comments added.
 *              11: Implemented polymorphism calls.
 *              11: Implemented collision detection.
 *              11: Script created.
 * 
 */
public class PlayerMechanics : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        // Calls parent class method.
        if(other.gameObject.name == "BasicBall")
        {
            other.gameObject.GetComponent<Ball>().SpecialEvent();
            EntityManager.instance.DeactivateObject(other.gameObject);
        }

        // Calls child class method.
        if (other.gameObject.name == "ScoreUpBall")
        {
            other.gameObject.GetComponent<ScoreUp>().SpecialEvent();
            EntityManager.instance.DeactivateObject(other.gameObject);
        }

        // Calls child class method.
        if (other.gameObject.name == "ScoreDownBall")
        {
            other.gameObject.GetComponent<ScoreDown>().SpecialEvent();
            EntityManager.instance.DeactivateObject(other.gameObject);
        }

        // Calls child class method.
        if (other.gameObject.name == "TimeUpBall")
        {
            other.gameObject.GetComponent<TimeUp>().SpecialEvent();
            EntityManager.instance.DeactivateObject(other.gameObject);
        }

        // Calls child class method.
        if (other.gameObject.name == "TimeDownBall")
        {
            other.gameObject.GetComponent<ScoreDown>().SpecialEvent();
            EntityManager.instance.DeactivateObject(other.gameObject);
        }
    }
}
