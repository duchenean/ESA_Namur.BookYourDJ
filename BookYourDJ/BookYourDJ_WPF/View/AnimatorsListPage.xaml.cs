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
using System.Data.Entity;
using BookYourDJ_WPF.Model;

namespace BookYourDJ_WPF.View
{
    /// <summary>
    /// Logique d'interaction pour AnimatorsListPage.xaml
    /// </summary>
    public partial class AnimatorsListPage : Page
    {
        public AnimatorsListPage()
        {
            InitializeComponent();
            BookYourDJEntities entities = new BookYourDJEntities();
            gridAnimators.ItemsSource = entities.Animators.ToList();
        }
    }
}
