using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlightController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Button Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightedSprite;

    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = normalSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = highlightedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;
    }
}