using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Spawn(Transform spawnPoint)
    {
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Debug.Log("ho colpito un nemico");
        }
    }
}
