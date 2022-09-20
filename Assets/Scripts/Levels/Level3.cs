using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level {
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

        var cloudLeft = spawnCloud(-0.5f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudRight = spawnCloud(0.5f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var starNew1 = spawnStar(0.7f);
        StartBoxWarning(3f, "right");
        yield return WaitTick(2);
        cloudRight = spawnCloud(0.75f, 1, 1.4f, cloudWaitDuration + 1, thunderDuration);
        yield return WaitTick(1);
        EndBoxWarning("right");

        var sweep = spawnSweep(1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        Rigidbody2D rgb = sweep.GetComponent<Rigidbody2D>();
        rgb.gravityScale = 0;
        rgb.velocity += new Vector2(-orientation * 10f, 0);

        spawnBomb(0f, 0.05f, 3, 4, 1);

        StartFloodWarn();
        yield return WaitTick(5);
        EndFloodWarn();
        ObjectPool.Despawn(starNew1, "star pool");
        var starNew2 = spawnStar(-0.2f);
        ObjectPool.Despawn(sweep, "sweep pool");

        StartFlood();
        yield return WaitTick(5);
        ObjectPool.Despawn(starNew2, "star pool");
        EndFlood();
        yield return WaitTick(1);

        StartBoxWarning(3f, "left");
        yield return WaitTick(2);
        starNew1 = spawnStar(0.7f);
        var starMiddle = spawnStar(0f, 1.0f);
        yield return WaitTick(1);
        EndBoxWarning("left");

        var sweep2 = spawnSweep(-1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        Rigidbody2D rgb2 = sweep2.GetComponent<Rigidbody2D>();
        rgb2.velocity += new Vector2(orientation * 10f, 0);

        spawnBomb(0f, 0.05f, 3, 4, 1);
        //starNew1 = spawnStar(0.7f);

        var cloudLeft1 = spawnCloud(-0.5f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudRight1 = spawnCloud(0.75f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        //starMiddle = spawnStar(0);
        yield return WaitTick(4);
        ObjectPool.Despawn(starMiddle, "star pool");
        ObjectPool.Despawn(starNew1, "star pool");
        var starMiddle2 = spawnStar(-0.8f);
        yield return WaitTick(2);
        spawnBomb(0f * orientation, 0.05f, 2f, 6, 1);
        yield return WaitTick(3);

        ObjectPool.Despawn(sweep2, "sweep pool");
        spawnBomb(-0.4f * orientation, 0.05f, 2f, 2, 1);
        spawnBomb(-0.9f * orientation, 0.05f, 2f, 2, 1);
        //spawnBomb(0.9f * orientation, 0.05f, 3.5f, 2, 1);
        var movingBomb = spawnBomb(0.9f * orientation, 0.05f, 3.5f, 2, 1);
        Rigidbody2D mbRB = movingBomb.AddComponent<Rigidbody2D>();
        mbRB.velocity += new Vector2(-orientation * 1.25f, 0);
        mbRB.gravityScale = 0;
        yield return WaitTick(3);

        ObjectPool.Despawn(starMiddle2, "star pool");

        cloudRight = spawnCloud(0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        yield return WaitTick(1);
        cloudRight = spawnCloud(0.6f, 1, 1.4f, cloudWaitDuration, thunderDuration - 1);
        cloudRight = spawnCloud(0.2f, 1, 1.4f, cloudWaitDuration, thunderDuration - 1);

        var starLeft = spawnStar(-0.75f * orientation);
        //ObjectPool.Despawn(starMiddle2, "star pool");
        yield return WaitTick(2);

        //spawnBomb(0f, 0.05f, 3, 2, 1);
        //spawnBomb(-0.55f, 0.05f, 3, 2, 1);
        //yield return WaitTick(5);

        //ObjectPool.Despawn(starLeft, "star pool");
        //spawnBomb(0.55f, 0.05f, 3, 2, 1);
        //yield return WaitTick(2);

        cloudLeft = spawnCloud(-0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        cloudRight = spawnCloud(0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var starLeft2 = spawnStar(-0.8f);
        var starRight = spawnStar(0.5f);
        var movingCloud = spawnCloud(orientation * 0.7f, 1, 1, cloudWaitDuration, thunderDuration + 0.5f);
        Rigidbody2D mcRB = movingCloud.AddComponent<Rigidbody2D>();
        mcRB.velocity += new Vector2(-orientation * 2f, 0);
        mcRB.gravityScale = 0;
        yield return WaitTick(4);

        ObjectPool.Despawn(starLeft, "star pool");

        mcRB.velocity -= new Vector2(-orientation * 3f, 0);
        yield return WaitTick(2);
        ObjectPool.Despawn(starLeft2, "star pool");
        ObjectPool.Despawn(starRight, "star pool");
        yield return WaitTick(1);
        ObjectPool.Despawn(movingCloud, "cloud pool");
        spawnBomb(-0.7f, 0.05f, 1.5f, 4, 1);
        spawnBomb(0f, 0.05f, 1.7f, 4, 1);
        spawnBomb(0.7f, 0.05f, 1.5f, 4, 1);
        yield return WaitTick(2);

        StartFloodWarn();
        var randomStar = spawnStar(0.1f);
        yield return WaitTick(3);
        EndFloodWarn();
        StartFlood();
        yield return WaitTick(5);
        ObjectPool.Despawn(randomStar, "star pool");
        EndFlood();
        yield return WaitTick(1);

        var lastCloud = spawnCloud(0.0f, 1, 1, 2f, 2f);
        movingCloud = spawnCloud(orientation * 0.0f, 1, 1, cloudWaitDuration, thunderDuration);
        mcRB = movingCloud.AddComponent<Rigidbody2D>();
        mcRB.velocity += new Vector2(-orientation * 2f, 0);
        mcRB.gravityScale = 0;
        var movingCloud1 = spawnCloud(orientation * 0.0f, 1, 1, cloudWaitDuration, thunderDuration);
        Rigidbody2D mcRB1 = movingCloud1.AddComponent<Rigidbody2D>();
        mcRB1.velocity -= new Vector2(-orientation * 2f, 0);
        mcRB1.gravityScale = 0;
        yield return WaitTick(3);
        
        mcRB.velocity -= new Vector2(-orientation * 3f, 0);
        mcRB1.velocity += new Vector2(-orientation * 3f, 0);

        spawnBomb(0.1f, 0.05f, 2f, 2, 1);
        var randomStar2 = spawnStar(-0.7f);
        yield return WaitTick(3);
        
        ObjectPool.Despawn(movingCloud, "cloud pool");
        ObjectPool.Despawn(movingCloud1, "cloud pool");

        ObjectPool.Despawn(randomStar2, "star pool");
        starNew2 = spawnStar(-0.5f);
        var starNew3 = spawnStar(0.35f);
        yield return WaitTick(2);
        StartFlood();
        yield return WaitTick(2);
        ObjectPool.Despawn(lastCloud, "cloud pool");
        yield return WaitTick(2);

        EndFlood();
        ObjectPool.Despawn(starNew2, "star pool");
        ObjectPool.Despawn(starNew3, "star pool");
        yield return WaitTick(2);

        yield return base.LevelScript();
    }
}
