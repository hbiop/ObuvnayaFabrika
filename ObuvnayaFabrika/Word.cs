using Microsoft.Office.Interop.Word;
using ObuvnayaFabrika.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Word = Microsoft.Office.Interop.Word;

namespace ObuvnayaFabrika
{
    public static class Word
    {
        public static void Excel(List<Sotrudniki> sotr)
        {
            Microsoft.Office.Interop.Excel.Application application = null;
            Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Sheets worksheets = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            //переменная для хранения диапазона ячеек
            //в нашем случае - это будет одна ячейка
            Microsoft.Office.Interop.Excel.Range cell = null;
            try
            {
                application = new Microsoft.Office.Interop.Excel.Application
                {
                    Visible = true
                };
                workbooks = application.Workbooks;
                workbook = workbooks.Add();
                worksheets = workbook.Worksheets; //получаем доступ к коллекции рабочих листов
                worksheet = worksheets.Item[1];//получаем доступ к первому листу
                for(int i = 1; i < sotr.Count; i++)
                {
                    cell = worksheet.Cells[i, 1];
                    cell.Value = sotr[i].Imia;
                    cell = worksheet.Cells[i, 2];
                    cell.Value = sotr[i].Familia;
                    cell = worksheet.Cells[i, 3];
                    cell.Value = sotr[i].Otchestvo;
                    cell = worksheet.Cells[i, 4];
                    cell.Value = sotr[i].Pochta;
                    cell = worksheet.Cells[i, 5];
                    cell.Value = sotr[i].NomerTelefona;
                }
               
                application.Quit();
            }
            finally
            {
                //освобождаем память, занятую объектами
                Marshal.ReleaseComObject(cell);
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(worksheets);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(workbooks);
                Marshal.ReleaseComObject(application);
            }
        }
        public static void Process(Dictionary<string, string> items)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            Document wordDoc;
            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();

                object missing = Type.Missing;
                object fileName = "C:\\college\\разработка программных модулей\\docs\\blank-trudovogo-dogovora_with_tags.docx"; //Путь к шаблону документа

                wordDoc = wordApp.Documents.Open(ref fileName, ref missing, ref missing, ref missing); //открываем шаблон документа

                foreach (var item in items) // Перебор всех тегов и значений словаря, с последующей
                                            // заменой каждого тега на соответствующее для него значение
                {
                    Find find = wordApp.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    object wrap = WdFindWrap.wdFindContinue;
                    object replace = WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true,
                        Wrap: wrap, Format: false, ReplaceWith: missing, Replace: replace);
                }


                // путь по которому будет сохранен файла и имя файла - сохранять на рабочий стол текущего пользователя (или выбор места сохранения через диалоговое окно)
                //
                object newFile = "C:\\college\\разработка программных модулей\\docs\\test6.docx";
                wordDoc.SaveAs2(newFile); //сохранить заполненный данными шаблон как новый документ
                wordApp.ActiveDocument.Close(); //закрытие активного документа
                wordApp?.Quit(); //отключение от приложения для работы с документами типа Word
            }
            catch (Exception ex)
            {
                wordApp?.ActiveDocument.Close(); //закрытие активного документа
                wordApp?.Quit();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
