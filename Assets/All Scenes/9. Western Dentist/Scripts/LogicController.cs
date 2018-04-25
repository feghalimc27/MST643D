using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicController : MonoBehaviour
{
    public static GameObject merryObject;
    public static Sprite pointBallSprite;

    public static int playerScore;
    public RawImage backgroundScroll;
    public Text scoreText;
    public RawImage lifeStatus;
    public RawImage spellStatus;
    public Texture life1;
    public Texture life2;
    public Texture life3;
    public Texture life4;
    public Texture life5;
    public Texture spell1;
    public Texture spell2;
    public Texture spell3;
    public Texture spell4;
    public Texture spell5;

    Texture []lifeStars;
    Texture []spellStars;

    void Start ()
    {
        merryObject = GameObject.Find("Merry").gameObject;
        pointBallSprite = Resources.Load<Sprite>("WesternDentist_PointBall");
        playerScore = 0;
        lifeStars = new Texture[] { life1, life2, life3, life4, life5 };
        spellStars = new Texture[] { spell1, spell2, spell3, spell4, spell5 };
        StartCoroutine(BackgroundScroll());
    }

    void Update()
    {
        scoreText.text = "" + playerScore;
        if (MerryController.merryHealth != 0)
        {
            lifeStatus.texture = lifeStars[MerryController.merryHealth - 1];
        }
    }

    IEnumerator BackgroundScroll()
    {
        for (float t = 2486; t >= -2486; t -= Time.deltaTime * 60)
        {
            backgroundScroll.rectTransform.localPosition = new Vector3(0, t, 0);
            yield return null;
        }
    }
}
