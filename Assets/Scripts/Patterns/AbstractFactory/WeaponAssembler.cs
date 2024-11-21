using System;
using UnityEngine;

public class WeaponAssembler : MonoBehaviour {

    private void Start() {
        var smgFactory = new SMGFactory();
        var smg = smgFactory.CreateWeapon();

        var sniperFactory = new SniperFactory();
        var sniper = sniperFactory.CreateWeapon();

    }
}
