using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MeshRendererMaterialSetter : MonoBehaviour
{
    public List<MeshMaterialPreset> presets;

    private MeshRenderer meshRenderer;

    private Material baseMaterial;
    private Dictionary<string, Material> lookupTable;

    [Serializable]
    public struct MeshMaterialPreset
    {
        public string name;
        public Material material;
    }

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer == null)
        {
            Debug.LogError("Missing MeshRenderer. MeshMaterialSetter will not function.");
        }
        else
        {
            baseMaterial = meshRenderer.material;
        }

        lookupTable = new Dictionary<string, Material>();
        foreach (MeshMaterialPreset preset in presets)
        {
            if (lookupTable.ContainsKey(preset.name))
            {
                Debug.LogWarning("Discovered duplicate presets under name : " + preset.name);
            }
            lookupTable[preset.name] = preset.material;
        }
    }

    public void SetMaterialPreset(string presetName)
    {
        Material mat;
        if(!lookupTable.TryGetValue(presetName, out mat))
        {
            Debug.LogError("Unable to find material preset by name : " + presetName);
            return;
        }
        meshRenderer.material = mat;
    }

    public void SetMaterial(Material material)
    {
        meshRenderer.material = material;
    }

    public void ResetMaterial()
    {
        meshRenderer.material = baseMaterial;
    }
}
