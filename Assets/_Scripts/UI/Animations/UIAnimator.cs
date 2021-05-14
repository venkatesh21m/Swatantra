using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Swatantra.UI
{
    public class UIAnimator : MonoBehaviour
    {
        #region serialized variables
        
        [Header("Size Variations")]
        [SerializeField] Vector2 NormalSize;
        [SerializeField] Vector2 HighlightedSize;
        [SerializeField] Vector2 ClickedSize; 
        
        [Header("position Variations")]
        [SerializeField] Vector2 Normalpos;
        [SerializeField] Vector2 Highlightedpos;
        [SerializeField] Vector2 Clickedpos;

        #endregion

        #region private variables
        
        private RectTransform rectTransform;
        private UIAnimatorHolder animatorHolder;
        private bool cliked = false;
        #endregion

        #region unityDefault functions

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            animatorHolder = GetComponentInParent<UIAnimatorHolder>();
        }

        #endregion


        #region pointer interactions

        public void OnPointerEnter()
        {
            if (cliked) return;
            
            rectTransform.DOKill();

            rectTransform.DOAnchorPos(Highlightedpos, 0.1f);
            rectTransform.DOSizeDelta(HighlightedSize, 0.1f);
        }

        public void OnPointerExit()
        {
            if (cliked) return;
           
            rectTransform.DOKill();

            rectTransform.DOAnchorPos(Normalpos, 0.1f);
            rectTransform.DOSizeDelta(NormalSize, 0.1f);
        }

        public void OnPointerClick()
        {
            animatorHolder.ResetAnimators();
            rectTransform.DOKill();
            
            cliked = true;
            
            rectTransform.DOAnchorPos(Clickedpos, 0.1f);
            rectTransform.DOSizeDelta(ClickedSize, 0.1f);
        }

        #endregion


        public void ResetAnim()
        {
            cliked = false;

            rectTransform.DOAnchorPos(Normalpos, 0.1f);
            rectTransform.DOSizeDelta(NormalSize, 0.1f);
        }
    }
}
