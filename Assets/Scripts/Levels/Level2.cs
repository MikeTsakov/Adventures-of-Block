using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level {
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

        StartBoxWarning(3f, "left");
        yield return WaitTick(3);
        EndBoxWarning("left");

        var cloudLeft = spawnCloud(-0.5f, 1, 1.4f, cloudWaitDuration, thunderDuration - 0.5f);
        var cloudRight = spawnCloud(0.6f, 1, 1.4f, cloudWaitDuration, thunderDuration);

        var sweep = spawnSweep(-1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        Rigidbody2D rgb = sweep.GetComponent<Rigidbody2D>();
        rgb.gravityScale = 0;
        rgb.velocity += new Vector2(orientation * 10f, 0);

        spawnBomb(-0.2f, 0.05f, 3, 4, 1);

        var star = spawnStar(-0.2f);

        var movingCloud = spawnCloud(orientation * 0.7f, 1, 1, cloudWaitDuration, thunderDuration);
        Rigidbody2D mcRB = movingCloud.AddComponent<Rigidbody2D>();
        mcRB.velocity += new Vector2(-orientation * 2f, 0);
        mcRB.gravityScale = 0;
        yield return WaitTick(4);

        mcRB.velocity -= new Vector2(-orientation * 3f, 0);
        var star2 = spawnStar(-0.9f);
        yield return WaitTick(2);

        ObjectPool.Despawn(star, "star pool");

        var star0 = spawnStar(0.2f);

        StartFloodWarn();
        yield return WaitTick(4);
        EndFloodWarn();

        ObjectPool.Despawn(sweep, "sweep pool");
        ObjectPool.Despawn(star2, "star pool");

        var cloudLeft2 = spawnCloud(-0.4f, 1, 1.4f, cloudWaitDuration, thunderDuration-0.5f);
        var cloudRight2 = spawnCloud(0.1f, 1, 1.4f, cloudWaitDuration, thunderDuration-0.5f);

        StartFlood();
        yield return WaitTick(1);
        var floodStar = spawnStar(0.8f);
        yield return WaitTick(4);
        spawnBomb(0.8f, 0.05f, 2, 2.5f, 1);
        EndFlood();
        yield return WaitTick(2);
        ObjectPool.Despawn(star0, "star pool");

        var star4 = spawnStar(-0.55f);
        ObjectPool.Despawn(floodStar, "star pool");
        StartBoxWarning(3f, "left");
        yield return WaitTick(3);
        EndBoxWarning("left");

        var sweep2 = spawnSweep(-1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        Rigidbody2D rgb2 = sweep2.GetComponent<Rigidbody2D>();
        rgb2.velocity += new Vector2(orientation * 10f, 0);

        var movingCloud2 = spawnCloud(orientation * 0.7f, 1, 1, cloudWaitDuration-1, thunderDuration);
        Rigidbody2D mcRB2 = movingCloud2.AddComponent<Rigidbody2D>();
        mcRB2.velocity += new Vector2(-orientation * 1.5f, 0);
        mcRB2.gravityScale = 0;
        yield return WaitTick(2);

        ObjectPool.Despawn(star4, "star pool");

        spawnBomb(0f, 0.05f, 1.5f, 4, 1);
        spawnBomb(0.6f, 0.05f, 1.5f, 4, 1);

        //var cloudLeft1 = spawnCloud(-0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        //var cloudRight1 = spawnCloud(0.0f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var starMiddle = spawnStar(0);
        yield return WaitTick(4);

        spawnBomb(-0.6f, 0.05f, 3f, 3, 1);
        StartBoxWarning(3f, "right");
        yield return WaitTick(2);
        ObjectPool.Despawn(starMiddle, "star pool");
        yield return WaitTick(1);
        EndBoxWarning("right");

        sweep2 = spawnSweep(1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        rgb2 = sweep2.GetComponent<Rigidbody2D>();
        rgb2.velocity += new Vector2(-orientation * 8f, 0);

        var starNew1 = spawnStar(0.6f);
        var starMiddle2 = spawnStar(-0.8f);

        movingCloud = spawnCloud(orientation * 0.7f, 1, 1, cloudWaitDuration, thunderDuration);
        mcRB = movingCloud.AddComponent<Rigidbody2D>();
        mcRB.velocity += new Vector2(-orientation * 1f, 0);
        mcRB.gravityScale = 0;

        cloudRight2 = spawnCloud(0.3f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        yield return WaitTick(5);

        ObjectPool.Despawn(starNew1, "star pool");
        ObjectPool.Despawn(starMiddle2, "star pool");
        ObjectPool.Despawn(sweep2, "sweep pool");

        var starLeft = spawnStar(0.42f * orientation);

        spawnBomb(-0.4f * orientation, 0.05f, 2f, 2, 1);
        spawnBomb(-0.9f * orientation, 0.05f, 2f, 2, 1);
        spawnBomb(0.9f * orientation, 0.05f, 3.5f, 2, 1);
        yield return WaitTick(4);

        var starLeft1 = spawnStar(-0.5f * orientation);
        spawnBomb(0f, 0.05f, 3, 2, 1);
        yield return WaitTick(1);
        ObjectPool.Despawn(starLeft, "star pool");
        //yield return WaitTick(3);
        
        spawnBomb(-0.55f, 0.05f, 3, 2, 1);
        yield return WaitTick(3);

        ObjectPool.Despawn(starLeft1, "star pool");
        //spawnBomb(0.55f, 0.05f, 3, 2, 1);
        //yield return WaitTick(2);

        cloudLeft = spawnCloud(-0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        cloudRight = spawnCloud(0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var starLeft2 = spawnStar(-0.7f);
        var starRight = spawnStar(0.0f);
        var movingCloud3 = spawnCloud(orientation * 0.7f, 1, 1, cloudWaitDuration, thunderDuration);
        Rigidbody2D mcRB3 = movingCloud3.AddComponent<Rigidbody2D>();
        mcRB3.velocity += new Vector2(-orientation * 2f, 0);
        mcRB3.gravityScale = 0;

        yield return WaitTick(3);

        mcRB.velocity -= new Vector2(-orientation * 4f, 0);
        yield return WaitTick(2);

        
        ObjectPool.Despawn(starRight, "star pool");
        spawnBomb(-0.7f, 0.05f, 1.5f, 4, 1);
        spawnBomb(0f, 0.05f, 1.7f, 4, 1);
        spawnBomb(0.7f, 0.05f, 1.5f, 4, 1);
        yield return WaitTick(1);
        ObjectPool.Despawn(starLeft2, "star pool");
        //yield return WaitTick(3);
        StartFloodWarn();
        var randomStar = spawnStar(0.1f);
        yield return WaitTick(3);
        EndFloodWarn();

        StartFlood();
        yield return WaitTick(5);
        ObjectPool.Despawn(randomStar, "star pool");
        EndFlood();

        yield return WaitTick(1);

        /*spawnCloud(-0.4f, 1, 1, 2f, 2f);
        spawnCloud(0.6f, 1, 1, 2f, 2f);
        yield return WaitTick(4);

        spawnBomb(0.1f, 0.05f, 2f, 2, 1);
        var randomStar2 = spawnStar(-0.7f);
        yield return WaitTick(1);

        yield return WaitTick(4);

        ObjectPool.Despawn(randomStar2, "star pool");
        var starNew2 = spawnStar(-0.5f);
        var starNew3 = spawnStar(0.5f);
        yield return WaitTick(1);
        StartFlood();
        yield return WaitTick(4);

        EndFlood();
        ObjectPool.Despawn(starNew2, "star pool");
        ObjectPool.Despawn(starNew3, "star pool");
        yield return WaitTick(2);*/

        yield return base.LevelScript();
    }
}
