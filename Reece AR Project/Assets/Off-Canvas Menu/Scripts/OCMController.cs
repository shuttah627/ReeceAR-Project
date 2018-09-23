using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class OCMController : MonoBehaviour
{
    public float OpenDragThreshold = 0.35f;
    public float TransitionSpeed = 0.5f;
    public Color OverlayColor = new Color(0, 0, 0, 0.8f);
    public Image DragHandle;
    public Image TransparentPadding;
    private ScrollRect scrollRect;
    private Color transparentColor;

	void Start()
	{
        transparentColor = new Color(OverlayColor.r, OverlayColor.g, OverlayColor.b, 0);
        scrollRect = GetComponent<ScrollRect>();
    }

    void Update()
    {
        DragHandle.color = Color.Lerp(transparentColor, OverlayColor, 1 - scrollRect.horizontalNormalizedPosition);
        TransparentPadding.color = Color.Lerp(transparentColor, OverlayColor, 1 - scrollRect.horizontalNormalizedPosition);
    }
    
    public void Open()
    {
        StartCoroutine(SlideTo(0, TransitionSpeed));

    }

    public void Close()
    {
        StartCoroutine(SlideTo(1, TransitionSpeed));
    }

    private IEnumerator SlideTo(float endXPos, float time)
    {
        var startXPos = scrollRect.horizontalNormalizedPosition;

        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(startXPos, endXPos, i);
            yield return null;
        }
    }

    public void OnEndDrag()
    {
        if (scrollRect.horizontalNormalizedPosition < OpenDragThreshold)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
}
