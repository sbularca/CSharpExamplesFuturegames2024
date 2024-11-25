using UnityEngine;

public static class Init {
    // this automatically executed when the game starts BEFORE all the other systems
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Initialize() {
        // I need the settings from disk
        PlayerPrefabSettings settings = Resources.Load<PlayerPrefabSettings>("PlayerPrefabSettings");

        // I get the settings and instantiate the player
        ControllerMovementReference playerMoveRef = Object.Instantiate(settings.controllerMovementReference);

        // I initialize the player movement system
        PlayerMovement playerMovement = new (playerMoveRef.characterSettings, playerMoveRef.characterController);
        playerMovement.Initialize();
    }
}
