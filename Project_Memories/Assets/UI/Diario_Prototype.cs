using UnityEngine;
using UnityEngine.InputSystem;

public class Diario_Prototype : MonoBehaviour
{
    [SerializeField] bool DiarioAberto = false;
    [SerializeField] InputActionReference UiAction;
    [SerializeField] CanvasGroup UiDiario;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DiarioAberto = false;
    }

    private void Update()
    {
        if (UiAction.action.WasPressedThisFrame())
        {
            DiaryStatus();
        }
    }
    void DiaryStatus()
    {
        DiarioAberto = !DiarioAberto;
        if (!DiarioAberto)
        {
            Esconder(UiDiario);
        }
        else
        {
            Mostrar(UiDiario);
        }
    }

    void Esconder(CanvasGroup uiDiario)
    {
        UIManeger.Instance.Hide(uiDiario);
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Mostrar(CanvasGroup uiDiario)
    {
        UIManeger.Instance.Show(uiDiario);
        Cursor.lockState = CursorLockMode.None;
    }
}