using UnityEngine;

public class IdleState : ICharacterState {
    private readonly InputHandler inputHandler;
    private readonly CharacterSettings settings;
    private readonly ControllerMovement controllerMovement;
    public IdleState(ControllerMovement controllerMovement, InputHandler inputHandler, CharacterSettings settings) {
        this.controllerMovement = controllerMovement;
        this.inputHandler = inputHandler;
        this.settings = settings;
    }

    public void EnterState() {
        // update animations here if any
    }

    public void UpdateState() {
        controllerMovement.velocity.x = 0f;
        controllerMovement.velocity.z = 0f;

        if (inputHandler.IsJumping && controllerMovement.IsGrounded()) {
            controllerMovement.SetState(new JumpingState(controllerMovement, inputHandler, settings, this));
        }

        if (inputHandler.MovementData != Vector2.zero) {
            controllerMovement.SetState(new WalkingState(controllerMovement, inputHandler, settings));
        }
    }
    public void ExitState() { }
}
