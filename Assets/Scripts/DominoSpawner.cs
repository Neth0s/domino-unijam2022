using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class DominoSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject dominosParent;
    [SerializeField] private PathDrawer pathDrawer;

    [Header("Dominos")]
    [SerializeField] private List<GameObject> dominoPrefabs;
    [SerializeField] private List<GameObject> longDominoPrefabs;
    [SerializeField] private List<int> dominosCounts;
    [SerializeField] private List<TextMeshProUGUI> dominosCountsTexts;
    [SerializeField] private List<Color> dominoColors;
    [SerializeField] private Color disabledColor;
    [SerializeField] private BoxCollider shadowCollider;

    [Header("Parameters")]
    [SerializeField] float speed = 0.3f;
    [SerializeField] private float minTimeBetweenDominos = 0.1f;
    [SerializeField] private Vector3 spawnOffset = new (0, 0.3f, 0);
    [SerializeField] private Material shadowRedMaterial;


    private int dominoIndex = 0;
    private float lastPosition = -1;
    private float currentTimeBetweenDominos = Mathf.Infinity;
    private int dominosRemaining = 0;
    private bool dollyCartStarted = false;

    Controls controls;
    private List<float> distances;
    private List<int> colors;

    CinemachineDollyCart dollyCart;


    private MeshRenderer shadowMeshRenderer;
    private Material shadowMaterial;

    private void Awake()
    {
        for (int i = 0; i < dominosCounts.Count; i++) dominosRemaining += dominosCounts[i];
        dollyCart = GetComponent<CinemachineDollyCart>();
        shadowMeshRenderer = shadowCollider.GetComponent<MeshRenderer>();
        shadowMaterial = shadowMeshRenderer.material;
    }

    private void OnEnable()
    {
        distances = new List<float>();
        colors = new List<int>();

        if (dominoPrefabs.Count != dominosCounts.Count)
        {
            Debug.LogWarning("La liste des nombres de dominos n'a pas la même taille que le nombre de prefabs de dominos");
        }
        for (int i = 0; i < Mathf.Min(dominosCountsTexts.Count, dominosCounts.Count); i++)
        {
            dominosCountsTexts[i].text = dominosCounts[i].ToString();
            if (dominosCounts[i] == 0) dominosCountsTexts[i].color = disabledColor;
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
        if (dollyCartStarted && (lastPosition == dollyCart.m_Position)) PlacingPhaseFinished();
        lastPosition = dollyCart.m_Position;
        shadowMeshRenderer.material = SpaceAvailable() ? shadowMaterial : shadowRedMaterial;
    }

    private void Spawn(int prefabIndex)
    {
        if (!SpaceAvailable())
            return;
        if (!dollyCartStarted)
        {
            dollyCartStarted = true;
            dollyCart.m_Speed = speed;
        }
        if (dominosCounts.Count <= prefabIndex || dominosCounts[prefabIndex] <= 0) return;

        if (currentTimeBetweenDominos > minTimeBetweenDominos)
        {
            bool longDomino = false;
            if (controls.Player.LongDomino.ReadValue<float>() > 0 && dominosCounts[prefabIndex] >= 2)
                longDomino = true;
            var dominoInstance = Instantiate(longDomino ? longDominoPrefabs[prefabIndex] : dominoPrefabs[prefabIndex], spawnPoint.position + spawnOffset, spawnPoint.rotation, dominosParent.transform);
            
            currentTimeBetweenDominos = 0;
            dominosCounts[prefabIndex] -= longDomino ? 2 : 1;
            dominosRemaining -= longDomino ? 2 : 1;
            distances.Add(dollyCart.m_Position);
            colors.Add(prefabIndex);
            
            if (dominosCountsTexts.Count > prefabIndex)
                dominosCountsTexts[prefabIndex].text = dominosCounts[prefabIndex].ToString();

            dominoInstance.GetComponent<Domino>().Init(dominoIndex, dollyCart.m_Position, dollyCart.m_Position / dollyCart.m_Path.PathLength, pathDrawer);
            dominoIndex++;
        }
        
        if (dominosRemaining <= 0) PlacingPhaseFinished();
    }
    private bool SpaceAvailable()
    {
        Collider[] hitColliders = Physics.OverlapBox(shadowCollider.bounds.center, shadowCollider.bounds.extents, transform.rotation);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject != shadowCollider.gameObject)
            {
                return false;
            }
        }
        return true;
    }
  

    private void PlacingPhaseFinished()
    {
        GameManager.Instance.SwitchToShowdownPhase();
        Destroy(gameObject);
    }
}
