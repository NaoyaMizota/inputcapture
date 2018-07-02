using UnityEngine;

namespace Forgevision.InputCapture
{
    public class MotionRecorder : MonoBehaviour
    {
        //録画するオブジェクトの対象
        [SerializeField]
        Transform _recordHead; 
        [SerializeField]
        Transform _recordRight;
        [SerializeField]
        Transform _recordLeft;

        MotionClip _motionClip;
        float _startTime;
        float _timer = 0f;

        //モーションの1秒あたりのキー数
        readonly int _recordFPS = 30;

        enum RecordState
        {
            NONE,
            RECORDING,
            STOP
        }

        RecordState recordState = RecordState.NONE;

        void Update()
        {
            CaptureUpdate();
        }

        void CaptureUpdate()
        {
            switch (recordState)
            {
                case RecordState.RECORDING:
                    break;
                case RecordState.STOP:
                    Debug.Log("録画終了。");
                    recordState = RecordState.NONE;
                    return;
                default:
                    return;
            }

            //１秒間に recordFPS 回数分だけキャプチャする。
            if (_timer > (1f / (float)_recordFPS))
            {
                _timer -= (1f / _recordFPS);
                float playTime = Time.time - _startTime;

                if (_recordHead != null)
                {
                    _motionClip.headCurve.AddKeyPostionAndRotation(playTime, _recordHead.position, _recordHead.rotation);
                }
                if (_recordRight != null)
                {
                    _motionClip.rightCurve.AddKeyPostionAndRotation(playTime, _recordRight.position, _recordRight.rotation);
                }
                if (_recordLeft != null)
                {
                    _motionClip.leftCurve.AddKeyPostionAndRotation(playTime, _recordLeft.position, _recordLeft.rotation);
                }
            }

            _timer += Time.deltaTime;

        }

        public void StartRecord(MotionClip motionClip)
        {
            this._motionClip = motionClip;
            recordState = RecordState.RECORDING;
            _startTime = Time.time;
            _timer = 0f;
            Debug.Log("録画開始。");
        }

        public void StopRecord()
        {
            recordState = RecordState.STOP;
        }

    }
}
