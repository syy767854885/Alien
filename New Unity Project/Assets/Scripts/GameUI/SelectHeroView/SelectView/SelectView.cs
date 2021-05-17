/****************************************************
    文件：SelectView.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class SelectView : MonoBehaviour 
{
    private Color _default = Color.gray;
    private Color _selected = Color.white;
    private Image img;
    private RectTransform rect;
    void Start()
    {
        transform.Find("playerA").gameObject.AddComponent<SelectPlayerA>();
        transform.Find("playerB").gameObject.AddComponent<SelectPlayerB>();
        transform.Find("playerC").gameObject.AddComponent<SelectPlayerC>();
        
        PlayerInit();
    }
    public void PlayerInit()
    {
        RectTransform rect = GameObject.Find("SelectView").GetComponent<RectTransform>();
        foreach (RectTransform rectTransform in rect)
        {
            img = rectTransform.gameObject.GetComponent<Image>();
            img.color = _default;
        }
        //Debug.Log("asd");

    }



}