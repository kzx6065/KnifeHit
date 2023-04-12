using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public GameObject KnifeCountGo;
    public Sprite usedKnife;
    public int lifeCount = 5;
    public List<Image> lifeUI;

    private void Awake()
    {
        instance = this;
    }
    private void OnDestroy()
    {
        instance = null;
    }

    public void Start()
    {
        currentLife = lifeCount;
        lifeUI.Add(KnifeCountGo.GetComponent<Image>());
        for(int i = 1; i < lifeCount; i++)
        {
            var newLifeGo = Instantiate(KnifeCountGo, KnifeCountGo.transform.parent);
            lifeUI.Add(newLifeGo.GetComponent<Image>());
        }
    }
    public int currentLife;
    public CanvasGroup gameoverUICanvasGroup;
    private float duration = 0.5f;
    public void UseLife()
    {
        currentLife--;
        lifeUI[lifeUI.Count - currentLife - 1].sprite = usedKnife;
        
        if(currentLife == 0)
        {
            gameoverUICanvasGroup.gameObject.SetActive(true);
            gameoverUICanvasGroup.alpha = 0;
            gameoverUICanvasGroup.DOFade(1, duration);
        }
    }
}
