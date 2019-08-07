using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ImageTouchableButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool pressed;
    private Image image;
    public Sprite pointerD, pointerU;

    private void initializeImageButton()
    {
        image = GetComponent<Image>();
        image.sprite = pointerU;
    }

    private void Start() => initializeImageButton();

    public void OnPointerDown(PointerEventData eventData)
    {
        image.sprite = pointerD;
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.sprite = pointerU;
        pressed = false;
    }
}
