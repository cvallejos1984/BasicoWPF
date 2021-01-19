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
using System.Data;
using System.Windows.Media.Animation;
using System.Threading;

namespace Mercadeo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Control control = new Control();
       
       public MainWindow()
         
        {
            InitializeComponent();
        }
       

        private void btnsorteo_Click(object sender, RoutedEventArgs e)
        {
            using (Loading lw = new Loading(Simulador))
            {
                lw.Owner = this;
                lw.ShowDialog();
            }
            Search();
        }

        private void Search()
        {
            try
            {
                DataSet DS = new DataSet();
                DS = control.DevolverSQL();
                if (DS.Tables.Count != 0)
                {
                    tbcode.Text = "Code:  " + Convert.ToString(DS.Tables[0].Rows[0]["code"]);
                    tbname.Text = Convert.ToString(DS.Tables[0].Rows[0]["name"]);
                    tbbrand.Text = "Brand:  " + Convert.ToString(DS.Tables[0].Rows[0]["brand"]);
                    tbitem.Text = "Item:  " + Convert.ToString(DS.Tables[0].Rows[0]["item"]);
                    tbstore.Text = "Store:  " + Convert.ToString(DS.Tables[0].Rows[0]["store"]);
                    tbdate.Text = "Date:  " + Convert.ToString(DS.Tables[0].Rows[0]["date"]);
                }
                tbname.Visibility = Visibility.Visible;
                tbcode.Visibility = Visibility.Visible;
                tbbrand.Visibility = Visibility.Visible;
                tbitem.Visibility = Visibility.Visible;
                tbstore.Visibility = Visibility.Visible;
                tbdate.Visibility = Visibility.Visible;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            }
        private void Simulador()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(5);
            }
        }

        }
    }

