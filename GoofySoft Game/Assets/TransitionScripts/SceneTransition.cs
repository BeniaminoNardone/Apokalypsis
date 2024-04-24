using System.Collections;
using UnityEngine;
 
public abstract class Scene_Transition : MonoBehaviour
{
    public abstract IEnumerator AnimateTransitionIn();
    public abstract IEnumerator AnimateTransitionOut();
}