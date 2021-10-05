using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "Base.csv";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path)) 
            {
                sw.Write(TBName.Text+";");
                sw.Write(DPDr.SelectedDate.ToString() + ";");
                if (RBMen.IsChecked==true)
                {
                    sw.Write("Мужской" + ";");
                }
                if (RBWomen.IsChecked==true)
                {
                    sw.Write("Женский" + ";");
                }

            }
        }
    }
}
