using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMenu : MonoBehaviour
{
    [Header("Screens Settings")]
    [SerializeField] private InputActionReference _uiAction;

    private bool _menuOpened;
    private bool _gameplayStarted;

    private void Start()
    {
        ShowCursor();
        _gameplayStarted = false;
        _menuOpened = false;
    }

    private void Update()
    {
        if (_gameplayStarted)
        {
            if (_uiAction.action.WasPressedThisFrame())
            {
                ToggleMenu();
            }
        }
    }

    public void StartGameplay()
    {
        _gameplayStarted = true;
        _menuOpened = false; 
        HideCursor();
    }

    private void ToggleMenu()
    {
        _menuOpened = !_menuOpened;

        if (_menuOpened)
        {
            // Abrindo Menu
            ShowCursor();
            FindObjectOfType<NavigationManager>().SwitchToSettings();
        }
        else
        {
            HideCursor();
            FindObjectOfType<NavigationManager>().StartGameSequence();
        }
    }

    #region Cursor
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion
}