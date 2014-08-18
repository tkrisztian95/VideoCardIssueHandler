using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCardHandler
{
    public static class Common
    {

        //----------------------------File Műveletek--------------------------//
        public static bool createFile(string folderPath, string fileName, bool overwrite, string[] linesContent)
        {

            try
            {
                string fullFilePath = folderPath + @"\" + fileName;
                if (Directory.Exists(folderPath) == false)
                {
                    Directory.CreateDirectory(folderPath);
                }
                if (File.Exists(fullFilePath))
                {

                    if (overwrite)
                    {

                        File.Delete(fullFilePath);

                    }
                    else
                    {

                        return false;

                    }



                }

                using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                {
                    for (int i = 0; i < linesContent.Length; i++)
                    {

                        sw.WriteLine(linesContent[i]);


                    }


                }

                return true;
            }
            catch
            {


                return false;
            }




        }
    }
}
