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
        StartCoroutine(HideCursor());
    }

    private void ToggleMenu()
    {
        _menuOpened = !_menuOpened;

        if (_menuOpened)
        {
            ShowCursor();
            // Aqui chamamos o NavigationManager para mostrar o menu
            FindObjectOfType<NavigationManager>().SwitchToSettings(); // Exemplo: abre configurações
        }
        else
        {
            StartCoroutine(HideCursor());
            FindObjectOfType<NavigationManager>().BackToMain(); // Ou uma função CloseAll
        }
    }

    #region Cursor
    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private IEnumerator HideCursor()
    {
        yield return new WaitForEndOfFrame();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion
}