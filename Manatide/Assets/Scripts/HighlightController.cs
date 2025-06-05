using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject highlight; // L’image cadre à afficher
    private RectTransform highlightRect;
    private RectTransform rectTransform;

    public Vector2 padding = new Vector2(20f, 20f); // marge autour du bouton

    void Start()
    {
        highlightRect = highlight.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();

        // Desactiver le raycast pour eviter clignotement
        Image highlightImage = highlight.GetComponent<Image>();
        if (highlightImage != null)
        {
            highlightImage.raycastTarget = false;
        }
    }


    void Update()
    {
        // Si la souris ne survole plus aucun objet UI, cacher le highlight
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            highlight.SetActive(false);
        }
    }

   

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (highlight != null)
        {
            highlight.SetActive(true);

            // Convertir la position du bouton en position dans la Canvas
            Vector3 worldPos = rectTransform.position;

            // Positionner le highlight au même endroit
            highlightRect.position = worldPos;

            // Ajuster la taille en ajoutant un padding
            highlightRect.sizeDelta = rectTransform.sizeDelta + padding;

            // S’assurer que le pivot est bien au centre
            highlightRect.pivot = new Vector2(0.5f, 0.5f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (highlight != null)
        {
            highlight.SetActive(false);
        }
    }
}