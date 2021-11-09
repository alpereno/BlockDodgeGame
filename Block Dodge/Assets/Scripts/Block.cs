using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //The only task of the block is to go upwards at the specified angle.
    //and will be destroy when reach border line

    [SerializeField] private Vector2 speedMinMax;
    float visibleHeightThreshold;
    float speed;

    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Utility.getDifficultyPercent());
        visibleHeightThreshold = Camera.main.orthographicSize + transform.localScale.y;
    }

    private void Update()
    {
        // if you don't want to move specific angle change the Space.Self to Space.World
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        if (transform.position.y > visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}