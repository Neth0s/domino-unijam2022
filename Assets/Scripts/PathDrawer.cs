using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private CinemachineDollyCart dollyCart;
    [SerializeField] private int points = 100;

    public void Start() => StartCoroutine(DrawCoroutine());

    private IEnumerator DrawCoroutine()
    {
        dollyCart.m_Position = 0;
        lineRenderer.enabled = false;

        lineRenderer.positionCount = points + 1;
        float segment = 1f / points;
        float pos = 0;
        
        for (int i = 0; i <= points; i++)
        {
            if (i == points) pos = 1;

            dollyCart.m_Position = pos;
            yield return new WaitForEndOfFrame();
            lineRenderer.SetPosition(i, dollyCart.transform.position);
            pos += segment;
        }

        Debug.Log("LineRenderer updated!");
        lineRenderer.enabled = true;
    }
}
