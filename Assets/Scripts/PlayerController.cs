using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Animator anim;
    [SerializeField] private float MoveSpeed = 20f;
    [SerializeField] private float VelRot = 100f;
    [SerializeField] private float JumpForce = 20f;
    private bool doJump = false;
    private int cont = 0;

    private Vector3 MoveDirection;
    private Vector3 MoveRotate;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalAxes = Input.GetAxis("Vertical");
        float horizontalAxes = Input.GetAxis("Horizontal");

        MoveDirection = transform.forward * verticalAxes;

        MoveRotate = new Vector3(0f, horizontalAxes, 0f);

        transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
        transform.Rotate(MoveRotate * VelRot * Time.deltaTime);

        if (verticalAxes > 0.1f) {
            anim.SetBool("walk", true);
        } else {
            anim.SetBool("walk", false);
        }

        if (Input.GetButtonDown("Jump") && cont<=1)
        {
            doJump = true;
            cont++;
            anim.SetBool("jump", true);
        }
    }

    private void FixedUpdate()
    {
        if (doJump)
        {
            rb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
            doJump = false;
            anim.SetBool("jump", false);
            
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        cont = 0;
    }
}