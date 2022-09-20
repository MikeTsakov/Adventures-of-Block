using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : Level {
    int[] orientations = new int[] { 1, 1, 1, 1, 1 };
    const float cloudWaitDuration = 3f;
    const float thunderDuration = 2f;


    protected override IEnumerator LevelScript()
    {
        //PlayBackground();
        int orientation = orientations[Log.Attempt-1];
        rafts.Spawn(v2(-0.3f, -1f), true);
        rafts.Spawn(v2(0.35f, -1f), true);
        yield return WaitTick(1);

        StartBoxWarning(3f, "right");
        yield return WaitTick(2);
        var cloudLeft = spawnCloud(-0.525f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudRight = spawnCloud(0.525f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        yield return WaitTick(1);
        EndBoxWarning("right");

        var starF = spawnStar(0.7f);
        var sweep = spawnSweep(1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        Rigidbody2D rgb = sweep.GetComponent<Rigidbody2D>();
        rgb.gravityScale = 0;
        rgb.velocity += new Vector2(-orientation * 10f, 0);

        spawnBomb(0f, 0.05f, 3, 4, 1);

        //Debug.Log("1");

        StartFloodWarn();
        yield return WaitTick(5);
        EndFloodWarn();

        ObjectPool.Despawn(sweep, "sweep pool");
        ObjectPool.Despawn(starF, "star pool");

        StartFlood();
        yield return WaitTick(5);
        EndFlood();
        yield return WaitTick(1);

        StartBoxWarning(3f, "left");
        yield return WaitTick(2);
        var cloudRight5 = spawnCloud(1f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudRight1 = spawnCloud(0.75f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudRight2 = spawnCloud(0.5f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        yield return WaitTick(1);
        EndBoxWarning("left");

        var sweep2 = spawnSweep(-1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        Rigidbody2D rgb2 = sweep2.GetComponent<Rigidbody2D>();
        rgb2.velocity += new Vector2(orientation * 10f, 0);

        yield return WaitTick(1);
        spawnBomb(0f, 0.05f, 3, 4, 1);
        var starNew1 = spawnStar(0.7f);

        yield return WaitTick(1);
        var cloudLeft5 = spawnCloud(-1f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudLeft1 = spawnCloud(-0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudLeft2 = spawnCloud(-0.6f, 1, 1.4f, cloudWaitDuration, thunderDuration);

        //Debug.Log("2");

        var starMiddle = spawnStar(0);
        yield return WaitTick(4);
        ObjectPool.Despawn(starNew1, "star pool");
        ObjectPool.Despawn(sweep2, "sweep pool");
        var starMiddle2 = spawnStar(-0.8f);
        yield return WaitTick(3);
        var starMiddle3 = spawnStar(0.9f);
        yield return WaitTick(1);
        spawnBomb(0.0f * orientation, 0.05f, 2f, 2, 1);
        var cloudLeft3 = spawnCloud(0.7f, 1, 1.4f, cloudWaitDuration - 1.5f, thunderDuration);
        yield return WaitTick(2);

        spawnBomb(0.5f, 0.05f, 2f, 2, 1);
        ObjectPool.Despawn(starMiddle, "star pool");
        yield return WaitTick(4);
        ObjectPool.Despawn(starMiddle2, "star pool");
        yield return WaitTick(2);
        ObjectPool.Despawn(starMiddle3, "star pool");

        //Debug.Log("3");

        var cloudLeft4 = spawnCloud(-0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudRight4 = spawnCloud(0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var starLeft2 = spawnStar(-0.8f);
        var starRight = spawnStar(0.8f);
        var movingCloud = spawnCloud(orientation * 0.7f, 1, 1, cloudWaitDuration, thunderDuration);
        Rigidbody2D mcRB = movingCloud.AddComponent<Rigidbody2D>();
        mcRB.velocity += new Vector2(-orientation * 2f, 0);
        mcRB.gravityScale = 0;
        yield return WaitTick(4);

        mcRB.velocity -= new Vector2(-orientation * 4f, 0);
        yield return WaitTick(2);

        ObjectPool.Despawn(starLeft2, "star pool");
        ObjectPool.Despawn(starRight, "star pool");
        spawnBomb(-0.7f, 0.05f, 1.5f, 4, 1);
        spawnBomb(0f, 0.05f, 1.7f, 4, 1);
        spawnBomb(0.7f, 0.05f, 1.5f, 4, 1);
        yield return WaitTick(4);

        //Debug.Log("4");

        StartFloodWarn();
        var randomStar = spawnStar(0.1f);
        yield return WaitTick(3);
        EndFloodWarn();
        cloudLeft4 = spawnCloud(0.45f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        yield return WaitTick(1);
        StartFlood();
        yield return WaitTick(5);

        ObjectPool.Despawn(randomStar, "star pool");
        EndFlood();

        yield return WaitTick(1);
        spawnCloud(-0.4f, 1, 1, 2f, 2f);
        spawnCloud(0.6f, 1, 1, 2f, 2f);
        yield return WaitTick(4);

        spawnBomb(0.1f, 0.05f, 2f, 2, 1);
        var randomStar2 = spawnStar(-0.7f);
        yield return WaitTick(5);

        ObjectPool.Despawn(randomStar2, "star pool");
        var starNew2 = spawnStar(-0.5f);
        var starNew3 = spawnStar(0.5f);
        StartFloodWarn();
        yield return WaitTick(2);
        EndFloodWarn();
        StartFlood();
        yield return WaitTick(4);
        EndFlood();
        ObjectPool.Despawn(starNew2, "star pool");
        ObjectPool.Despawn(starNew3, "star pool");
        yield return WaitTick(2);

        yield return base.LevelScript();
    }
}
