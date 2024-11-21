using System;
using UnityEngine;

public class ObserverExamples : MonoBehaviour {
    //public static Action<int> OnDamageAction;

    private int playerHealth = 100;
    private void OnEnable() {
        Signals.Get<DamageSignal>().AddListener(OnDamage);
        //OnDamageAction += OnDamage;
    }
    private void Start() {
        Signals.Get<UpdateUI>().Dispatch(playerHealth);
    }
    private void OnDamage(int value) {
        playerHealth -= value;
        Signals.Get<UpdateUI>().Dispatch(playerHealth);
        //GUIHandler.OnUpdateUI.Invoke(playerHealth);
    }

    private void OnDisable() {
        Signals.Get<DamageSignal>().RemoveListener(OnDamage);
        //OnDamageAction -= OnDamage;
    }
}

public class DamageSignal : ASignal<int> { }
public class UpdateUI : ASignal<int> { }
