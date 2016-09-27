using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp3.Resources;
using Microsoft.Phone.Scheduler;
using System.Windows.Threading;
using System.Windows.Media;

namespace PhoneApp3
{
    class alarm
    {
        public void alarm_1()
        {
            // 既にalarmという名前のアラーム情報が存在しているかチェック
            if (ScheduledActionService.Find("alarm") != null)
            {
                // 既存のアラーム情報を削除する
                ScheduledActionService.Remove("alarm");
            }
            //now_times.Text = "aaa";
            var alarm = new Alarm("alarm");
            alarm.Content = "アラームの通知コンテンツ";
            // 「アラームを通知を開始する時間」を今から1分後に設定する
            alarm.BeginTime = DateTime.Now.AddMinutes(1);
            // 「アラームが期限切れになる時間」を今から2分後に設定する
            alarm.ExpirationTime = DateTime.Now.AddMinutes(2);
            // 通知を繰り返すか、繰り返しの間隔を設定
            alarm.RecurrenceType = RecurrenceInterval.Daily;
            // アラーム時の鳴動するサウンド
            //alarm.Sound = new Uri("/Ring01.wma", UriKind.Relative);

            ScheduledActionService.Add(alarm);
            // ApplicationBar をローカライズするためのサンプル コード
            //BuildLocalizedApplicationBar();
        }
    }
    public partial class MainPage : PhoneApplicationPage
    {
        // コンストラクター
        public MainPage()
        {
            InitializeComponent();
            
            //現在の時間を設定
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

           
        }
        void timer_Tick(object sender, EventArgs e)
        {
            now_times.Text = DateTime.Now.ToLongTimeString();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(2016, 9, 27, 22, 53, 30);
            now_time2.Text = now.ToString();
            set_time.Text = dt.ToString();

            switch (dt.CompareTo(now))
            {
                case -1:
                    //dt<now
                    now_time2.Foreground = new SolidColorBrush(Colors.Blue);
                    set_time.Foreground = new SolidColorBrush(Colors.Blue);
                    break;
                case 0:
                    //dt=now
                    alarm al = new alarm();
                    now_time2.Foreground = new SolidColorBrush(Colors.Red);
                    set_time.Foreground = new SolidColorBrush(Colors.Red);
                    al.alarm_1();
                    break;
                case 1:
                    //dt>now
                    now_time2.Foreground = new SolidColorBrush(Colors.Green);
                    set_time.Foreground = new SolidColorBrush(Colors.Green);
                    break;
            }

        }

        

        private void btnReminder_Click(object sender, RoutedEventArgs e)
        {

            // 既にreminderという名前のリマインダー情報が存在しているかチェック
            if (ScheduledActionService.Find("reminder") != null)
            {
                // 既存のリマインダー情報を削除する
                ScheduledActionService.Remove("reminder");
            }

            var reminder = new Reminder("reminder");
            reminder.Title = "ユーザーへのリマインダー通知タイトル";
            reminder.Content = "リマインダーの通知コンテンツ";
            // 「リマインダーを通知を開始する時間」を今から1分後に設定する
            reminder.BeginTime = DateTime.Now.AddMinutes(1);
            // 「リマインダーが期限切れになる時間」を今から2分後に設定する
            reminder.ExpirationTime = DateTime.Now.AddMinutes(2);
            // 通知を繰り返すか、繰り返しの間隔を設定
            reminder.RecurrenceType = RecurrenceInterval.Daily;
            //alarm.Sound = new Uri("/Ring01.wma", UriKind.Relative);
            // タップされた時に開くページのUriを設定
            reminder.NavigationUri
                = new Uri("/ReminderPage.xaml?title=" + reminder.Name, UriKind.Relative);

            ScheduledActionService.Add(reminder);
        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{

            // ScheduledActionServiceに登録されている
            // リマインダーやアラーム情報を一括で取得する
          //  var notifications = ScheduledActionService.GetActions<ScheduledNotification>();
          //  listBox1.ItemsSource = notifications;
        //}
        // ローカライズされた ApplicationBar を作成するためのサンプル コード
        //private void BuildLocalizedApplicationBar()
        //{
        //    // ページの ApplicationBar を ApplicationBar の新しいインスタンスに設定します。
        //    ApplicationBar = new ApplicationBar();

        //    // 新しいボタンを作成し、テキスト値を AppResources のローカライズされた文字列に設定します。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // AppResources のローカライズされた文字列で、新しいメニュー項目を作成します。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}