using UnityEngine;
using UnityEngine.InputSystem;

public class Diario_Prototype : MonoBehaviour
{
    [SerializeField] bool DiarioAberto = false;
    [SerializeField] InputActionReference UiAction;
    [SerializeField] CanvasGroup UiDiario;

    private void Start()
    {
        DiarioAberto = false;
    }

    private void Update()
    {
        if (UiAction.action.WasPressedThisFrame())
        {
            EstadoDoDiario();
        }
    }
    void EstadoDoDiario()
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
    }
    void Mostrar(CanvasGroup uiDiario)
    {
        UIManeger.Instance.Show(uiDiario);
    }
}