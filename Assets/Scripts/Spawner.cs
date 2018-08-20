using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray) {
            if (isTimeToSpawn(thisAttacker)) {
                Spawn(thisAttacker);
            }
        }
	}

    private bool isTimeToSpawn(GameObject thisAttacker) {
        Attacker attacker = thisAttacker.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay) {
            Debug.LogWarning("Spawn capped by frame rate");
        }

        float treshold = spawnsPerSecond * Time.deltaTime / 5;

        return UnityEngine.Random.value < treshold;
    }

    private void Spawn(GameObject thisAttacker) {
        GameObject myAttacker = Instantiate(thisAttacker) as GameObject;
        myAttacker.transform.parent = this.transform;
        myAttacker.transform.position = this.transform.position;
    }
}
