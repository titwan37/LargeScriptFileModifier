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

namespace LargeScriptFileModifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties

        /// <summary>
        /// MyFolderPath
        /// </summary>
        public string MyFolderPath { get; set; } = Settings1.Default.FolderPath;

        //public string MyFolderPath { get; set; } = @"C:\temp\";
        //public string MyFolderPath { get; set; } = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Resource\TypeSupport\Unicode\Mappings\win\";

        /// <summary>
        /// MyFileOrg
        /// </summary>
        public string MyFileOrg { get; set; } = Settings1.Default.FileOrg;

        //public string MyFileOrg { get; set; } = @"MUP.xml";

        /// <summary>
        /// MyFileNew
        /// </summary>
        public string MyFileNew { get; set; } = Settings1.Default.FileNew;

        //public string MyFileNew { get; set; } = @"Rewrote.xml";

        /// <summary>
        /// StringOld
        /// </summary>
        public string StringOld { get; set; } = Settings1.Default.StringOld;

        //public string StringOld { get; set; } = @"deviceID";

        /// <summary>
        /// StringNew
        /// </summary>
        public string StringNew { get; set; } = Settings1.Default.StringNew;

        //public string StringNew { get; set; } = @"systemUHD";

        /// <summary>
        /// ModificationCount
        /// </summary>
        public int ModificationCount { get; set; }

        #endregion Properties

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_start_Click(object sender, RoutedEventArgs e)
        {
            //Task.Factory.StartNew();
            ModificationCount = LargeScriptFileIO.Modify(MyFolderPath,
                MyFileOrg, MyFileNew,
                StringOld, StringNew);
            TextBlock_ModifCount.Text = ModificationCount.ToString();
        }
    }
}