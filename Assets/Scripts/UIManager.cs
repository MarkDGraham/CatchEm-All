using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *                                  UIManager.cs
 *                                   Mark Graham
 *                                December 16, 2022
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 */

/*
 * Modification History:
 *      2022:
 *          Dec:
 *             17:
 *             16: Added In-Game UI text attachments for proper game
 *                 stats tracking.
 *             16: Singleton behavior added.
 *             16: Script created. 
 * 
 * 
 */

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    // Variables:
    [SerializeField] TextMeshProUGUI _score, _timer, _gameOverScore;
    [SerializeField] GameObject _pauseUI, _gameOverUI, _mainUI;

    void Update() 
    {
        _score.text = GameManager.instance.GetScoreValue().ToString();
        _timer.text = GameManager.instance.GetTimeValue().ToString("F0");
    }

    public void PauseUI()
    {
        if(GameManager.instance.GetPauseState())
            _pauseUI.SetActive(true);
        else
            _pauseUI.SetActive(false);
    }

    public void GameOverUI()
    {
        _gameOverScore.text = _score.text;

        if(GameManager.instance.GetGameState())
            _gameOverUI.SetActive(true);
        else
            _gameOverUI.SetActive(false);

        MainUI();
    }

    private void MainUI()
    {
        if (GameManager.instance.GetGameState())
            _mainUI.SetActive(false);
        else
            _mainUI.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }
}
