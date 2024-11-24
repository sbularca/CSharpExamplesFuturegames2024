using UnityEngine;

public class IdleState : ICharacterState {
    private readonly InputHandler inputHandler;
    private readonly PlayerMovementSettings settings;
    private readonly PlayerMovement playerMovement;
    public IdleState(PlayerMovement playerMovement, InputHandler inputHandler, PlayerMovementSettings settings) {
        this.playerMovement = playerMovement;
        this.inputHandler = inputHandler;
        this.settings = settings;
    }

    public void EnterState() {
        // update animations here if any
    }

    public void UpdateState() {
        playerMovement.velocity.x = 0f;
        playerMovement.velocity.z = 0f;

        if (inputHandler.IsJumping && playerMovement.IsGrounded()) {
            playerMovement.SetState(new JumpingState(playerMovement, inputHandler, settings, this));
        }

        if (inputHandler.MovementData != Vector2.zero) {
            playerMovement.SetState(new WalkingState(playerMovement, inputHandler, settings));
        }
    }
    public void ExitState() { }
}
