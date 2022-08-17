using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;


    private void Awake()
    {
        UpdateMaterialSector();
    }

    private void UpdateMaterialSector()
    {
        Renderer SectorRenderer = GetComponent<Renderer>();
        SectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5) return;

        if (IsGood)
            player.Bounce();
        else
            player.Die();
    }

    private void OnValidate()
    {
        UpdateMaterialSector();
    }
}
