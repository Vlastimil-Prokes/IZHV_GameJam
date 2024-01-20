using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundSG : MonoBehaviour
{

    public Sprite[] spriteImage;
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    SpriteRenderer m_SpriteRenderer;
    public int NumberInList = 0;

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip[GameManager.IndicesOfSounds[GameManager.StartGameLook[NumberInList]]]);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = spriteImage[GameManager.IndicesOfSprites[GameManager.StartGameLook[NumberInList]]];
    }

}
