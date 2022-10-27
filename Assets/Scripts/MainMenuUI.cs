using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    // MM User Interface Variables
    // Game object for Main Menu UI Components
    [SerializeField] private GameObject _mainMenu;

    // Game object for Helpful Info UI Components
    [SerializeField] private GameObject _infoMenu;

    // MM User Interafce Methods

    /*
     * Name: PlayGame
     * Parameters: N/A
     * Return: N/A
     * Description:
     *   Changes from Main Menu Scene to Game Scene.
     */
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    /*
     * Name: QuitGame
     * Parameters: N/A
     * Return: N/A
     * Description:
     *   In Editor:
     *      Deactivates the playmode and returns to editing mode.
     *   In Build:
     *      Quits the game.
     */
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    /*
     * Name: HelpfulInfo
     * Parameters: N/A
     * Return: N/A
     * Description:
     *  Deactivates the Main Menu UI and activates Helpful Info UI.
     */
    public void HelpfulInfo()
    {
        _infoMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    /*
     * Name: ReturnMM
     * Parameters: N/A
     * Return: N/A
     * Description:
     *   Deactivates the Helpful Info UI and activates Main Menu UI.
     */
    public void ReturnMM()
    {
        _mainMenu.SetActive(true);
        _infoMenu.SetActive(false);
    }
}
