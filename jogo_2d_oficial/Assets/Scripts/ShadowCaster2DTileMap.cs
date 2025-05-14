using System.Linq;
using System.Reflection;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(CompositeCollider2D))]
public class ShadowCaster2DTileMap : MonoBehaviour
{
    [Space]
    [SerializeField]
    private bool selfShadows = true;

    private CompositeCollider2D tilemapCollider;

    static readonly FieldInfo meshField = typeof(ShadowCaster2D)
        .GetField("m_Mesh", BindingFlags.NonPublic | BindingFlags.Instance);
    static readonly FieldInfo shapePathField = typeof(ShadowCaster2D)
        .GetField("m_ShapePath", BindingFlags.NonPublic | BindingFlags.Instance);
    static readonly FieldInfo shapePathHashField = typeof(ShadowCaster2D)
        .GetField("m_ShapePathHash", BindingFlags.NonPublic | BindingFlags.Instance);
    static readonly MethodInfo generateShadowMeshMethod = typeof(ShadowCaster2D)
        .Assembly
        .GetType("UnityEngine.Rendering.Universal.ShadowUtility")
        .GetMethod("GenerateShadowMesh", BindingFlags.Public | BindingFlags.Static);

    private IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
        Generate();
    }

    public void Generate()
    {
        tilemapCollider = GetComponent<CompositeCollider2D>();
        Debug.Log("[Shadow] pathCount = " + tilemapCollider.pathCount);
        DestroyAllChildren();

        for (int i = 0; i < tilemapCollider.pathCount; i++)
        {
            Vector2[] pathVertices = new Vector2[tilemapCollider.GetPathPointCount(i)];
            tilemapCollider.GetPath(i, pathVertices);

            GameObject shadowCaster = new GameObject($"shadow_caster_{i}");
            shadowCaster.transform.parent = transform;
            ShadowCaster2D caster = shadowCaster.AddComponent<ShadowCaster2D>();
            caster.selfShadows = selfShadows;

            Vector3[] shapePath = pathVertices.Select(v => (Vector3)v).ToArray();
            shapePathField.SetValue(caster, shapePath);
            shapePathHashField.SetValue(caster, Random.Range(int.MinValue, int.MaxValue));
            meshField.SetValue(caster, new Mesh());
            generateShadowMeshMethod.Invoke(
                null,
                new object[] { meshField.GetValue(caster), shapePathField.GetValue(caster) }
            );
        }
    }

    public void DestroyAllChildren()
    {
        foreach (var child in transform.Cast<Transform>().ToList())
            DestroyImmediate(child.gameObject);
    }
}