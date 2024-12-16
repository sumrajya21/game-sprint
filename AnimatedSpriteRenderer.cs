using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    public Sprite idleSprite;
    public Sprite[] animationSprites;

    public float AnimateTime = 0.25f;
    private int AnimationFrame;

    public bool loop = true;
    public bool idle = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(NextFrame), AnimateTime, AnimateTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void NextFrame()
    {
        AnimationFrame++;
        if (AnimationFrame >= animationSprites.Length && loop)
        {
            AnimationFrame = 0;
        }
        if (idle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if (animationSprites.Length > 0 && AnimationFrame < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[AnimationFrame];
        }
    }
}
