using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class DominoSpawner : MonoBehaviour
{
    [SerializeField] float distanceBetweenDominos = 1;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> dominoPrefabs;
    [SerializeField] private List<int> dominosCounts;
    [SerializeField] private float minTimeBetweenDominos = 0.1f;
    [SerializeField] private List<TextMeshProUGUI> dominosCountsTexts;

    [SerializeField] Vector3 spawnOffset = new Vector3(0, 0.3f, 0);

    [SerializeField] int dominoIndex = 0;


    private float currentTimeBetweenDominos = Mathf.Infinity;

    Controls controls;

    CinemachineDollyCart dollyCart;

    [SerializeField] GameObject dominosParent;

    private void Awake()
    {
        dollyCart = GetComponent<CinemachineDollyCart>();
    }

    private void OnEnable()
    {
        if (dominoPrefabs.Count != dominosCounts.Count)
        {
            Debug.Log("Attention la liste des nombres de dominos n'a pas la même taille que le nombre de prefabs de dominos");
        }
        for (int i = 0; i < Mathf.Min(dominosCountsTexts.Count, dominosCounts.Count); i++)
        {
            dominosCountsTexts[i].text = dominosCounts[i].ToString();
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
            var dominoInstance = Instantiate(dominoPrefabs[prefabIndex], spawnPoint.position + spawnOffset, spawnPoint.rotation, dominosParent.transform);
            currentTimeBetweenDominos = 0;
            dominosCounts[prefabIndex] -= 1;
            if (dominosCountsTexts.Count > prefabIndex)
                dominosCountsTexts[prefabIndex].text = dominosCounts[prefabIndex].ToString();

            dominoInstance.GetComponent<Domino>().Init(dominoIndex, dollyCart.m_Position);
            dominoIndex++;
        }
    }
}
