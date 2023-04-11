using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public Knife knife;

    private void Start()
    {
        knife = FindObjectOfType<Knife>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            var newKnife = Instantiate(knife);
            newKnife.enabled = true;
            newKnife.GetComponent<Collider2D>().enabled = true;
            GameManager.instance.UseLife();
        }
    }
}
