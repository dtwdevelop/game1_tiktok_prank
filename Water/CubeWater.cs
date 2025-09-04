using UnityEngine;

public class CubeWater : MonoBehaviour
{
    [Tooltip("Массив Transform объектов, представляющих точки погружения.")]
    public Transform[] floatPoints;
    [Tooltip("Как высоко над водой будет находиться каждая точка погружения.")]
    public float floatHeight = 1f;
    [Tooltip("Насколько сильно будет гаситься колебание.")]
    public float bounceDamp = 0.05f;
    [Tooltip("Уровень воды.")]
    public float waterLevel = 0f;

    private Rigidbody rb;
    private float submergedCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component не найден на этом объекте.");
            enabled = false;
        }

        if (floatPoints.Length == 0)
        {
            Debug.LogError("Не назначены точки погружения!");
            enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (rb == null || floatPoints.Length == 0) return;

        submergedCount = 0;
        for (int i = 0; i < floatPoints.Length; i++)
        {
            Vector3 worldPoint = floatPoints[i].position;
            float depth = worldPoint.y - waterLevel;

            if (depth < 0) // Точка погружена
            {
                submergedCount++;
                float displacementMultiplier = Mathf.Clamp01(-depth / floatHeight);
                Vector3 buoyancyForce = -Physics.gravity * rb.mass * displacementMultiplier;
                rb.AddForceAtPosition(buoyancyForce, worldPoint);
                float dampVelocity = rb.GetPointVelocity(worldPoint).y * -bounceDamp;
                rb.AddForceAtPosition(Vector3.up * dampVelocity * rb.mass, worldPoint);
            }
        }

        // Дополнительная логика для сопротивления вращению (опционально)
        if (submergedCount > 0)
        {
            // Можно добавить силы, противодействующие наклону, основываясь на том, какие точки погружены
        }
    }

    // Для визуализации точек погружения в редакторе
    void OnDrawGizmosSelected()
    {
        if (floatPoints != null)
        {
            Gizmos.color = Color.blue;
            foreach (Transform point in floatPoints)
            {
                if (point != null)
                {
                    Gizmos.DrawSphere(point.position, 0.1f);
                }
            }
        }
    }
}