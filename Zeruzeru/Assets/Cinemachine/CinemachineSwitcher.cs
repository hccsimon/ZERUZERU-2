using UnityEngine;
using UnityEngine.InputSystem;


public class CinemachineSwitcher : MonoBehaviour
{

    public Animator animator;
    public PlayerChanger PlayerChanger;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            animator.Play("PoliceCam");
            PlayerChanger.Changer(1);
        }
        else if(Input.GetKeyDown(KeyCode.F2))
        {
            animator.Play("ZeruzeruCam");
            PlayerChanger.Changer(2);
        }
    }
}
