using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ControllerMovementReference : MonoBehaviour {
    public CharacterSettings characterSettings;
    public CharacterController characterController;
}
