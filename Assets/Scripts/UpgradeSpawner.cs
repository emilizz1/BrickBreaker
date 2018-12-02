using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] upgrades;
    [Range(0, 100)] [SerializeField] float ChancePercentage;
	
	public void SpawnRequest(Vector2 position)
    {
        if(Random.Range(0f,100f) < ChancePercentage)
        {
            SpawnUpgrade(position);
        }
    }

    void SpawnUpgrade (Vector2 position)
    {
        Instantiate(upgrades[Random.Range(0, upgrades.Length)], position, Quaternion.identity, transform);
    }
}
