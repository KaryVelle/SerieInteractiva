using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class DissolveTextures : MonoBehaviour
{
    [SerializeField] private Material[] dissolveColors;
    [SerializeField] private Material[] dissolveTextures;
    [SerializeField] private float dissolveTime = 2f; 
    private void Start()
    {
        List<Material> allMaterials = new List<Material>();
        foreach (var mat in allMaterials)
        {
            if (mat.HasProperty("_AlphaClipping"))
            {
                mat.SetFloat("_AlphaClipping", 0);
            }
        }
        StartCoroutine(DissolveMaterials());
    }

    private IEnumerator DissolveMaterials()
    {
        float elapsedTime = 0f;
        
        List<Material> allMaterials = new List<Material>();
        allMaterials.AddRange(dissolveColors);
        allMaterials.AddRange(dissolveTextures);

       
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;
            float alphaValue = Mathf.Clamp01(elapsedTime / dissolveTime);

            foreach (var mat in allMaterials)
            {
                if (mat.HasProperty("_AlphaClipping"))
                {
                    mat.SetFloat("_AlphaClipping", alphaValue);
                }
            }

            yield return null;
        }
        
        foreach (var mat in allMaterials)
        {
            if (mat.HasProperty("_AlphaClipping"))
            {
                mat.SetFloat("_AlphaClipping", 1f);
            }
        }
    }
}
