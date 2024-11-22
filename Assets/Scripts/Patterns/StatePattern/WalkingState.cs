using UnityEngine;

public class WalkingState : ICharacterState {
    private readonly ControllerMovement controllerMovement;
    private readonly InputHandler inputHandler;
    private readonly CharacterSettings settings;

    public WalkingState(ControllerMovement controllerMovement, InputHandler inputHandler, CharacterSettings settings) {
        this.controllerMovement = controllerMovement;
        this.inputHandler = inputHandler;
        this.settings = settings;

    }

    public void EnterState() {
        // update animations here if any
    }

    public void UpdateState() {
        controllerMovement.MoveCharacter(settings.walkingSpeed);

        if (inputHandler.IsJumping && controllerMovement.IsGrounded()) {
            controllerMovement.SetState(new JumpingState(controllerMovement, inputHandler, settings, this));
        }

        if (inputHandler.IsSprinting) {
            controllerMovement.SetState(new RunningState(controllerMovement, inputHandler, settings));
        }

        if (inputHandler.MovementData == Vector2.zero) {
            controllerMovement.SetState(new IdleState(controllerMovement, inputHandler, settings));
        }
    }

    public void ExitState() { }
}
