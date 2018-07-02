using UnityEngine;

namespace Forgevision.InputCapture
{
    public class MotionPlayer : MonoBehaviour
    {
        //モーション再生する対象
        [SerializeField]
        Transform _targetHead;
        [SerializeField]
        Transform _targetRight;
        [SerializeField]
        Transform _targetLeft;

        MotionClip _motionClip;
        float _startTime = 0f;
        float _delayTimeSec = 0f;
    
        enum PlayState
        {
            NONE,
            STOP,
            PLAYING
        }

        PlayState playState = PlayState.NONE;

        void Update()
        {
            MotionUpdate();
        }

        //motionClipからデータを取り出して、対象のPosition及びRotationを変化させる。
        void MotionUpdate()
        {
            switch (playState)
            {
                case PlayState.PLAYING:
                    break;
                default:
                    return;
            }

            float playTime = Time.time - _startTime - _delayTimeSec;
            
            if(playTime < 0f)
            {
                return;
            }

            if (_targetHead != null)
            {

                _targetHead.SetPositionAndRotation(
                      new Vector3(_motionClip.headCurve.pos_xCurve.Evaluate(playTime)
                    , _motionClip.headCurve.pos_yCurve.Evaluate(playTime)
                    , _motionClip.headCurve.pos_zCurve.Evaluate(playTime))
                    , new Quaternion(_motionClip.headCurve.rot_xCurve.Evaluate(playTime)
                    , _motionClip.headCurve.rot_yCurve.Evaluate(playTime)
                    , _motionClip.headCurve.rot_zCurve.Evaluate(playTime)
                    , _motionClip.headCurve.rot_wCurve.Evaluate(playTime)));
            }

            if (_targetRight != null)
            {

                _targetRight.SetPositionAndRotation(
                      new Vector3(_motionClip.rightCurve.pos_xCurve.Evaluate(playTime)
                    , _motionClip.rightCurve.pos_yCurve.Evaluate(playTime)
                    , _motionClip.rightCurve.pos_zCurve.Evaluate(playTime))
                    , new Quaternion(_motionClip.rightCurve.rot_xCurve.Evaluate(playTime)
                    , _motionClip.rightCurve.rot_yCurve.Evaluate(playTime)
                    , _motionClip.rightCurve.rot_zCurve.Evaluate(playTime)
                    , _motionClip.rightCurve.rot_wCurve.Evaluate(playTime)));
            }


            if (_targetLeft != null)
            {

                _targetLeft.SetPositionAndRotation(
                      new Vector3(_motionClip.leftCurve.pos_xCurve.Evaluate(playTime)
                    , _motionClip.leftCurve.pos_yCurve.Evaluate(playTime)
                    , _motionClip.leftCurve.pos_zCurve.Evaluate(playTime))
                    , new Quaternion(_motionClip.leftCurve.rot_xCurve.Evaluate(playTime)
                    , _motionClip.leftCurve.rot_yCurve.Evaluate(playTime)
                    , _motionClip.leftCurve.rot_zCurve.Evaluate(playTime)
                    , _motionClip.leftCurve.rot_wCurve.Evaluate(playTime)));
            }
        }

        //_delayTime_sec秒遅れて再生させる。
        public void MotionPlay(MotionClip motionClip, float delayTimeSec =1f)
        {           
            if (_targetHead == null && _targetRight == null && _targetLeft == null)
            {
                Debug.LogWarning("モーション再生対象が設定されていません。");
                return;
            }
            _startTime = Time.time;
            _motionClip = motionClip;
            _delayTimeSec = delayTimeSec;

            Debug.Log("モーション再生。遅延は" + string.Format("{0:#.#}", this._delayTimeSec)　 + "秒");
            playState = PlayState.PLAYING;
        }

        public void MotionStop()
        {
            if (playState != PlayState.PLAYING)
            {
                return;
            }
            Debug.Log("モーション停止。");
            playState = PlayState.STOP;
        }

    }
}
