using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private FPMovementController movementController;
    private LookController lookController;
    private ShootController shootController;


    private void Start()
    {
        movementController = GetComponent<FPMovementController>();
        lookController = GetComponentInChildren<LookController>();
        shootController = GetComponentInChildren<ShootController>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            movementController.Jump();
        }

        if (Input.GetButton("Fire1"))
        {
            shootController.Shoot();
        }

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        Move(new Vector3(xMovement, 0, zMovement));

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Look(new Vector2(mouseX, mouseY));


        
    }


    private void Move(Vector3 direction)
    {
        movementController.SetMoveDirection(direction);
    }

    public void Look(Vector2 mouseVector)
    {
        lookController.SetLookVector(mouseVector);
    }

    //private void Shoot(InputAction.CallbackContext ctx)
    //{
    //    shootController.Shoot(true);
    //}

    //private void StopShoot(InputAction.CallbackContext ctx)
    //{
    //    shootController.Shoot(false);
    //}


}