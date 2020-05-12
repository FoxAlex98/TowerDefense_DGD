using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : ShootingTurret {
    [SerializeField] int unIntero;

    private void Start()
    {
        SendInformation(this);
    }

    public int GetInfo()
    {
        return unIntero;
    }
}
