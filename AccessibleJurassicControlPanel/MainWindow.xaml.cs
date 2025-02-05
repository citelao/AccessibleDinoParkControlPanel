using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using AccessibleJurassicControlPanel.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AccessibleJurassicControlPanel
{
    public class NavigationItem
    {
        public string Label { get; set; } = "";
        public Symbol Symbol { get; set; } = Symbol.Home;
        public Type PageType { get; set; } = typeof(Page);
        public bool IsSelected { get; set; } = false;
    }

    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public List<NavigationItem> NavigationItems { get; set; } = new List<NavigationItem>
        {
            new NavigationItem { Label = "Home", Symbol = Symbol.Home, PageType = typeof(Home), IsSelected = true, },
            new NavigationItem { Label = "Chapter 1: Simple Name", Symbol = Symbol.Bullets, PageType = typeof(Ch1SimpleName) },
            new NavigationItem { Label = "Chapter 2: Advanced Info", Symbol = Symbol.Bullets, PageType = typeof(Ch2AdvancedInfo) },
            new NavigationItem { Label = "Chapter 3: Contexts", Symbol = Symbol.Bullets, PageType = typeof(Ch3Context) },
        };

        public MainWindow()
        {
            this.InitializeComponent();

            ContentFrame.Navigate(typeof(Home));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = args.SelectedItem as NavigationItem;
            if (selectedItem != null)
            {
                ContentFrame.Navigate(selectedItem.PageType);
            }
        }
    }
}
