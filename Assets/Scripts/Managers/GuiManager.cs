using UnityEngine;
using UnityEditor;

public class GuiManager : MonoBehaviour
{
    public static GuiManager instance;

    void Awake()
    {
        instance = this;
    }

    public void ShowInformation<T>(T turret)
    {
        string type = turret.GetType().ToString();

        switch (type)
        {
            case "MachineGun":
                MachineGun gun = turret as MachineGun;
                Debug.Log(gun.GetInfo());
                break;

            case "RocketLauncher":
                RocketLauncher rock = turret as RocketLauncher;
                Debug.Log(rock.name);
                break;
                
        }
    }
}