using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    public MenuPanel mainMenu;
    public MenuPanel creditsMenu;
    public MenuPanel settingsMenu;
    public MenuPanel controlsMenu;

    private MenuPanel currentActiveMenu;
    [SerializeField] private GameObject _actionPlayer;

    void Start()
    {
        _actionPlayer.SetActive(false);
        currentActiveMenu = mainMenu;
        mainMenu.Show();
    }

    public void SwitchToCredits() => ChangeMenu(creditsMenu);
    public void SwitchToSettings() => ChangeMenu(settingsMenu);
    public void SwitchToControls() => ChangeMenu(controlsMenu); 
    public void BackToMain() => ChangeMenu(mainMenu);
    public void StartGameSequence()
    {
        mainMenu.Hide();
        _actionPlayer.SetActive(true);

        // Acessa o PlayerMenu para esconder o cursor
        PlayerMenu pm = FindObjectOfType<PlayerMenu>();
        if (pm != null)
        {
            pm.StartGameplay();
            pm.HideCursor();
        }
    }

    private void ChangeMenu(MenuPanel targetMenu)
    {
        _actionPlayer.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (currentActiveMenu != null)
        {
            currentActiveMenu.Hide();
        }

        targetMenu.Show();
        currentActiveMenu = targetMenu;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}