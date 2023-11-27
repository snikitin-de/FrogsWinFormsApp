using NAudio.Wave;

namespace FrogsWinFormsApp
{
    public class MediaPlayer
    {
        private UnmanagedMemoryStream sound;
        private MemoryStream memoryStream;
        private WaveFileReader waveFileReader;
        private WaveOutEvent waveOutEvent;
        private bool isLooping;

        public MediaPlayer(UnmanagedMemoryStream sound, bool isLooping = false)
        {
            this.sound = sound;
            this.isLooping = isLooping;
        }

        public void Play()
        {
            memoryStream = new MemoryStream(StreamToBytes(sound));
            waveFileReader = new WaveFileReader(memoryStream);
            waveOutEvent = new WaveOutEvent();
            waveOutEvent.PlaybackStopped += new EventHandler<StoppedEventArgs>(MediaEnded);
            waveOutEvent.Init(waveFileReader);
            waveOutEvent.Play();
        }

        private void MediaEnded(object? sender, StoppedEventArgs e)
        {
            memoryStream.Dispose();
            waveFileReader.Close();
            waveFileReader.Dispose();
            waveOutEvent.Dispose();

            if (isLooping)
            {
                Play();
            }
        }

        private byte[] StreamToBytes(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
