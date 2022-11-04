using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
    public int stIdle = 0;
    public int stWalking = 1;
    public int stBackwalking = 2;
    public int stRunning = 3;
    public int stPunching = 4;
    public int stKicking = 5;
    public int stJumping = 6;
    public int stDying = 7;
    //public int previousState = 0;
    public int currentState = 0;

    private PlayerController plyCont;
    private Animator anim;


    void Start() {
        plyCont = gameObject.GetComponentInParent<PlayerController>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update() {
        //if (previousState != currentState) {
            anim.SetBool("punch", false);
            anim.SetBool("jump", false);
            anim.SetBool("kick", false);
            anim.SetBool("walk", false);
            anim.SetBool("backwalk", false);
            anim.SetBool("death", false);
            anim.SetBool("run", false);

            switch (currentState) {
                case 0:
                    break;
                case 1:
                    anim.SetBool("walk", true);
                    break;
                case 2:
                    anim.SetBool("backwalk", true);
                    break;
                case 3:
                    anim.SetBool("run", true);
                    break;
                case 4:
                    anim.SetBool("punch", true);
                    break;
                case 5:
                    anim.SetBool("kick", true);
                    break;
                case 6:
                    anim.SetBool("jump", true);
                    break;
                case 7:
                    anim.SetBool("death", true);
                    break;
            }
            //previousState = currentState;
        //}
    }

    public void KickIsOver() {
        anim.SetBool("kick", false);
        currentState = stIdle;
    }

    public void PunchIsOver() {
        anim.SetBool("punch", false);
        currentState = stIdle;
    }
    
    public void JumpIsOver() {
        anim.SetBool("jump", false);
        currentState = stIdle;
    }

    public void SetAnimatorState(int state) {
        currentState = state;
    }
}
