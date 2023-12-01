# FrogsWinFormsApp

🎮 🐸 Игра «_Лягушки_», написанная в процессе изучения технологии **Windows Forms** и работы со звуками и изображениями.

<div align="center"><img src="https://github.com/snikitin-de/FrogsWinFormsApp/assets/25394427/844e0301-2d0e-4336-8ff4-2beb3c022e49"></div>

## Описание

### :question: Правила игры

Прыгать можно на листок, если он находится рядом или через 1 лягушку.

### :fireworks: Победа

Необходимо расположить лягушек, которые смотрят влево, в левую часть, а остальных - в правую часть за минимальное количество перепрыгиваний.

### 🎮 Геймплей

Пример геймплея игры:

<div align="center"><img src="https://github.com/snikitin-de/FrogsWinFormsApp/assets/25394427/4790f62f-d804-4f96-a435-3d08bec369a0"></div>

## Техническая часть

* Проект реализован на платформе **Windows Forms**.
* Для работы с изображениями используется компонент **PictureBox**.
* Для работы со звуками используется библиотека **NAudio**.

### Архитектура

Структура каталога решения:

![Структура каталога решения](https://github.com/snikitin-de/FrogsWinFormsApp/assets/25394427/19161940-ed8f-426c-bc4e-999334aefe6f)

### Работа со звуками

Для более удобной работы со звуками из ресурсов приложения и реализации бесконечного воспроизвидения звуков написана обёртка над библиотекой **NAudio** в виде класса **MediaPlayer**:

```csharp
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
```

Пример использования класса **MediaPlayer**:

```csharp
var mediaPlayer = new MediaPlayer(Properties.Resources.riverSunrise, true);
mediaPlayer.Play();
```
