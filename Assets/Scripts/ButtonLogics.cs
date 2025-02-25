using UnityEngine;

public class ButtonLogics : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void AlwaysOpen()
    {
        animator.SetTrigger("Open");
    }
}
