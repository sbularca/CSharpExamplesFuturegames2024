using UnityEngine;

public class JumpingState : ICharacterState {
    private readonly PlayerMovement controllerMovementReference;
    private readonly InputHandler inputHandler;
    private readonly CharacterSettings settings;
    private readonly ICharacterState previousState;
    private float speed;
    private bool isReset;

    public JumpingState(PlayerMovement controllerMovementReference, InputHandler inputHandler, CharacterSettings settings, ICharacterState previousState) {
        this.controllerMovementReference = controllerMovementReference;
        this.inputHandler = inputHandler;
        this.settings = settings;
        this.previousState = previousState;
    }

    public void EnterState() {
        // update animations here if any

        speed = previousState switch {
            RunningState => settings.runSpeed,
            WalkingState => settings.runSpeed,
            _ => 0f
        };
    }

    public void UpdateState() {
        if(!isReset) {
            controllerMovementReference.velocity.y = settings.jumpVelocity;
            isReset = true;
        }

        controllerMovementReference.MoveCharacter(speed);

        if (controllerMovementReference.IsGrounded() && controllerMovementReference.velocity.y <= 0f) {
            controllerMovementReference.SetState(new IdleState(controllerMovementReference, inputHandler, settings));
        }
    }

    public void ExitState() { }
}
