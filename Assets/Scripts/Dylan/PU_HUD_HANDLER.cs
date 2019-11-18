using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PU_HUD_HANDLER : MonoBehaviour
{
    public const float maxAlpha = 1.00f;
    public const float minAlpha = 0.00f;
    public const float duration = 3.00f;
    public int flag = 1;

    public SpriteRenderer powerUp;

    // Start is called before the first frame update
    void Start()
    {
        powerUp.color = new Color(1f, 1f, 1f, 0.0f);
    }

    // Update is called once per frame
    public abstract void Update();
    public abstract void powerUpTimer();
}
