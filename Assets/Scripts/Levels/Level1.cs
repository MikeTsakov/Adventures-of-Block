using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level {
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
        yield return WaitTick(3);
        EndBoxWarning("right");

        var sweep = spawnSweep(1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        Rigidbody2D rgb = sweep.GetComponent<Rigidbody2D>();
        rgb.gravityScale = 0;
        rgb.velocity += new Vector2(-orientation * 8f, 0);

        StartFloodWarn();
        yield return WaitTick(3);
        EndFloodWarn();

        ObjectPool.Despawn(sweep, "sweep pool");

        StartFlood();
        yield return WaitTick(3);
        EndFlood();
        yield return WaitTick(1);


        var starMiddle2 = spawnStar(-0.8f);
        yield return WaitTick(1);

        spawnBomb(-0.4f * orientation, 0.05f, 2f, 2, 1);
        spawnBomb(-0.9f * orientation, 0.05f, 2f, 2, 1);
        spawnBomb(0.9f * orientation, 0.05f, 3.5f, 2, 1);
        var starLeft = spawnStar(-0.75f * orientation);
        yield return WaitTick(3);

        ObjectPool.Despawn(starMiddle2, "star pool");
        ObjectPool.Despawn(starLeft, "star pool");

        var cloudLeft = spawnCloud(-0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
        var cloudRight = spawnCloud(0.8f, 1, 1.4f, cloudWaitDuration, thunderDuration);
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

        StartBoxWarning(3f, "left");
        yield return WaitTick(3);
        EndBoxWarning("left");

        sweep = spawnSweep(-1f, 0.08f, 1.4f, cloudWaitDuration, thunderDuration);
        rgb = sweep.GetComponent<Rigidbody2D>();
        rgb.gravityScale = 0;
        rgb.velocity += new Vector2(orientation * 10f, 0);

        yield return WaitTick(2);

        yield return base.LevelScript();
    }
}
