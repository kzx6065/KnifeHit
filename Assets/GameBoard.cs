using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public float minAngle = 1000f;
    public float maxAngle = 1200f;
    public float minDuration = 2;
    public float maxDuration = 3;
    public Ease ease = Ease.InOutQuart;

    void Start()
    {
        DOTween.To(
            () => transform.rotation.eulerAngles.z,
            x => transform.rotation = Quaternion.Euler(0.0f, 0.0f, x),
            Random.Range(minAngle, maxAngle),
            Random.Range(minDuration, maxDuration)
            )
            .SetEase(ease)
            .SetLoops(-1, LoopType.Incremental);


        MakeApples();
    }

    public Sprite apple;
    public int appleMin = 2;
    public int appleMax = 4;
    public float appleDistance = 1.75f;

    private void MakeApples()
    {
        //사과 랜덤 생성.
        var center = transform.position;
        int appleCount = Random.Range(appleMin, appleMax);

        for (int i = 0; i < appleCount; i++)
        {
            float appleRotation = Random.Range(0, 360);
            GameObject newApple = new GameObject("apple");
            newApple.transform.rotation = Quaternion.Euler(0, 0, appleRotation);
            newApple.transform.position = center;
            newApple.transform.SetParent(transform);

            newApple.transform.localPosition = newApple.transform.up * appleDistance;
            newApple.AddComponent<SpriteRenderer>().sprite = apple;
            newApple.tag = "Apple";

            var direction = (newApple.transform.position - center).normalized;
            newApple.transform.right = direction;
            newApple.transform.Rotate(new Vector3(0, 0, -90), Space.Self);
        }
    }
}
