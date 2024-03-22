using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyScript : Settings
{
    private Animator animator;
    [SerializeField] private TextMeshPro text;

    List<Skin> skinBuy;

    private List<int> SkinOpens;

    void Start()
    {
        animator = GetComponent<Animator>();
        skinBuy = new List<Skin>()
        {
            new Skin { SkinID = 1, SkinMoney = 1},
            new Skin { SkinID = 2, SkinMoney = 2},
            new Skin { SkinID = 3, SkinMoney = 3}
        };
        gameObject.SetActive(false);
        SkinOpens = SkinOpensGet();
    }

    void Update()
    {
        
    }

    public void BuyEnebled(int num)
    {
        gameObject.SetActive(false);
        foreach (Skin skin in skinBuy)
        {
            if(skin.SkinID == num && !SkinOpens.Contains(num))
            {
                gameObject.SetActive(true);
                text.text = $"{skin.SkinMoney}";
            }
        }
        
    }

    private void Disaible()
    {
        animator.SetBool("Buy", false);
        gameObject.SetActive(false);
    }

    public void BuySkin()
    {
        if (CoinGet() >= skinBuy[ScinNum-1].SkinMoney)
        {
            CoinSet(-skinBuy[ScinNum-1].SkinMoney);
            animator.SetBool("Buy", true);
            SkinOpensSet(Settings.ScinNum);
        }
    }
}
