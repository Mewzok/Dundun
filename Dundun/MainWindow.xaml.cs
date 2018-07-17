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
using System.IO;

namespace Dundun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow AppWindow;

        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            InitPlayer();
        }

        public static void InitPlayer()
        {
            String pathString = AppDomain.CurrentDomain.BaseDirectory;
            String pathString2 = System.IO.Path.GetFullPath(System.IO.Path.Combine(pathString, @"..\..\"));
            Sprites ethan = new Sprites(pathString2 + "Resources\\Sprites\\ethan.png");
            //+ "Resources\\Sprites\\ethan.png"
            ethan.SetSprites();

        }



    }
}
