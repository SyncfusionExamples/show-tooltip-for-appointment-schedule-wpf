namespace WPFSchedulerDemo
{
    using System.Windows;
    using Syncfusion.SfSkinManager;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Applying meterial3 light theme initially. 
            SfSkinManager.SetTheme(this, new Theme("Material3Light"));
        }
    }
}