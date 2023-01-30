using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [Header("Bools")]
    [SerializeField] bool sleep;

    public Animator coralAnimator;
    public Animation test;
    public GameManager gm;

    [Header("AnimationHash")]
    int hunger = Animator.StringToHash("BoredLoop");
    int tired = Animator.StringToHash("");
    int thirsty = Animator.StringToHash("ThirstyLoop");
    int bored = Animator.StringToHash("Bored");
    private void Start()
    {
    }
    private void Update()
    {
        Sleep();
        CurrentAnimation();
        
    }
    void CurrentAnimation()
    {
        //coralAnimator.GetCurrentAnimatorStateInfo(0);
        if (gm.thirst < 20)
        {
            coralAnimator.SetBool("Thirsty", true);
        }
        else 
        {
            coralAnimator.SetBool("Thirsty", false);
            if(gm.hunger < 20)
            {
                coralAnimator.SetBool("Hungry", true);
            }
            else
            {
                coralAnimator.SetBool("Hungry", false);
            }
        }
    }
    public void Sleep()
    {
        coralAnimator.SetBool("Sleep", gm.sleeping);
    }
}
