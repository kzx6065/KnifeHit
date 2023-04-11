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
        for(int i = 1; i < lifeCount; i++)
        {
            Instantiate(KnifeCountGo, KnifeCountGo.transform);
        }
    }
    public int currentLife;
    public void UseLife()
    {
        currentLife--;
        lifeUI[currentLife - 1].sprite = usedKnife;
    }
}
