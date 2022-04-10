using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public struct CardData
    {
        public Sprite sprite;
        public int value;

        public static int operator -(CardData source, CardData to)
        {
            if ((source.value == 1 && to.value == 13) || (source.value == 13 && to.value == 1))
                return 1;

            return Mathf.Abs(source.value - to.value);
        }
    }

    CardData infos;
    Image img;
    bool initBack;

    public void Setup(CardData cardInfos, bool startBack)
    {
        infos = cardInfos;
        initBack = startBack;
    }

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        if (initBack)
            ShowBack();
        else
            ShowFront();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetCard(CardData data)
    {
        infos = data;

        if (initBack)
            ShowBack();
        else
            ShowFront();
    }

    public void ShowFront()
    {
        img.sprite = infos.sprite;
        initBack = false;
    }

    public void ShowBack()
    {
        img.sprite = MainDeck.instance.CardBack;
        initBack = true;
    }

    // Distance des valeurs entre deux cartes. Le Roi et l'As sont � une distance de 1
    // Ne renvoie que des valeurs positives (sauf en cas d'erreur)
    public static int operator -(Card source, Card to)
    {
        if (source == null || to == null)
            return -1;

        if ((source.infos.value == 1 && to.infos.value == 13) || (source.infos.value == 13 && to.infos.value == 1))
            return 1;

        return Mathf.Abs(source.infos.value - to.infos.value);
    }

}
