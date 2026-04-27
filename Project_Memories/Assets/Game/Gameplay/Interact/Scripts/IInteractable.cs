namespace Memorias.Gameplay.Interact
{
    public interface IInteractable
    {
        public void OnInteract();
        public void Selected();
        public void Deselected();
    }
}