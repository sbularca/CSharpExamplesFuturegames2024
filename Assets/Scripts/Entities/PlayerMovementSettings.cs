using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSettings", menuName = "Examples/Character Settings")]
public class PlayerMovementSettings : ScriptableObject {
    [Header("Movement")]
    public float walkingSpeed = 3f;
    public float runSpeed = 10f;
    public float rotationSpeed = 20f;
    public float jumpVelocity = 2f;
    public float gravity = -9.8f;
}
