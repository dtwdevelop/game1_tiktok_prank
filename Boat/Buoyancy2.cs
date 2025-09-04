using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Buoyancy2 : MonoBehaviour
{
    public Rigidbody rb;
    public float buoyancyStrength = 5f;
    public WaterSurface water;

    void FixedUpdate()
    {
        if (!water) return;

        WaterSearchParameters searchParams = new WaterSearchParameters { startPositionWS = transform.position };
        WaterSearchResult searchResult;
        water.ProjectPointOnWaterSurface(searchParams, out searchResult);

        float displacement = Mathf.Clamp01(searchResult.projectedPositionWS.y - transform.position.y);
        if (displacement > 0)
        {
            rb.AddForce(Vector3.up * displacement * buoyancyStrength * 0.5f, ForceMode.Acceleration);
        }
    }
}