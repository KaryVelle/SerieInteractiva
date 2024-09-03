using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDissolveAnim : MonoBehaviour
{
   #region Variables

   [SerializeField] private DissolveTextures dissolveTextures;
   [SerializeField] private bool isGrabbed;
   #endregion


   public void Pick()
   {
      Debug.Log("<color=green>Begin Dissolve</color>");
      StartCoroutine(dissolveTextures.DissolveMaterials());
   }
}
