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
        string path = "Base.csv";  // путь у файлу
        List<People> ListPeople = new List<People>();
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(path))
            {
                BtnShow.IsEnabled = true;
            }
        }

        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            Im.Visibility = Visibility.Visible;
            SPShow.Visibility = Visibility.Collapsed;
            using (StreamWriter sw = new StreamWriter(path, true)) // запись в scv-файл
            {
                sw.Write(TBName.Text+";");    // запись в csv-файл из текстового поля
                sw.Write(DPDr.SelectedDate.ToString() + ";");   // запись в файл даты, выбранной в календаре
                // запись в файл пола, котрорый выбрал пользователь:
                if (RBMen.IsChecked==true)    
                {
                    sw.Write("Мужской" + ";");
                }
                if (RBWomen.IsChecked==true)
                {
                    sw.Write("Женский" + ";");
                }
                string character = "";
                if (CBСheerful.IsChecked==true)
                {
                    character += CBСheerful.Content+" ";
                }
                if (CBCharismatic.IsChecked==true)
                {
                    character += CBCharismatic.Content + " ";
                }
                if (CBStubborn.IsChecked==true)
                {
                    character += character + CBStubborn.Content + " ";
                }
                character = character.Substring(0, character.Length - 1);
                sw.Write(character + ";");
                ListBoxItem lb = (ListBoxItem)LBSp.SelectedItem;
                sw.Write(lb.Content+"\n");
                MessageBox.Show("Данные записаны");
                BtnShow.IsEnabled = true;
                TBName.Text = "";
            }
        }
        int i;
        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            Im.Visibility = Visibility.Collapsed;
            SPShow.Visibility = Visibility.Visible;
            using (StreamReader sr = new StreamReader(path))
            {
                while(sr.EndOfStream!=true)
                {
                    string[] Sarr = sr.ReadLine().Split(';');
                    ListPeople.Add(new People() 
                    { Name = Sarr[0], Dr = Sarr[1], Gender = Sarr[2], Character = Sarr[3], Sp = Sarr[4] });

                }
            }
            i = 0;
            TBShowName.Text = ListPeople[0].Name;
            TBShowDR.Text = ListPeople[0].Dr;
            TBShowGender.Text = ListPeople[0].Gender;
            TBShowCharacter.Text = ListPeople[0].Character;
            TBShowSp.Text = ListPeople[0].Sp;

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)  // следующая запись
        {
            try
            {
                i++;
                TBShowName.Text = ListPeople[i].Name;
                TBShowDR.Text = ListPeople[i].Dr;
                TBShowGender.Text = ListPeople[i].Gender;
                TBShowCharacter.Text = ListPeople[i].Character;
                TBShowSp.Text = ListPeople[i].Sp;
            }
            catch
            {
                MessageBox.Show("Это была последняя запись");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                i = ListPeople.Count-1;
                TBShowName.Text = ListPeople[i].Name;
                TBShowDR.Text = ListPeople[i].Dr;
                TBShowGender.Text = ListPeople[i].Gender;
                TBShowCharacter.Text = ListPeople[i].Character;
                TBShowSp.Text = ListPeople[i].Sp;
            }
            catch
            {
                MessageBox.Show("Это была последняя запись");
            }
        }
    }
}
