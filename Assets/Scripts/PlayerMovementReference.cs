using System.Collections.Generic;
using System.Linq;
using ToolBox.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementReference : MonoBehaviour {
    public PlayerMovementSettings playerMovementSettings;
    public EntitySettings playerSettings;
}
