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


    private float currentTimeBetweenDominos = Mathf.Infinity;

    Controls controls;

    private void OnEnable()
    {
        if (dominoPrefabs.Count != dominosCounts.Count)
        {
            Debug.Log("Attention la liste des nombres de dominos n'a pas la même taille que le nombre de prefabs de dominos");
        }
        controls = new Controls();
        controls.Player.Enable();
        controls.Player.PlaceColor1.performed += ctx => Spawn(0);
        controls.Player.PlaceColor2.performed += ctx => Spawn(1);
        controls.Player.PlaceColor3.performed += ctx => Spawn(2);
        controls.Player.PlaceColor4.performed += ctx => Spawn(3);
    }
    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.PlaceColor1.performed -= ctx => Spawn(0);
        controls.Player.PlaceColor2.performed -= ctx => Spawn(1);
        controls.Player.PlaceColor3.performed -= ctx => Spawn(2);
        controls.Player.PlaceColor4.performed -= ctx => Spawn(3);
    }
    private void Update()
    {
        currentTimeBetweenDominos += Time.deltaTime;
    }
    private void Spawn(int prefabIndex)
    {
        if (dominosCounts.Count <= prefabIndex || dominosCounts[prefabIndex] <= 0)
            return;
        if (currentTimeBetweenDominos > minTimeBetweenDominos)
        {
            Instantiate(dominoPrefabs[prefabIndex], spawnPoint.position, spawnPoint.rotation);
            currentTimeBetweenDominos = 0;
            dominosCounts[prefabIndex] -= 1;
        }
    }
}
