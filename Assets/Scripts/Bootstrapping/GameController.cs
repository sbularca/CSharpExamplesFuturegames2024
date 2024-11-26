using System;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private PlayerData playerData;

    private InputHandler inputHandler;
    private PlayerMovement playerMovement;
    private bool initialized;

    public void Initialize() {
        inputHandler = new InputHandler();
        playerMovement = new PlayerMovement(playerData.playerReferencePrefab, inputHandler);
        playerMovement.Initialize();
        initialized = true;
    }

    public void Update() {
        if(!initialized) {
            return;
        }
        playerMovement.Tick();
    }

}
