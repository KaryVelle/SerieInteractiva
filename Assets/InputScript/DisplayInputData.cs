using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;


[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    [FormerlySerializedAs("_pen")] public Pen pen;
    [SerializeField] public StartDissolveAnim dissolveAnim;
    [SerializeField] private DissolveTextures dissolveTextures;
    public MoveKey moveKey;
    public bool penGrabbed = false;
    private InputData _inputData;
    [SerializeField] private MoveManager moveManager;

    
    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    public void Update()
    {
        if (!_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out var rightPrimBtn))return;
        {
            if (rightPrimBtn && dissolveAnim.isControllerGrabbed)
            {
                Debug.Log(rightPrimBtn);
                StartCoroutine(dissolveTextures.DissolveMaterials());
            }
            if (rightPrimBtn && pen.isGrabbed)
            {
                pen.Draw();
            }
            else if (pen.currentDrawing != null)
            {
                pen.currentDrawing = null;
            }

        }
        
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out var right2DAxis))
        {
            if (dissolveTextures.dissolveCorEnded)
            {
                moveManager.StartMovement();
            }
        }
    }
   
}
