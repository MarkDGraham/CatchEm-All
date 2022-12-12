using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                  PlayerControls.cs
 *                    Mark Graham
 *                 November 25, 2022
 *  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 */

/*
 * Modification Log:
 *  2022:
 *      Dec:
 *          11: Added pause check to input controls.
 *          11: Bound clamping added to input controls.
 *          11: Movement bounds added to input.
 *      Nov:
 *          25: Commented code.
 *          25: [Fix] Removed RB, added Translate.
 *          25: [Bug] Player falls with Rigidbody(RB).
 *          25: Added player movement code.
 *          24: Added player game object finder.
 *          24: Added Move and Pause actions.
 *          24: Added Input System connection.
 *          24: Script created.
 * 
 */

public class PlayerControls : MonoBehaviour
{
    // Variables:
    [SerializeField] InputActions playerInput;                  // Player input action mapping.
    private InputAction _pause, _move;                          // Individual actions used in mapping.
    private GameObject Player;                                  // Player object for movement.
    private float _moveSpeed = 9.0f;                            // Player movement speed.
    private float _upperBound = 10.0f, _lowerBound = -10.0f;    // Player input bound checking.

    void Awake()
    {
        playerInput = new InputActions();                       // Creates new input mapping.
        Player = GameObject.FindGameObjectWithTag("Player");    // Finds player object in scene.
    }

    // Enables individual input action listeners.
    private void OnEnable()
    {
        _move = playerInput.Player.Move;
        _move.Enable();

        _pause = playerInput.Player.Pause;
        _pause.Enable();
        _pause.performed += Pause;                  // Adds pause action into event system.
    }

    // Disable input action listeners.
    void OnDisable()
    {
        _move.Disable();
        _pause.Disable();
    }

    // Checks for movement action, then moves player repsectivly.
    private void Update()
    {
        if(!(GameManager.instance.GetPauseState()))
        {
            // If input and in bound range, then move player.
            if(_move.ReadValue<float>() <= 1.0 || _move.ReadValue<float>() >= -1.0)
                if (Player.transform.position.x >= _lowerBound && Player.transform.position.x <= _upperBound)
                    Player.transform.Translate(
                        Vector3.right * Time.deltaTime * _move.ReadValue<float>() * _moveSpeed);
        
            // Clamps position to the upper bound and lower bound
            if (Player.transform.position.x >= _upperBound)
                Player.transform.position = new Vector3(_upperBound, 0, 0);     // Fixes float point errors.
            if (Player.transform.position.x <= _lowerBound)
                Player.transform.position = new Vector3(_lowerBound, 0, 0);
        }
        
    }

    // Toggles the game pause state.
    private void Pause(InputAction.CallbackContext context)
    {
        GameManager.instance.TogglePause();
    }
}
