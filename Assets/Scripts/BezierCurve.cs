using UnityEngine;

[System.Serializable]
public class BezierCurve
{
    private readonly Vector3[] points;

    public Vector3[] Points { get { return points; } }
    public Vector3 StartPosition { get { return points[0]; } }
    public Vector3 EndPosition { get { return points[3]; } }

    public BezierCurve(Vector3[] points)
    {
        this.points = points;
    }

    public BezierCurve()
    {
        points = new Vector3[4];
    }

    public Vector3 GetSegment(float time)
    {
        time = Mathf.Clamp01(time);
        float inverse = 1 - time;

        return (inverse * inverse * inverse * points[0])
            + (3 * inverse * inverse * time * points[1])
            + (3 * inverse * time * time * points[2])
            + (time * time * time * points[3]);
    }

    public Vector3[] GetSegments(int Subdivisions)
    {
        Vector3[] segments = new Vector3[Subdivisions];

        float time;
        for (int i = 0; i < Subdivisions; i++)
        {
            time = (float)i / Subdivisions;
            segments[i] = GetSegment(time);
        }

        return segments;
    }
}