using UnityEngine;

namespace Forgevision.InputCapture
{
    //Motion保存用のデータクラス
    public class MotionClip
    {

        //Position及びRotationのアニメーションカーブ
        public class PosRotCurve
        {
            public AnimationCurve pos_xCurve;
            public AnimationCurve pos_yCurve;
            public AnimationCurve pos_zCurve;
            public AnimationCurve rot_xCurve;
            public AnimationCurve rot_yCurve;
            public AnimationCurve rot_zCurve;
            public AnimationCurve rot_wCurve;

            public PosRotCurve()
            {
                pos_xCurve = new AnimationCurve();
                pos_yCurve = new AnimationCurve();
                pos_zCurve = new AnimationCurve();
                rot_xCurve = new AnimationCurve();
                rot_yCurve = new AnimationCurve();
                rot_zCurve = new AnimationCurve();
                rot_wCurve = new AnimationCurve();
            }

            public void AddKeyPostionAndRotation(float time,Vector3 position, Quaternion rotation)
            {
                pos_xCurve.AddKey(time, position.x);
                pos_yCurve.AddKey(time, position.y);
                pos_zCurve.AddKey(time, position.z);
                rot_xCurve.AddKey(time, rotation.x);
                rot_yCurve.AddKey(time, rotation.y);
                rot_zCurve.AddKey(time, rotation.z);
                rot_wCurve.AddKey(time, rotation.w);
            }
        }

        //頭、両手の3点の位置及び回転を保存する。(追加可能)
        public PosRotCurve headCurve  = new PosRotCurve();
        public PosRotCurve rightCurve = new PosRotCurve();
        public PosRotCurve leftCurve = new PosRotCurve();

    }
}
