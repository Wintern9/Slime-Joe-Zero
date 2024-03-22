using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonPlay : MonoBehaviour
{
    [SerializeField] private Animator animatorCloud;
    private Animator _thisAnimator;
    private Image ChildImage;

    [SerializeField] private GameObject CanvasEnebl;
    [SerializeField] private GameObject CanvasDisable;
    [SerializeField] private GameObject ButtonDis;

    [SerializeField] private Button[] buttons;

    void Start()
    {
        _thisAnimator = GetComponent<Animator>();
        ChildImage = GetComponentInChildren<Image>();

    }

    bool ButtonClick = false;

    private void Update()
    {
        if(ButtonClick)
            Opacity();

        if (_thisAnimator.GetCurrentAnimatorStateInfo(0).IsName("Main"))
        {
            ButtonDis.SetActive(false);
        }
    }

    private void Opacity()
    {
        if (ChildImage.color.a <= 0)
        {
            CanvasEnebl.SetActive(false);
            CanvasDisable.SetActive(true);
            //animatorCloud.SetBool("Levels", false);
            _thisAnimator.SetBool("Burron", false);
        }
    }    

    public void ButtonPlay()
    {
        ButtonClick = true;
        animatorCloud.SetBool("Levels", true);
        _thisAnimator.SetBool("Burron", true);
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
    }
    
    public void ButtonBack()
    {
        ButtonClick = false;
        _thisAnimator.gameObject.SetActive(true);
        animatorCloud.SetBool("Levels", false);
        _thisAnimator.SetBool("Burron", false);
        _thisAnimator.Play("CloudsAnimationMenuButton 1");

        foreach (var button in buttons)
        {
            button.interactable = true;
        }
    }


}
