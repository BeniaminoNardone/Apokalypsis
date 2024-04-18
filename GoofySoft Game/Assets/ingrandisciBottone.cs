using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float scaleFactor = 1.1f; // fattore di scala per l'ingrandimento
    public float scaleSpeed = 5f; // velocità di interpolazione della scala

    private bool isHovered = false;

    void Start()
    {
        originalScale = transform.localScale; // salvataggio della scala originale
    }

    void Update()
    {
        // Se il cursore è sopra il pulsante, scala gradualmente
        if (isHovered)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * scaleFactor, Time.deltaTime * scaleSpeed);
        }
        else // Altrimenti, torna gradualmente alla scala originale
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * scaleSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Quando il cursore entra nel pulsante, imposta il flag su true
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Quando il cursore esce dal pulsante, imposta il flag su false
        isHovered = false;
    }
}
