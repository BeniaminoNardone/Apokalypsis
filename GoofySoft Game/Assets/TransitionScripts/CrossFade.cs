using System.Collections;
using UnityEngine;
using DG.Tweening;
 
[System.Serializable]
public class CrossFade : Scene_Transition
{
    public CanvasGroup crossFade;
    
    public override IEnumerator AnimateTransitionIn()
    {
        var tweener = crossFade.DOFade(1f, 1f);
        yield return tweener.WaitForCompletion();
    }
 
    public override IEnumerator AnimateTransitionOut()
    {
        var tweener = crossFade.DOFade(0f, 0.5f);
        yield return tweener.WaitForCompletion();
    }
}