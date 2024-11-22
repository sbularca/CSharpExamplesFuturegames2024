using System;
using UnityEngine;

public class Generics : MonoBehaviour {
    private static void LogValue<T>(T value) {
        Debug.Log($"Value: {value}, Type: {typeof(T)}");
    }

    private void Start() {
        LogValue("Hello World!");

        var go = new GameObject();
        go.AddComponent<Rigidbody2D>();
    }
}
