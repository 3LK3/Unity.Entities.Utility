using TMPro;
using UnityEngine;

namespace Elke.Entities.Utility
{
    public class FramesPerSecond : MonoBehaviour
    {
        public TMP_Text Text;
        public float UpdateInterval = 0.1f;

        private float m_TimeSinceLastUpdate = 0f;
        private int m_LastFrameIndex = 0;
        private float[] m_FrameDeltaTimes;

        private void Awake()
        {
            m_FrameDeltaTimes = new float[50];
        }

        private void Update()
        {
            m_FrameDeltaTimes[m_LastFrameIndex] = Time.unscaledDeltaTime;
            m_LastFrameIndex = (m_LastFrameIndex + 1) % m_FrameDeltaTimes.Length;

            if (m_TimeSinceLastUpdate < UpdateInterval)
            {
                m_TimeSinceLastUpdate += Time.unscaledDeltaTime;
                return;
            }

            var fps = CalculateFps();
            Text.SetText(Mathf.RoundToInt(fps).ToString());

            m_TimeSinceLastUpdate = 0f;
        }

        private float CalculateFps()
        {
            var total = 0f;
            foreach (var delta in m_FrameDeltaTimes)
            {
                total += delta;
            }
            return m_FrameDeltaTimes.Length / total;
        }
    }
}
