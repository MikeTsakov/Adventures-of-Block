using UnityEngine;
using System.Collections;

public enum Variation
{
    None, Video, Slow, Fast, Both
}

public class Level : MonoBehaviour {

    protected ObjectPool bombs, clouds, stars, rafts, sweeps;
    protected WaterScript water, water1;
    protected MusicController music;
    protected Variation soundMode = Log.CurrentMode;
    protected BoxWarningScript leftBoxWarning, rightBoxWarning;

    protected static float tickDuration = 1f; // 1 = 120bpm
    protected float nextTick;
    public static float delay;

    bool finished = false;
    public static float getTickDuration() {
        return tickDuration;
    }

    public static float getDelay() {
        return delay;
    }

    // Use this for initialization
    void Start () {
        bombs = GameObject.Find("bomb pool").GetComponent<ObjectPool>();
        clouds = GameObject.Find("cloud pool").GetComponent<ObjectPool>();
        stars = GameObject.Find("star pool").GetComponent<ObjectPool>();
        rafts = GameObject.Find("raft pool").GetComponent<ObjectPool>();
        sweeps = GameObject.Find("sweep pool").GetComponent<ObjectPool>();
        water = GameObject.Find("water").GetComponent<WaterScript>();
        water1 = GameObject.Find("water1").GetComponent<WaterScript>();
        music = GameObject.Find("MusicController").GetComponent<MusicController>();
        leftBoxWarning = GameObject.Find("left box warning").GetComponent<BoxWarningScript>();
        rightBoxWarning = GameObject.Find("right box warning").GetComponent<BoxWarningScript>();

        nextTick = Time.time + tickDuration;
        soundMode = Log.CurrentMode;
        Log.StartLevel(Time.time);
       
        StartCoroutine(LevelScript());
	}

    void Update()
    {
        if(finished)
        {
            FindObjectOfType<LevelController>().Finish();
        }
    }

    protected GameObject spawnSweep(float x, float y = 1f, float? size = 1f, float? waitDuration = 2f, float? sweepDuration = 2f, bool halfDuration = false) {
        var sweep = sweeps.Spawn(v2(x, y), true);

        waitDuration = 2;
        sweepDuration = 2;

        float? waitTime = waitDuration * tickDuration;
        float? thunderTime = sweepDuration * tickDuration;
        //sweep.GetComponent<PlayerController>().SetProperties(1, waitTime, thunderTime);
        sweep.gameObject.SetActive(true);

        music.StartSweepCue();
        //music.StartCloudCue((halfDuration) ? 4 * tickDuration : 8 * tickDuration, x); // halfDuration makes it so that the lightning will only strike once
        return sweep;
    }

    protected GameObject spawnBomb(float x, float y = 0.05f, float? radius = 4, float explosionDelay = 4, float? teleDuration = 2)
    {
        var bomb = bombs.Spawn(v2(x, y), false);

        explosionDelay = 4; //These values are made constant for a more consistent level design
        //radius = 2;
        teleDuration = 4;

        delay = explosionDelay * tickDuration;
        bomb.GetComponent<BombControllerScript>().SetProperties(radius, delay, teleDuration * tickDuration);
        bomb.gameObject.SetActive(true);

        music.StartBombCue(delay, x);

        return bomb;
    }

    protected GameObject spawnCloud(float x, float y = 1f, float? size = 1f, float? waitDuration = 2f, float? thunderDuration = 2f, bool halfDuration = false)
    {
        var cloud = clouds.Spawn(v2(x, y), true);

        //waitDuration = 2;
        //thunderDuration = 2;

        float? waitTime = waitDuration * tickDuration;
        float? thunderTime = thunderDuration * tickDuration;
        cloud.GetComponent<CloudScript>().SetProperties(1, waitTime, thunderTime);
        cloud.gameObject.SetActive(true);

        //music.StartCloudCue((halfDuration) ? 4 * tickDuration : 8 * tickDuration, x); // halfDuration makes it so that the lightning will only strike once
        return cloud;
    }

    protected GameObject spawnStar(float x, float y = 1.5f)
    {
        float my = y;

        var star = stars.Spawn(v2(x, my), true);
        star.gameObject.SetActive(true);

        music.StartStarCue();

        return star;
    }

    protected void StartBoxWarning(float warningDuration, string box)
    {
        if (box.Equals("left"))
        {
            //leftBoxWarning.gameObject.SetActive(true);
            leftBoxWarning.SetProperties(warningDuration, true);
        }
        else
        {
            //rightBoxWarning.gameObject.SetActive(true);
            rightBoxWarning.SetProperties(warningDuration, true);
        }
        music.StartSweepWarningCue();
    }

    protected void EndBoxWarning(string box)
    {
        if (box.Equals("left"))
        {
            //leftBoxWarning.gameObject.SetActive(false);
            //leftBoxWarning.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            //rightBoxWarning.gameObject.SetActive(false);
            //rightBoxWarning.GetComponent<Renderer>().enabled = false;
        }
    }

    protected void StartFloodWarn() {
        water1.State = WaterState.Warn;
        music.StartFloodWarningCue();
        //music.FadeOutBGMusic();
    }

    protected void EndFloodWarn() {
        water1.State = WaterState.Ebb;
        //music.EndFloodCue();
        //music.FadeInBGMusic();
    }

    protected void StartFlood()
    {
        water.State = WaterState.Flood;
        music.StartFloodCue();
        //music.FadeOutBGMusic();
    }

    protected void EndFlood()
    {
        water.State = WaterState.Ebb;
        //music.EndFloodCue();
        //music.FadeInBGMusic();
    }

    /*
    protected void PlayBackground()
    {
        if (soundMode == Variation.None)
            music.PlayBackground();
        if (soundMode == Variation.Video)
            music.PlayBeat();
    }
    */


    private bool hasNextTickPassed()
    {
        if(Time.time >= nextTick)
        {
            nextTick += tickDuration;
            return true;
        }
        return false;
    }

    protected IEnumerator WaitTick(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitUntil(hasNextTickPassed);
            Log.NextTick();
        }
    }

    public static Vector2 v2(float x, float y)
    {
        //left floor = -6.38, -0.44
        //right floor = 6.38, -0.44
        //ebb level = -4
        //cloud height is around 3.
        //This provides a scaling method so everything on the screen can be defined from -1 to 1.
        return new Vector2(x * 6.38f, y * 3.56f - 0.44f);
    }

    protected virtual IEnumerator LevelScript()
    {
        finished = true;
        yield return null;
    }

}
