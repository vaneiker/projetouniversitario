using NAudio.Lame;
using NAudio.Wave;
using System;
using System.IO;
using System.Linq;

namespace WEB.ConfirmationCall.Common
{
    public class JMAudioTools
    {
        public static String ConvertToMp3(string origFileDir, string destFileDir, string fileName, bool waitFlag, String soxFilePath)
        {
            try
            {
                var origFile = origFileDir + fileName;
                var destFileWav = destFileDir + fileName.Replace(" ", "");
                var finalDestFile = destFileWav.Replace(".wav", ".mp3");

                if (File.Exists(finalDestFile))
                    return finalDestFile;

                StandarizeWavFile(origFile, destFileWav, true, soxFilePath);
                WavToMP3(destFileWav, finalDestFile);

                return finalDestFile;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void StandarizeWavFile(string origFileName, string destFileName, bool waitFlag, String soxFilePath)
        {
            string outfile = "\"" + origFileName + "\" -e signed-integer \"" + destFileName + "\"";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = soxFilePath;
            psi.Arguments = outfile;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            var p = System.Diagnostics.Process.Start(psi);

            if (waitFlag)
                p.WaitForExit();
        }

        public static void WavToMP3(string waveFileName, string mp3FileName, int bitRate = 128)
        {
            using (var reader = new WaveFileReader(waveFileName))
            using (var writer = new LameMP3FileWriter(mp3FileName, reader.WaveFormat, bitRate))
                reader.CopyTo(writer);
        }

        public static void CheckAddBinPath(string LameBinFolder)
        {
            // find path to 'bin' folder
            var binPath = Path.Combine(new string[] { AppDomain.CurrentDomain.BaseDirectory, LameBinFolder });
            // get current search path from environment
            var path = Environment.GetEnvironmentVariable("PATH") ?? "";

            // add 'bin' folder to search path if not already present
            if (!path.Split(Path.PathSeparator).Contains(binPath, StringComparer.CurrentCultureIgnoreCase))
            {
                path = string.Join(Path.PathSeparator.ToString(), new string[] { path, binPath });
                Environment.SetEnvironmentVariable("PATH", path);
            }
        }
    }
}