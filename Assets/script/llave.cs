using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour
{
    public SpriteRenderer[] wallElements;
    float alphaValue = 0f;
    public float disappearRate;
    bool playerEntered = false;

    public bool toggleWall = false;
    // Update is called once per frame
    void Update()
    {
        if (playerEntered)
        {
            alphaValue += Time.deltaTime * disappearRate;
            if (alphaValue >= 1)
            {
                alphaValue = 1;
            }
            foreach (SpriteRenderer wallItem in wallElements)
            {
                wallItem.color = new Color(wallItem.color.r, wallItem.color.g, wallItem.color.b, alphaValue);
            }
        }

        else
        {
            alphaValue -= Time.deltaTime * disappearRate;
            if (alphaValue <= 0)
            {
                alphaValue = 0;

            }
            foreach (SpriteRenderer wallItem in wallElements)
            {
                wallItem.color = new Color(wallItem.color.r, wallItem.color.g, wallItem.color.b, alphaValue);
            }
        }




    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerEntered = true;
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && toggleWall)
        {
            playerEntered = false;
        }

    }
}

