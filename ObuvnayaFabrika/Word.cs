using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace ObuvnayaFabrika
{
    internal class Word
    {
        private FileInfo _fileInfo;

        public Word(string filename)
        {
            if(File.Exists(filename)) 
            {
                _fileInfo = new FileInfo(filename);
            }
            else 
            {
                throw new ArgumentException("Файл не найден");            
            }
        }
        public void Process(Dictionary<string, string> items)
        {
            Microsoft.Office.Interop.Word.Application app = null;
            try
            {
                app = new Microsoft.Office.Interop.Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file, missing);
                foreach (var item in items)
                {
                    Microsoft.Office.Interop.Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;
                    Object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                    Object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                    find.Execute(wrap, replace);
                }
                Object newFileName = Path.Combine(_fileInfo.DirectoryName, DateTime.Now.ToString());
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                app.Quit();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                app.Quit();
            }
        }
    }
}
