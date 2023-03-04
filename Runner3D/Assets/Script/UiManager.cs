using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{   
        public RectTransform mainMenu, configMenu,creditsMenu;
    // Start is called before the first frame update
    void Start()
    {
         mainMenu.DOAnchorPos(Vector2.zero,0.25f);
    }

   public void ConfigBnt()
   {
    mainMenu.DOAnchorPos( new Vector2 (-500,0),0.25f);
    configMenu.DOAnchorPos(new Vector2 (0,0),0.25f);
    }
    public void BackConfigBnt()
    {
        mainMenu.DOAnchorPos(new Vector2(0,0),0.25f);
        configMenu.DOAnchorPos(new Vector2(500,0),0.25f);
    }

    public void CreditsBnt()
    {
        mainMenu.DOAnchorPos(new Vector2(-500,0),0.25f);
        creditsMenu.DOAnchorPos(new Vector2(0,0),0.25f).SetDelay(0.25f);
    }

    public void CloseCredisBnt()
    {
        creditsMenu.DOAnchorPos(new Vector2(0,800),0.25f);
        mainMenu.DOAnchorPos(new Vector2(0,0),0.25f).SetDelay(0.25f);


    }
}
