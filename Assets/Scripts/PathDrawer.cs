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

    [SerializeField] private Vector3 offset;

    [SerializeField] private LineRenderer lineRendererPrefab;
    private List<LineRenderer> lineRenderers = new();

    [System.Serializable]
    public struct ColorCoef
    {
        public Color color;
        public float coefficient;

        public ColorCoef(Color color, float coefficient)
        {
            this.color = color;
            this.coefficient = coefficient;
        }
    }

    [SerializeField] List<ColorCoef> colorCoefs = new();
    public List<ColorCoef> ColorCoefficients { get => colorCoefs; private set => colorCoefs = value; }

    public Color Evaluate(float coefficient)
    {
        coefficient = Mathf.Clamp01(coefficient);

        Color result = colorCoefs[0].color;
        for (int i = 0; i < colorCoefs.Count; i++)
        {
            result = colorCoefs[i].color;
            coefficient -= colorCoefs[i].coefficient;
            if (coefficient < 0) break;

        }

        return result;
    }

    public void Start() => StartCoroutine(DrawCoroutine());

    private IEnumerator DrawCoroutine()
    {
        dollyCart.m_Position = 0;
        float pos = 0;
        float segment;

        for(int i = 0; i < colorCoefs.Count; i++)
        {
            int colorPointCount = Mathf.CeilToInt(colorCoefs[i].coefficient * points);
            LineRenderer currentLine = Instantiate(lineRendererPrefab, Vector3.zero, Quaternion.Euler(90, 0, 0), transform);
            currentLine.enabled = false;
            
            currentLine.positionCount = colorPointCount + 1;
            segment = colorCoefs[i].coefficient / colorPointCount;
            currentLine.startColor = colorCoefs[i].color;
            currentLine.endColor = colorCoefs[i].color;
            
            yield return new WaitForEndOfFrame();

            currentLine.SetPosition(0, dollyCart.transform.position + offset);
            
            for(int j = 1; j < colorPointCount + 1; j++)
            {
                pos += segment;
                dollyCart.m_Position = pos;

                yield return new WaitForEndOfFrame();
                currentLine.SetPosition(j, dollyCart.transform.position + offset);
            }
            lineRenderers.Add(currentLine);
        }

        foreach (var line in lineRenderers)
        {
            line.enabled = true;
        }

        Debug.Log("Line renderer updated !");
    }
}
