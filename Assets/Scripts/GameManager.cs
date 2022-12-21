using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                              GameManager.cs
 *                                Mark Graham      
 *                            November 29, 2022
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 */

/*
 *  Modification Log:
 *      2022:
 *          December:
 *              20: Implemented game over and pause UI activators.
 *              17: [FIX] End game mechanic placed in seperate conditional
 *                  statement to allow for correction.
 *              17: [BUG] Game ends right as timeup special event called
 *                  (negates the time increase).
 *              17: [FIX] Game over mechanic now in In-Game state.
 *              17: [BUG] Game doesn't stop after timer reaches 0.
 *              11: Implemented end game mechanic.
 *              11: Implemented spawn mechanic.
 *              11: Implemented accessor method to pause value.
 *              01: Implemented default game values.
 *              01: Implmented Game over mechanics.
 *          November:
 *              30: Implemented pause mechanics. 
 *              30: Encapsulation added for time and score.
 *              30: Score methods added.
 *              30: [FIX] Timer - Time.deltaTime is outside of range.
 *              30: [BUG] Timer doesn't count down correctly.
 *              30: Implemented time changing function.
 *              29: Implemented singleton functionality. 
 *              29: Script created. 
 */

public class GameManager : MonoBehaviour
{
    // Enable singleton behavior making sure that only one GameManager can 
    // exist in a scene at a time.
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
            Destroy(this);

        if(instance == null)
            instance = this;
    }

    // Variables:
    private int _score = 0,  _scoreRange = 5;
    private const int _defaultScore = 0;
    private float _timeRange = 5, _timer = 45.0f, _spawnRate = .5f;
    private const float _defaultTimer = 45.0f;
    private bool _isPaused = false, _isOver = false;

    // Methods:
    // Game Layout
    void Update()
    {
        if(_timer <= 0.0f && !(_isPaused || _isOver))       // End game mechanic.
            GameOver();

        // ABSTRACTION:
        if(!(_isPaused || _isOver))
        {
            UpdateTimeValue(-Time.deltaTime);               // Reduces the time clock of the game state.
            if (_spawnRate <= 0.0f)
            {
                _spawnRate = 1.5f;                          // Resets the spawn delay between spawns.
                EntityManager.instance.SpawnObject();       // ABSTRACTION call to spawn enemy.
            }
            _spawnRate -= Time.deltaTime;                   // Countdowns the spawn delay.                  
        }
    }

    /*
     *  Function Name: UpdateTimeValue
     *  Parameters:
     *      _newTime: an float modification value
     *  Description:
     *      Changes the timer in game by a valid time.
     *  Return: N/A
     */
    public void UpdateTimeValue(float _newTime)             // ENCAPSULATION
    {
        if (_newTime >= -_timeRange && _newTime <= _timeRange)
            _timer += _newTime;
    }

    /*
     *  Function Name: GetTime
     *  Parameters: N/A
     *  Description:
     *      Gets time remaining in the game.
     *  Return: float
     */
    public float GetTimeValue()
    {
        return _timer;
    }

    /*
     *  Function Name: UpdateScoreValue
     *  Parameters: 
     *      _newScore: an int modification value
     *  Description:
     *      Changes the score in game by a valid score.
     *  Return: N/A
     */
    public void UpdateScoreValue(int _newScore)
    {
        if(-_scoreRange <= _newScore && _newScore <= _scoreRange)
            _score += _newScore;
    }

    /*
     *  Function Name: GetScoreValue
     *  Parameters: N/A
     *  Description:
     *      Gets the score of the current game.
     *  Return: int
     */
    public int GetScoreValue()                                      // ENCAPSULATION
    {
        return _score;
    }

    /*
     *  Function Name: TogglePause
     *  Parameters: N/A
     *  Description:
     *      Inverses the current value of the pause value.
     *  Return: N/A
     */
    public void TogglePause()
    {
        _isPaused = !_isPaused;
        UIManager.instance.PauseUI();
    }

    /*
     *  Function Name: GetPauseState
     *  Parameters: N/A
     *  Description:
     *      Returns True / False if in a pause state.
     *  Return: N/A
     */
    public bool GetPauseState()
    {
        return _isPaused;
    }

    /*
     *  Function Name: GameOver
     *  Parameters: N/A
     *  Description:
     *      Toggles the GameOver state.
     *  Return: N/A
     */
    public void GameOver()
    {
        _isOver = !_isOver;
        UIManager.instance.GameOverUI();
    }

    public bool GetGameState()
    {
        return _isOver;
    }

    /*
     *  Function Name: ResetGame
     *  Parameters: N/A
     *  Description:
     *      Sets game values back to default game state.
     *  Return: N/A
     */
    public void ResetGame()
    {
        UIManager.instance.ResetGame();
    }

    /*
     *  Function Name: OnCollisionEnter
     *  Parameters: N/A
     *  Description:
     *      Abstracts the destruction call of ball entities.
     *  Return: N/A
     */
    void OnCollisionEnter(Collision other)
    {
        EntityManager.instance.DeactivateObject(other.gameObject);
    }
}
