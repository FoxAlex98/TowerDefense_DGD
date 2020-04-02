using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Spawn(Transform spawnPoint)
    {
        transform.Spawn(spawnPoint);//sto chiamando lo spawn che sta nella classe estesa
    }
    
}
