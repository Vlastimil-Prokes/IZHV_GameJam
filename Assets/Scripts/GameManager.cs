using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    static public int[] IndicesForSAndS = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    static public int[] IndicesOfSounds = { 0, 1, 2, 3, 4, 5, 6 };
    static public int[] IndicesOfSprites = { 0, 1, 2, 3, 4, 5, 6 };
    static public bool ArrReady = false;
    static public int Score = 0;
    static public int NowIndex = 0;
    static public int[] CorrectSerie = { 0, 0, 0, 0, 0 };
    static public int[] StartGameLook = { -1, -1, -1, -1, -1 };

    static public void Randomize(int[] items)
    {
        System.Random rand = new System.Random();

        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = rand.Next(i, items.Length);
            int temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }

    static public int CheckAllIds(int i)
    {
        for (int j = 0; j < CorrectSerie.Length; j++)
        {
            for (int k = 0; k < i; k++)
            {
                if (CorrectSerie[j] == IndicesForSAndS[k])
                    break;
                else if (k + 1 == i)
                {
                    IndicesForSAndS[i] = CorrectSerie[j];
                    return 0;
                }
            }
        }
        return 1;
    }

    static void NewCorrectSerie()
    {
        for (int i = 0; i < CorrectSerie.Length; i++)
        {
            System.Random rnd = new System.Random();
            CorrectSerie[i] = rnd.Next(0, 7);
        }
    }

    static void NewStartGameLook()
    {
        for (int i = 0; i < CorrectSerie.Length; i++)
        {
            if (i == 0)
            {
                StartGameLook[i] = CorrectSerie[i];
                continue;
            }
            bool set = true;
            int placing = CorrectSerie[i];
            while (set)
            {
                for (int j = 0; j < i; j++)
                {
                    if (StartGameLook[j] == placing)
                    {
                        System.Random rnd = new System.Random();
                        StartGameLook[i] = rnd.Next(0, 7);
                        placing = StartGameLook[i];
                        break;
                    }
                    else if (j + 1 == i)
                    {
                        StartGameLook[i] = placing;
                        set = false;
                    }
                }
            }
        }
    }

    static void NewIndicesForSAndS()
    {
        for (int i = 0; i < IndicesForSAndS.Length; i++)
        {
            if (i > IndicesForSAndS.Length - CorrectSerie.Length)
            {
                int value = CheckAllIds(i);
                if (value == 0)
                    continue;

            }
            System.Random rnd = new System.Random();
            IndicesForSAndS[i] = rnd.Next(0, 7);
        }
    }

    static public void SetupGame()
    {
        GameManager.NewCorrectSerie();
        GameManager.NewStartGameLook();
        GameManager.NewIndicesForSAndS();

        GameManager.Randomize(StartGameLook);
        GameManager.Randomize(IndicesOfSounds);
        GameManager.Randomize(IndicesOfSprites);
        Score = 0;
        NowIndex = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
        ArrReady = true;
    }
}
