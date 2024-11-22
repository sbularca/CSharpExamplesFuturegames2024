using System;
using UnityEngine;

[Flags]
public enum Choices {
    None,
    First,
    Second,
    Third,
}

public class SingletonMonoBehaviour : MonoBehaviour {
    public Choices choice;
    private static SingletonMonoBehaviour instance;

    public static SingletonMonoBehaviour Instance {
        get {
            instance = instance ?? new GameObject("SingletonMonobehavior").AddComponent<SingletonMonoBehaviour>();
            DontDestroyOnLoad(instance);
            return instance;
        }
    }

    /// <summary>
    ///  same as the property getter
    /// </summary>
    /// <returns></returns>
    public static SingletonMonoBehaviour GetInstance() {
        instance = instance ?? new GameObject("SingletonMonobehavior").AddComponent<SingletonMonoBehaviour>();
        DontDestroyOnLoad(instance);
        return instance;
    }

    /// <summary>
    /// same as the property setter
    /// </summary>
    public static void SetInstance() {
        instance = Instance;
    }


    public void DoSomething() { }
}


public class Player : MonoBehaviour {
    private void Awake() {
        SingletonMonoBehaviour.GetInstance().DoSomething();
    }
}
