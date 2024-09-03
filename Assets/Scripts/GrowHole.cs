using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

public class GrowHole : MonoBehaviour
{
    [SerializeField] private Material hole;
    public static int SizeID = Shader.PropertyToID("_Size");
    [SerializeField] private float sizeValue;
    public static int OpacityID = Shader.PropertyToID("_Opacity");
    [SerializeField] private float opacityValue;
    [SerializeField] private float duration = 5f; // Tiempo en segundos para completar la animación


    public IEnumerator StartGrowing()
    {
        float elapsedTime = 0f;
        float initialSizeValue = 0f;
        float targetSizeValue = 3f;
        float initialOpacityValue = 0f;
        float targetOpacityValue = 1f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            sizeValue = Mathf.Lerp(initialSizeValue, targetSizeValue, elapsedTime / duration);
            opacityValue = Mathf.Lerp(initialOpacityValue, targetOpacityValue, elapsedTime / duration);

            hole.SetFloat(SizeID, sizeValue);
            hole.SetFloat(OpacityID, opacityValue);

            yield return null; // Espera hasta el siguiente frame
        }

        // Asegurarse de que los valores finales se establecen correctamente
        sizeValue = targetSizeValue;
        opacityValue = targetOpacityValue;

        hole.SetFloat(SizeID, sizeValue);
        hole.SetFloat(OpacityID, opacityValue);
    }
}
