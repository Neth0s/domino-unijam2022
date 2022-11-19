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
    [SerializeField] private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    [System.Serializable]
    public struct ColorCoefficient
    {
        public Color color;
        public float coefficient;

        public ColorCoefficient(Color color, float coefficient)
        {
            this.color = color;
            this.coefficient = coefficient;
        }
    }

    [SerializeField] List<ColorCoefficient> colorCoefficients = new List<ColorCoefficient>();
    public List<ColorCoefficient> ColorCoefficients { get => colorCoefficients; private set => colorCoefficients = value; }

    public Color Evaluate(float coefficient)
    {
        coefficient = Mathf.Clamp01(coefficient);

        Color result = colorCoefficients[0].color;
        for (int i = 0; i < colorCoefficients.Count; i++)
        {
            result = colorCoefficients[i].color;
            coefficient -= colorCoefficients[i].coefficient;
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

        for(int i = 0; i < colorCoefficients.Count; i++)
        {
            int currentColorPointCount = Mathf.CeilToInt(colorCoefficients[i].coefficient * points);
            LineRenderer currentLine = Instantiate(lineRendererPrefab, Vector3.zero, Quaternion.Euler(90, 0, 0), transform);
            currentLine.positionCount = currentColorPointCount + 1;
            segment = colorCoefficients[i].coefficient / currentColorPointCount;
            currentLine.SetColors(colorCoefficients[i].color, colorCoefficients[i].color);
            yield return new WaitForEndOfFrame();
            currentLine.SetPosition(0, dollyCart.transform.position + offset);
            for(int j = 1; j < currentColorPointCount + 1; j++)
            {
                pos += segment;
                dollyCart.m_Position = pos;
                yield return new WaitForEndOfFrame();
                currentLine.SetPosition(j, dollyCart.transform.position + offset);
            }
            currentLine.enabled = false;
            lineRenderers.Add(currentLine);
        }

        foreach (var lineRendererToEnable in lineRenderers)
        {
            lineRendererToEnable.enabled = true;
        }

        /*lineRenderer.enabled = false;

        lineRenderer.positionCount = points + 1;
        float segment = 1f / points;
        float pos = 0;

        for (int i = 0; i <= points; i++)
        {
            if (i == points) pos = 1;

            dollyCart.m_Position = pos;
            yield return new WaitForEndOfFrame();
            lineRenderer.SetPosition(i, dollyCart.transform.position + offset);
            pos += segment;
        }

        Debug.Log("LineRenderer updated!");
        lineRenderer.enabled = true;*/
    }
}
