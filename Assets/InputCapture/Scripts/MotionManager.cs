using UnityEngine;

namespace Forgevision.InputCapture
{
    public class MotionManager : MonoBehaviour
    {
        [SerializeField]
        MotionRecorder _motionRecorder;
        [SerializeField]
        MotionPlayer _motionPlayer;

        MotionClip _motionClip = new MotionClip();
        public float _delayTimeSec = 1f;

        void Start()
        {
            _motionRecorder.StartRecord(_motionClip);
            _motionPlayer.MotionPlay(_motionClip, _delayTimeSec);
        }

    }
}
