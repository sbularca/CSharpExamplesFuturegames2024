using UnityEngine;

public class CommandHandler {
    private bool shouldJump;
    private bool shouldUndo;

    public CommandHandler() {
        var controller = new CharacterController();
        Move move = new (controller);
        Jump jump = new (controller);

        ICommand command = null;

        if(shouldJump) {
            jump.Execute();
            command = jump;
        }
        else {
            move.Execute();
            command = move;
        }

        if(shouldUndo) {
            command.Undo();
        }
    }
}
