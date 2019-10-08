using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SubtitlesEditor.Readers
{
    public static class ReaderFactory
    {
        public static ISubtitlesReader CreateReader(string path, ref Navigators.ISubtitlesNavigator navigator)
        {
            ISubtitlesReader reader;
            string line = "";
            try
            {
                if(!File.Exists(path))
                {
                    File.Create(path);
                }
                using (StreamReader sr = new StreamReader(File.OpenRead(path)))
                {
                    line = sr.ReadLine();
                }
                line.Trim();
                int i;
                if (line.StartsWith("{"))
                    reader = new MicroDVDReader(navigator);
                else
                    if (line.StartsWith("["))
                        reader = new Mpl2Reader(navigator);
                    else if (Int32.TryParse(line, out i))
                        reader = new SubRipReader(navigator);
                    else
                        reader = null;

            }
            catch (IOException)
            {
                reader = null;
            }
            catch (Exception)
            {
                reader = null;
            }
            return reader;
        }
    }
}
