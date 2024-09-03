using System;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    public Pen _pen;
    public MoveKey moveKey;
    public bool penGrabbed = false;
    private InputData _inputData;
    private DisplayInputData _displayInputData;


    private void Start()
    {
        _displayInputData = GetComponent<DisplayInputData>();
        _inputData = GetComponent<InputData>();
    }

    public void Update()
    {
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out var rightPrimBtn))
        {
            if (rightPrimBtn && _pen.isGrabbed)
            {
                
                _pen.Draw();
            }
            else if (_pen.currentDrawing != null)
            {
                _pen.currentDrawing = null;
            }
        }
        
    }

   
}
