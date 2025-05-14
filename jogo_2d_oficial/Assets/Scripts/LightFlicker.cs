using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class TorchFlicker : MonoBehaviour
{
    public Light2D light2D;
    public float baseIntensity = 1f;
    public float intensityVariation = 0.5f;
    public float baseRadius = 3f;
    public float radiusVariation = 1f;
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;

    private float speedA;
    private float speedB;
    private Vector2 offsetA;
    private Vector2 offsetB;

    void Awake()
    {
        if (light2D == null) light2D = GetComponent<Light2D>();
        speedA = Random.Range(minSpeed, maxSpeed);
        speedB = Random.Range(minSpeed * 1.5f, maxSpeed * 1.5f);
        offsetA = Random.insideUnitCircle * 100f;
        offsetB = Random.insideUnitCircle * 100f;
    }

    void Update()
    {
        float t = Time.time;
        float noiseA = Mathf.PerlinNoise(offsetA.x + t * speedA, offsetA.y);
        float noiseB = Mathf.PerlinNoise(offsetB.x + t * speedB, offsetB.y);
        float flicker = noiseA * 0.7f + noiseB * 0.3f;
        light2D.intensity = baseIntensity + (flicker - 0.5f) * intensityVariation;
        light2D.pointLightOuterRadius = baseRadius + (flicker - 0.5f) * radiusVariation;
    }
}