using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public static AnimatorManager Instance;
    private void Awake()
    {
        if(Instance == null && Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CurrentAnimation(Animator animator,string name)
    {
        if (!string.IsNullOrEmpty(name))
        { 
            animator.Play(name); 
        }
    }
}
