using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoSpawner : MonoBehaviour
{
    [SerializeField] float distanceBetweenDominos = 1;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> dominoPrefabs;
    [SerializeField] private List<int> dominosCounts;
    [SerializeField] private float minTimeBetweenDominos = 0.1f;

    private int prefabIndex = 0;
    private int dominoTypesRemaining;

    private float currentTimeBetweenDominos = Mathf.Infinity;

    Controls controls;

    private void OnEnable()
    {
        dominoTypesRemaining = dominoPrefabs.Count;
        controls.Player.Enable();
        controls.Player.Place.performed += ctx => Spawn();
        controls.Player.Switch.performed += ctx => Switch();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.Place.performed -= ctx => Spawn();
        controls.Player.Switch.performed -= ctx => Switch();
    }
    private void Update()
    {
        currentTimeBetweenDominos += Time.deltaTime;
    }
    private void Spawn()
    {
        if (currentTimeBetweenDominos > minTimeBetweenDominos)
        {
            Instantiate(dominoPrefabs[prefabIndex], spawnPoint.position, spawnPoint.rotation);
            currentTimeBetweenDominos = 0;
            dominosCounts[prefabIndex] -= 1;
            if (dominosCounts[prefabIndex] <= 0)
            {
                Switch();
                dominoTypesRemaining -= 1;
            }
        }
    }

    private void Switch()
    {
        if (dominoTypesRemaining <= 0)
        {
            return;
        }
        do
        {
            prefabIndex = (prefabIndex + 1) % dominoPrefabs.Count;
        } while (dominosCounts[prefabIndex] <= 0);
    }
}
