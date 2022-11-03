using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    //Movement
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float VelRot;
    [SerializeField] private float JumpForce;
    public bool isGrounded = true;
    private Vector3 MoveDirection;
    private Vector3 MoveRotate;

    //Animator
    private Animator anim;
    private AnimatorController animCont;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        animCont = gameObject.GetComponentInChildren<AnimatorController>();
    }

    void Update() {
        Movement();
        //UpdateAnimatorState();
    }

    float verticalAxes;
    float horizontalAxes;
    void Movement() {
        //if (animCont.currentState != animCont.stPunching && animCont.currentState != animCont.stKicking) {
        verticalAxes = Input.GetAxis("Vertical");
        horizontalAxes = Input.GetAxis("Horizontal");
        MoveDirection = transform.forward * verticalAxes;
        MoveRotate = new Vector3(0f, horizontalAxes, 0f);
        transform.Rotate(MoveRotate * VelRot * Time.deltaTime);
        transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
        //}

        if (isGrounded ) {
            //if (animCont.currentState == animCont.stWalking || animCont.currentState == animCont.stBackwalking) {
            if (verticalAxes > 0.1f) {
                animCont.SetAnimatorState(animCont.stWalking);
            } else if (verticalAxes < -0.1f) {
                animCont.SetAnimatorState(animCont.stBackwalking);
            } else {
                animCont.SetAnimatorState(animCont.stIdle);
            }
            //}
        }

        if (verticalAxes > 0.1f) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                animCont.SetAnimatorState(animCont.stRunning);
            } else {
                animCont.SetAnimatorState(animCont.stWalking);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            animCont.SetAnimatorState(animCont.stJumping);
            rb.AddForce(Vector3.up * JumpForce);
        }

        if (Input.GetMouseButtonDown(0)) {
            animCont.SetAnimatorState(animCont.stPunching);
        } else if (Input.GetMouseButtonDown(1)) { 
            animCont.SetAnimatorState(animCont.stKicking);
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }  
}