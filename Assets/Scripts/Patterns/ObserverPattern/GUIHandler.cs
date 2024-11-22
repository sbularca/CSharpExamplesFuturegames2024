using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIHandler : MonoBehaviour {
    public Button button;
    public TextMeshProUGUI text;

    public static Action<int> OnUpdateUI;

    private void OnEnable() {
        Signals.Get<UpdateUI>().AddListener(UpdateHealth);
        OnUpdateUI += UpdateHealth;
    }
    private void Start() {
        button.onClick.AddListener(() => {
            Signals.Get<DamageSignal>().Dispatch(10);
        });
        button.onClick.AddListener(() => { ObserverExamples.OnDamageAction?.Invoke(10); });
    }

private void UpdateHealth(int value) {
        text.text = value.ToString();
    }

    private void OnDisable() {
        Signals.Get<UpdateUI>().RemoveListener(UpdateHealth);
        button.onClick.RemoveAllListeners();
        OnUpdateUI -= UpdateHealth;
    }
}
