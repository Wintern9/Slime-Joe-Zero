using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSkinButtons : MonoBehaviour
{
    static private Color ButtonColorEnable;
    static private Color ButtonColorEnableChild;
    static private Color ButtonColorDisable;
    static private Color ButtonColorDisableChild;

    static private float PositionButtonEnable;
    static private float PositionButtonDisable;

    [SerializeField] private GameObject[] ButtonsMenuSkin;

    static private int NumButtonEnable = 0;
    [SerializeField]private int thisButtonNumInfo;

    [SerializeField] private GameObject ElementSkinView;

    private void Start()
    {
        if (ButtonsMenuSkin != null)
        {
            ButtonColorEnable = ButtonsMenuSkin[0].GetComponent<Image>().color;
            ButtonColorEnableChild = ButtonsMenuSkin[0].transform.GetChild(0).GetComponent<Image>().color;
            PositionButtonEnable = ButtonsMenuSkin[0].transform.position.x;

            ButtonColorDisable = ButtonsMenuSkin[1].GetComponent<Image>().color;
            ButtonColorDisableChild = ButtonsMenuSkin[1].transform.GetChild(0).GetComponent<Image>().color;
            PositionButtonDisable = ButtonsMenuSkin[1].transform.position.x;
        }

        gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick());
    }

    private void Update()
    {
        if(NumButtonEnable != thisButtonNumInfo)
        {
            gameObject.GetComponent<Image>().color = ButtonColorDisable;
            gameObject.GetComponent<RectTransform>().position = new Vector2 (PositionButtonDisable, gameObject.GetComponent<RectTransform>().position.y);
            transform.GetChild(0).GetComponent<Image>().color = ButtonColorDisableChild;
            ElementSkinView.SetActive(false);
        }
    }

    private void OnButtonClick()
    {
        NumButtonEnable = thisButtonNumInfo;
        gameObject.GetComponent<Image>().color = ButtonColorEnable;
        gameObject.GetComponent<RectTransform>().position = new Vector2(PositionButtonEnable, gameObject.GetComponent<RectTransform>().position.y);
        transform.GetChild(0).GetComponent<Image>().color = ButtonColorEnableChild;
        ElementSkinView.SetActive(true);
    }
}
