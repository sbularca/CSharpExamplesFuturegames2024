using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement {
    private readonly CharacterSettings characterSettings;
    private readonly CharacterController characterController;

    public PlayerMovement(CharacterSettings characterSettings, CharacterController characterController) {
        this.characterSettings = characterSettings;
        this.characterController = characterController;
    }

    // TODO: this variable to exist in a different place like a data class
    public Vector3 velocity;

    private ICharacterState currentState;
    private InputHandler inputHandler;
    private bool isRotating;

    public void Initialize() {
        inputHandler = new InputHandler();
        inputHandler.RegisterPlayerInput();

        SetState(new IdleState(this, inputHandler, characterSettings));

        velocity = Vector3.zero;
    }

    private void Update() {
        currentState.UpdateState();
        RotateCharacter();

        if(!IsGrounded()) {
            velocity.y -= characterSettings.gravity * Time.deltaTime;
        }
        else if(velocity.y <= 0) {
            velocity.y = -2f;
        }
        characterController.Move(velocity * Time.deltaTime);
    }

    public void MoveCharacter(float speed) {
        Vector3 moveInput = new Vector3(inputHandler.MovementData.x, 0f, inputHandler.MovementData.y).normalized;
        Vector3 moveDirection = characterController.transform.TransformDirection(moveInput) * speed;
        velocity.x = moveDirection.x;
        velocity.z = moveDirection.z;
    }

    private void RotateCharacter() {
        if(Mouse.current.rightButton.wasPressedThisFrame) {
            isRotating = !isRotating;

            Cursor.lockState = isRotating ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isRotating;
        }

        if(!isRotating) {
            return;
        }

        Vector3 rotation = new Vector3(0f, inputHandler.LookData.x * characterSettings.rotationSpeed, 0f);
        characterController.transform.Rotate(rotation * Time.deltaTime);
    }

    public bool IsGrounded() {
        return characterController.isGrounded;
    }

    public void SetState(ICharacterState newState) {
        currentState?.ExitState();
        newState.EnterState();
        Debug.Log($"{currentState} => {newState}");
        currentState = newState;
    }

    private void OnDispose() {
        inputHandler.Dispose();
    }
}
