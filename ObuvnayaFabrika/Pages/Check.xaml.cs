using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObuvnayaFabrika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Page
    {
        public Check()
        {
            InitializeComponent();
            var zakaz = Helper.GetContext().Prodaji.Where(t => t.Zakaz == 1).ToList();
            tb_data.Text = zakaz[0].Data.ToString();
            tb_vremia.Text = zakaz[0].Vremia.ToString();
            tb_summa.Text = zakaz[0].Summa.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                IDocumentPaginatorSource idp = flowdoc;
                idp.DocumentPaginator.ComputePageCount();
                pd.PrintDocument(idp.DocumentPaginator, Title);
            }
        }
    }
}
