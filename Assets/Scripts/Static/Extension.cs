﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension {

	public static void Spawn(this Transform trans, Transform spawnPoint) //ho reso questo metodo un metodo esteso
    {
        trans.position = spawnPoint.position;
        trans.rotation = spawnPoint.rotation;
        trans.gameObject.SetActive(true);
    }
}
