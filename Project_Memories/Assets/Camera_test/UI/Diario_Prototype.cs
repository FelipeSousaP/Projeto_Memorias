using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Diario_Prototype : MonoBehaviour
{
    /// <summary>
    /// "WasPressedThisFrame" = evita que o evento seja chaamdo um trilhão de vezes em um clique
    /// o Editor da unity nao desativa 100% o cursor por questãod e segurança
    /// serve apenas pro editor (Mouse.current.leftButton.wasPressedThisFrame)
    /// </summary>
    [Header("Screens Settings")]
    [SerializeField] private InputActionReference _uiAction;
    [SerializeField] private CanvasGroup _startScreen;
    [SerializeField] private CanvasGroup _uiMenuScreen;
    
    bool _menuOpened;
    bool _gameplayStarted;
    private void Start()
    {
        UIManeger.Instance.Show(_startScreen);
        _gameplayStarted = false;
        _menuOpened = false;
    }
    
    private void Update()
    {
        if (_gameplayStarted)
        {
            //abrir menu
            if (_uiAction.action.WasPressedThisFrame())
            {
                MenuStatus();
            }
        }
        else
        {
            GameplayDisabled();
        }
    }
    void GameplayDisabled()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            UIManeger.Instance.Hide(_startScreen);
            StartCoroutine(HideCursor());
            _gameplayStarted = true;
        }
    }

    void MenuStatus()
    {
        _menuOpened = !_menuOpened;
        if (_menuOpened)
        {
            ShowCursor();
            UIManeger.Instance.Show(_uiMenuScreen);
        }
        else
        {
            StartCoroutine(HideCursor());
            UIManeger.Instance.Hide(_uiMenuScreen);
        }
    }

    #region Cursor
    void ShowCursor() => Cursor.lockState = CursorLockMode.None;
    IEnumerator HideCursor()
    {
        Debug.Log("cursor sumiu");
        yield return new WaitForEndOfFrame();
        Debug.Log("cursor sumiu mesmo");
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion
}