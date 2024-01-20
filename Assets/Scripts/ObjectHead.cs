using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectHead : MonoBehaviour
{
    public Sprite[] spriteImage;
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    SpriteRenderer m_SpriteRenderer;
    public int NumberInList = 0;
    int IndexOfSAndS;

    void IsMissing()
    {
        for (int i = 0; i < GameManager.IndicesForSAndS.Length; i++)
        {
            if (GameManager.CorrectSerie[GameManager.NowIndex] == GameManager.IndicesForSAndS[i] && i != NumberInList)
            {
                System.Random rand = new System.Random();
                GameManager.IndicesForSAndS[NumberInList] = rand.Next(0, 7);
                return;
            }
        }
        GameManager.IndicesForSAndS[NumberInList] = GameManager.CorrectSerie[GameManager.NowIndex];
    }

    public void OnClickItem()
    {
        audioSource.PlayOneShot(audioClip[GameManager.IndicesOfSounds[IndexOfSAndS]]);
        if (IndexOfSAndS == GameManager.CorrectSerie[GameManager.NowIndex])
        {
            GameManager.NowIndex += 1;
            if (GameManager.NowIndex == GameManager.CorrectSerie.Length)
            {
                GameManager.NowIndex = 0;
                GameManager.Score += 1;
                for (int i = 0; i < GameManager.IndicesForSAndS.Length; i++)
                {
                    if (i > GameManager.IndicesForSAndS.Length - GameManager.CorrectSerie.Length)
                    {
                        int value = GameManager.CheckAllIds(i);
                        if (value == 0)
                            continue;

                    }
                    System.Random rnd = new System.Random();
                    GameManager.IndicesForSAndS[i] = rnd.Next(0, 7);
                }
            }
            else
            {
                IsMissing();
            }
        }
        else
        {
            GameManager.NowIndex = 0;
            IsMissing();
        }
    }
    void Update()
    {
        if (GameManager.ArrReady)
        {
            IndexOfSAndS = GameManager.IndicesForSAndS[NumberInList];
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.sprite = spriteImage[GameManager.IndicesOfSprites[IndexOfSAndS]];
        }
    }
}
