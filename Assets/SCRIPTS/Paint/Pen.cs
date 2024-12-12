using System.Runtime.InteropServices.ComTypes;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField][Range(2, 20)] private int _penRadius = 10;
    public int PenRadius => _penRadius;
    [SerializeField] private Image _penPointer;
    private RectTransform _canvas;
    private Color32 _penColour = new(0, 0, 0, 255);
    public Color32 PenColour => _penColour;
    // public Color32 backroundColour = new(0, 0, 0, 0);
    public bool IsInFocus
    {
        get => _isInFocus;
        private set
        {
            if (value != _isInFocus)
            {
                _isInFocus = value;
                TogglePenPointerVisibility(value);
            }
        }
    }
    private bool _isInFocus = false;

    private void Awake()
    {
        _canvas = (RectTransform)GetComponentInParent<Canvas>().transform;
    }
    private void Update()
    {
        if (IsInFocus)
        {
            SetPenPointerPosition();
        }
    }
    private void OnEnable()
    {
        TogglePenPointerVisibility(false);
    }
    private void SetPenPointerSize()
    {
        var rt = _penPointer.rectTransform;
        rt.sizeDelta = new Vector2(_penRadius * 5, _penRadius * 5);
    }
    private void SetPenPointerPosition()
    {
        // _penPointer.transform.position = Input.mousePosition;
        Vector2 scale = new(_canvas.rect.width / Screen.width, _canvas.rect.height / Screen.height);
        _penPointer.rectTransform.anchoredPosition = Vector2.Scale(Input.mousePosition, scale);
    }
    private void TogglePenPointerVisibility(bool isVisible)
    {
        if (isVisible)
            SetPenPointerSize();

        _penPointer.gameObject.SetActive(isVisible);
        Cursor.visible = !isVisible;
    }
    public void OnPointerEnter(PointerEventData eventData) => IsInFocus = true;
    public void OnPointerExit(PointerEventData eventData) => IsInFocus = false;
}
