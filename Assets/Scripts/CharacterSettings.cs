using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CharacterSettings", menuName = "Character Settings")]
public class CharacterSettings : ScriptableObject {
    [Header("Movement")]
    public float walkingSpeed = 3f;
    public float runSpeed = 10f;
    public float rotationSpeed = 20f;
    public float jumpVelocity = 2f;
    public float gravity = -9.8f;
}
