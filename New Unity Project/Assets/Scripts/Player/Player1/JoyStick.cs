/****************************************************
    文件：JoyStick.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : ScrollRect 
{
    private float radius;

    private Transform imgArrowTrans;

    void Start()
    {
        radius = content.sizeDelta.x * 0.5f;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        Vector2 contentPosition = content.anchoredPosition;
        //判断摇杆的位置是否大于半径
        if (contentPosition.magnitude > radius)
        {
            //摇杆位置设置到边界处
            contentPosition = contentPosition.normalized * radius;
            SetContentAnchoredPosition(contentPosition);
        }
        Vector2 inputVector = content.anchoredPosition.normalized;
        StaticData.inputValue = inputVector;

    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        SetContentAnchoredPosition(Vector2.zero);
        StaticData.inputValue = Vector2.zero;
    }
}