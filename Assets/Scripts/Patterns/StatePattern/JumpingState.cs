using UnityEngine;

public class JumpingState : ICharacterState {
    private readonly ControllerMovement controllerMovement;
    private readonly InputHandler inputHandler;
    private readonly CharacterSettings settings;
    private readonly ICharacterState previousState;
    private float speed;
    private bool isReset;

    public JumpingState(ControllerMovement controllerMovement, InputHandler inputHandler, CharacterSettings settings, ICharacterState previousState) {
        this.controllerMovement = controllerMovement;
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
            controllerMovement.velocity.y = settings.jumpVelocity;
            isReset = true;
        }

        controllerMovement.MoveCharacter(speed);

        if (controllerMovement.IsGrounded() && controllerMovement.velocity.y <= 0f) {
            controllerMovement.SetState(new IdleState(controllerMovement, inputHandler, settings));
        }
    }

    public void ExitState() { }
}
