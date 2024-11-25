using UnityEngine;

public class WalkingState : ICharacterState {
    private readonly PlayerMovement controllerMovementReference;
    private readonly InputHandler inputHandler;
    private readonly CharacterSettings settings;

    public WalkingState(PlayerMovement controllerMovementReference, InputHandler inputHandler, CharacterSettings settings) {
        this.controllerMovementReference = controllerMovementReference;
        this.inputHandler = inputHandler;
        this.settings = settings;

    }

    public void EnterState() {
        // update animations here if any
    }

    public void UpdateState() {
        controllerMovementReference.MoveCharacter(settings.walkingSpeed);

        if (inputHandler.IsJumping && controllerMovementReference.IsGrounded()) {
            controllerMovementReference.SetState(new JumpingState(controllerMovementReference, inputHandler, settings, this));
        }

        if (inputHandler.IsSprinting) {
            controllerMovementReference.SetState(new RunningState(controllerMovementReference, inputHandler, settings));
        }

        if (inputHandler.MovementData == Vector2.zero) {
            controllerMovementReference.SetState(new IdleState(controllerMovementReference, inputHandler, settings));
        }
    }

    public void ExitState() { }
}
