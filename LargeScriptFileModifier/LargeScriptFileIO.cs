using System;
using System.IO;

namespace LargeScriptFileModifier
{
    public static class LargeScriptFileIO
    {
        internal static int Modify(string myFolder,
            string myFileOrg, string myFileRev,
            string oldString, string newString)
        {
            int cnt = 0;
            //Task tk;
            string filepathOrg = Path.Combine(myFolder, myFileOrg);
            string filepathRev = Path.Combine(myFolder, myFileRev);

            using (FileStream fs = File.Open(filepathOrg, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        //using (FileStream fw = File.Create(filepathRev, 4096, FileOptions.WriteThrough))
                        using (FileStream fw = new FileStream(filepathRev, FileMode.Create, FileAccess.ReadWrite))
                        {
                            using (StreamWriter sw = new StreamWriter(fw))
                            {
                                string lineOrg;
                                string lineRev;
                                while ((lineOrg = sr.ReadLine()) != null)
                                {
                                    if (lineOrg.Contains(oldString))
                                    {
                                        lineRev = lineOrg.Replace(oldString, newString,
                                            StringComparison.InvariantCultureIgnoreCase);

                                        cnt++;
                                    }
                                    else
                                    {
                                        lineRev = lineOrg;
                                    }

                                    sw.WriteLine(lineRev);
                                    //tk = await sw.WriteLineAsync(lineRev);
                                }
                            }
                        }
                    }
                }
            }
            System.Diagnostics.Debug.Write("Number of catches = " + cnt);
            //return tk;
            return cnt;
        }
    }
}