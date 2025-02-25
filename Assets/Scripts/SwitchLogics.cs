using UnityEngine;

public class SwitchLogics : MonoBehaviour
{
    private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void Open()
        {
            animator.SetBool("isOpen", true);
        }
        public void Close()
        {
            animator.SetBool("isOpen", false);
        }
}
