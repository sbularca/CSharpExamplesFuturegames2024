using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ControllerMovement : MonoBehaviour {
    [SerializeField] CharacterSettings characterSettings;

    private CharacterController characterController;
    private ICharacterState currentState;
    private InputHandler inputHandler;

    private bool isRotating;
    public Vector3 velocity;

    private void Start() {
        inputHandler = new InputHandler();
        inputHandler.RegisterPlayerInput();

        characterController = GetComponent<CharacterController>();
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
        Vector3 moveDirection = transform.TransformDirection(moveInput) * speed;
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
        transform.Rotate(rotation * Time.deltaTime);
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

    private void OnDestroy() {
        inputHandler.Dispose();
    }
}
