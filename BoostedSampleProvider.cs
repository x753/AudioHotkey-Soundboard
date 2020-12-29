using System;
using NAudio.Wave;

namespace AudioHotkeySoundboard
{
    public class BoostedSampleProvider : ISampleProvider
    {
        private ISampleProvider source;
        public float boost = 0f;
        public float SampleRate { get; set; }

        public BoostedSampleProvider(ISampleProvider source)
        {
            this.source = source;
            SampleRate = source.WaveFormat.SampleRate;
        }

        public int Read(float[] samples, int offset, int count)
        {
            var samplesAvailable = source.Read(samples, offset, count);
            if (WaveFormat.Channels == 1)
            {
                for (int n = 0; n < samplesAvailable; n++)
                {
                    float right = 0.0f;
                    BoostedSample(boost, ref samples[n], ref right);
                }
            }
            else if (WaveFormat.Channels == 2)
            {
                for (int n = 0; n < samplesAvailable; n += 2)
                {
                    BoostedSample(boost, ref samples[n], ref samples[n + 1]);
                }
            }
            return samplesAvailable;
        }

        public void BoostedSample(float boost, ref float spl0, ref float spl1)
        {
            var dB0 = 8.6562f * log(abs(spl0)) + boost;
            var dB1 = 8.6562f * log(abs(spl1)) + boost;

            if (dB0 > -9.1f)
            {
                dB0 += 9.1f;
                dB0 = 1.017f * dB0 + -0.025f * dB0 * dB0;
                dB0 = min(-9.1f + dB0, -0.1f);
            }

            if (dB1 > -9.1f)
            {
                dB1 += 9.1f;
                dB1 = 1.017f * dB1 + -0.025f * dB1 * dB1;
                dB1 = min(-9.1f + dB1, -0.1f);
            }

            spl0 = exp(dB0 / 8.6562f) * sign(spl0);
            spl1 = exp(dB1 / 8.6562f) * sign(spl1);
        }

        public WaveFormat WaveFormat { get { return source.WaveFormat; } }
        public string Name { get; }
        // helper base methods these are primarily to enable derived classes to use a similar
        // syntax to REAPER's JS effects
        protected const float log2db = 8.6858896380650365530225783783321f; // 20 / ln(10)
        protected const float db2log = 0.11512925464970228420089957273422f; // ln(10) / 20 
        protected static float min(float a, float b) { return Math.Min(a, b); }
        protected static float max(float a, float b) { return Math.Max(a, b); }
        protected static float abs(float a) { return Math.Abs(a); }
        protected static float exp(float a) { return (float)Math.Exp(a); }
        protected static float sqrt(float a) { return (float)Math.Sqrt(a); }
        protected static float sin(float a) { return (float)Math.Sin(a); }
        protected static float tan(float a) { return (float)Math.Tan(a); }
        protected static float cos(float a) { return (float)Math.Cos(a); }
        protected static float pow(float a, float b) { return (float)Math.Pow(a, b); }
        protected static float sign(float a) { return Math.Sign(a); }
        protected static float log(float a) { return (float)Math.Log(a); }
        protected static float PI { get { return (float)Math.PI; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
