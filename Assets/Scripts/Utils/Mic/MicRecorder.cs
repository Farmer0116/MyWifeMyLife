using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Utils.Mic
{
    public class MicRecorder
    {
        // 現在録音するマイクデバイス名
        string currentRecordingMicDeviceName = "";

        // ヘッダーサイズ
        int HeaderByteSize = 22;

        // BitsPerSample
        int BitsPerSample = 16;

        // AudioFormat
        int AudioFormat = 1;

        // 録音する AudioClip
        AudioClip recordedAudioClip;

        // サンプリング周波数
        int samplingFrequency = 16000;

        // Wav データ
        byte[] dataWav;

        public void Launch(string recordingTargetMicDeviceName)
        {
            // マイクデバイスがキャッチできたかどうか
            bool catchedMicDevice = false;

            // マイクデバイスを探す
            foreach (string device in Microphone.devices)
            {
                Debug.Log($"Mic device name : {device}");

                // PC 用のマイクデバイスを割り当て
                if (device == recordingTargetMicDeviceName)
                {
                    Debug.Log($"{recordingTargetMicDeviceName} searched");

                    currentRecordingMicDeviceName = device;

                    catchedMicDevice = true;
                }

            }

            if (catchedMicDevice)
            {
                Debug.Log($"currentRecordingMicDeviceName : {currentRecordingMicDeviceName}");
            }
            else
            {
                Debug.Log($"指定したマイクが見つかりませんでした");
            }
        }

        public void RecordStart(int maxTimeSeconds)
        {
            // マイクの録音を開始して AudioClip を割り当て
            recordedAudioClip = Microphone.Start(currentRecordingMicDeviceName, false, maxTimeSeconds, samplingFrequency);
        }

        public byte[] RecordStop()
        {
            // マイクの停止
            Microphone.End(currentRecordingMicDeviceName);

            // using を使ってメモリ開放を自動で行う
            using (MemoryStream currentMemoryStream = new MemoryStream())
            {
                // ChunkID RIFF
                byte[] bufRIFF = Encoding.ASCII.GetBytes("RIFF");
                currentMemoryStream.Write(bufRIFF, 0, bufRIFF.Length);

                // ChunkSize
                byte[] bufChunkSize = BitConverter.GetBytes((UInt32)(HeaderByteSize + recordedAudioClip.samples * recordedAudioClip.channels * BitsPerSample / 8));
                currentMemoryStream.Write(bufChunkSize, 0, bufChunkSize.Length);

                // Format WAVE
                byte[] bufFormatWAVE = Encoding.ASCII.GetBytes("WAVE");
                currentMemoryStream.Write(bufFormatWAVE, 0, bufFormatWAVE.Length);

                // Subchunk1ID fmt
                byte[] bufSubchunk1ID = Encoding.ASCII.GetBytes("fmt ");
                currentMemoryStream.Write(bufSubchunk1ID, 0, bufSubchunk1ID.Length);

                // Subchunk1Size (16 for PCM)
                byte[] bufSubchunk1Size = BitConverter.GetBytes((UInt32)16);
                currentMemoryStream.Write(bufSubchunk1Size, 0, bufSubchunk1Size.Length);

                // AudioFormat (PCM=1)
                byte[] bufAudioFormat = BitConverter.GetBytes((UInt16)AudioFormat);
                currentMemoryStream.Write(bufAudioFormat, 0, bufAudioFormat.Length);

                // NumChannels
                byte[] bufNumChannels = BitConverter.GetBytes((UInt16)recordedAudioClip.channels);
                currentMemoryStream.Write(bufNumChannels, 0, bufNumChannels.Length);

                // SampleRate
                byte[] bufSampleRate = BitConverter.GetBytes((UInt32)recordedAudioClip.frequency);
                currentMemoryStream.Write(bufSampleRate, 0, bufSampleRate.Length);

                // ByteRate (=SampleRate * NumChannels * BitsPerSample/8)
                byte[] bufByteRate = BitConverter.GetBytes((UInt32)(recordedAudioClip.samples * recordedAudioClip.channels * BitsPerSample / 8));
                currentMemoryStream.Write(bufByteRate, 0, bufByteRate.Length);

                // BlockAlign (=NumChannels * BitsPerSample/8)
                byte[] bufBlockAlign = BitConverter.GetBytes((UInt16)(recordedAudioClip.channels * BitsPerSample / 8));
                currentMemoryStream.Write(bufBlockAlign, 0, bufBlockAlign.Length);

                // BitsPerSample
                byte[] bufBitsPerSample = BitConverter.GetBytes((UInt16)BitsPerSample);
                currentMemoryStream.Write(bufBitsPerSample, 0, bufBitsPerSample.Length);

                // Subchunk2ID data
                byte[] bufSubchunk2ID = Encoding.ASCII.GetBytes("data");
                currentMemoryStream.Write(bufSubchunk2ID, 0, bufSubchunk2ID.Length);

                // Subchuk2Size
                byte[] bufSubchuk2Size = BitConverter.GetBytes((UInt32)(recordedAudioClip.samples * recordedAudioClip.channels * BitsPerSample / 8));
                currentMemoryStream.Write(bufSubchuk2Size, 0, bufSubchuk2Size.Length);

                // Data
                float[] floatData = new float[recordedAudioClip.samples * recordedAudioClip.channels];
                recordedAudioClip.GetData(floatData, 0);

                foreach (float f in floatData)
                {
                    byte[] bufData = BitConverter.GetBytes((short)(f * short.MaxValue));
                    currentMemoryStream.Write(bufData, 0, bufData.Length);
                }

                dataWav = currentMemoryStream.ToArray();

                // // 検証用にファイル保存
                // // Assets/record.wavに保存
                // string pathSaveWav = Path.Combine(Application.dataPath, "record.wav");
                // // using を使ってメモリ開放を自動で行う
                // using (FileStream currentFileStream = new FileStream(pathSaveWav, FileMode.Create))
                // {
                //     currentFileStream.Write(dataWav, 0, dataWav.Length);
                //     Debug.Log($"保存完了 path : {pathSaveWav}");
                // }

                return dataWav;
            }
        }
    }
}
