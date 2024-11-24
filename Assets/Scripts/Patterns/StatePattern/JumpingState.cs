using UnityEngine;

public class JumpingState : ICharacterState {
    private readonly PlayerMovement playerMovement;
    private readonly InputHandler inputHandler;
    private readonly PlayerMovementSettings settings;
    private readonly ICharacterState previousState;
    private float speed;
    private bool isReset;

    public JumpingState(PlayerMovement playerMovement, InputHandler inputHandler, PlayerMovementSettings settings, ICharacterState previousState) {
        this.playerMovement = playerMovement;
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
            playerMovement.velocity.y = settings.jumpVelocity;
            isReset = true;
        }

        playerMovement.MoveCharacter(speed);

        if (playerMovement.IsGrounded() && playerMovement.velocity.y <= 0f) {
            playerMovement.SetState(new IdleState(playerMovement, inputHandler, settings));
        }
    }

    public void ExitState() { }
}
