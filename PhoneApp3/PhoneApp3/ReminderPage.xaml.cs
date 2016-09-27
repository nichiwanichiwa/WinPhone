using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;

namespace PhoneApp3
{
    public partial class ReminderPage : PhoneApplicationPage
    {
        public ReminderPage()
        {
            InitializeComponent();
          
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // クエリ文字列にtitleが含まれていれば、
            // ページのタイトルとして表示する
            string title = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("title", out title))
            {
                PageTitle.Text = title;
            }
        }
    }
}