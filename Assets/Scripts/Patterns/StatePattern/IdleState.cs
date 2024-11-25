using UnityEngine;

public class IdleState : ICharacterState {
    private readonly InputHandler inputHandler;
    private readonly CharacterSettings settings;
    private readonly PlayerMovement controllerMovementReference;
    public IdleState(PlayerMovement controllerMovementReference, InputHandler inputHandler, CharacterSettings settings) {
        this.controllerMovementReference = controllerMovementReference;
        this.inputHandler = inputHandler;
        this.settings = settings;
    }

    public void EnterState() {
        // update animations here if any
    }

    public void UpdateState() {
        controllerMovementReference.velocity.x = 0f;
        controllerMovementReference.velocity.z = 0f;

        if (inputHandler.IsJumping && controllerMovementReference.IsGrounded()) {
            controllerMovementReference.SetState(new JumpingState(controllerMovementReference, inputHandler, settings, this));
        }

        if (inputHandler.MovementData != Vector2.zero) {
            controllerMovementReference.SetState(new WalkingState(controllerMovementReference, inputHandler, settings));
        }
    }
    public void ExitState() { }
}
