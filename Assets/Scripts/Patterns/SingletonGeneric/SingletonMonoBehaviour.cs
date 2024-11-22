using System;
using UnityEngine;

public class SingletonMonoBehaviour : MonoBehaviour {
    private static SingletonMonoBehaviour instance;
    public static SingletonMonoBehaviour Instance {
        get {
            instance = instance ?? new GameObject("SingletonMonobehavior").AddComponent<SingletonMonoBehaviour>();
            DontDestroyOnLoad(instance);
            return instance;
        }
    }

    public void DoSomething() {}
}


public class Player : MonoBehaviour {
    private void Awake() {
        SingletonMonoBehaviour.Instance.DoSomething();
    }
}
