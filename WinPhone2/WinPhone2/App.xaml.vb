' 空のアプリケーション テンプレートについては、http://go.microsoft.com/fwlink/?LinkID=391641 を参照してください

''' <summary>
''' 既定の Application クラスに対してアプリケーション独自の動作を実装します。
''' </summary>
NotInheritable Class App
    Inherits Application

    Private _transitions As TransitionCollection

    ''' <summary>
    ''' 単一アプリケーション オブジェクトを初期化します。これは、実行される作成したコードの
    ''' 最初の行であり、main() または WinMain() と論理的に等価です。
    ''' </summary>
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' アプリケーションがエンド ユーザーによって正常に起動されたときに呼び出されます。他のエントリ ポイントは、
    ''' アプリケーションが特定のファイルを開くために起動されたときに
    ''' 検索結果やその他の情報を表示するために使用されます。
    ''' </summary>
    ''' <param name="e">起動の要求とプロセスの詳細を表示します。</param>
    Protected Overrides Sub OnLaunched(e As LaunchActivatedEventArgs)
#If DEBUG Then
        If System.Diagnostics.Debugger.IsAttached Then
            DebugSettings.EnableFrameRateCounter = True
        End If
#End If

        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        ' ウィンドウに既にコンテンツが表示されている場合は、アプリケーションの初期化を繰り返さずに、
        ' ウィンドウがアクティブであることだけを確認してください
        If rootFrame Is Nothing Then
            ' ナビゲーション コンテキストとして動作するフレームを作成し、最初のページに移動します
            rootFrame = New Frame()

            ' TODO: この値をアプリケーションに適切なキャッシュ サイズに変更します
            rootFrame.CacheSize = 1

            ' 既定の言語を設定します
            rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages(0)

            If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                ' TODO: 以前中断したアプリケーションから状態を読み込みます
            End If

            ' フレームを現在のウィンドウに配置します
            Window.Current.Content = rootFrame
        End If

        If rootFrame.Content Is Nothing Then
            ' スタートアップのターンスタイル ナビゲーションを削除します。
            If rootFrame.ContentTransitions IsNot Nothing Then
                _transitions = New TransitionCollection()
                For Each transition As Transition In rootFrame.ContentTransitions
                    _transitions.Add(transition)
                Next
            End If

            rootFrame.ContentTransitions = Nothing
            AddHandler rootFrame.Navigated, AddressOf RootFrame_FirstNavigated

            ' ナビゲーションの履歴スタックが復元されていない場合、最初のページに移動します。
            ' このとき、必要な情報をナビゲーション パラメーターとして渡して、新しいページを
            ' 作成します
            If Not rootFrame.Navigate(GetType(MainPage), e.Arguments) Then
                Throw New Exception("Failed to create initial page")
            End If
        End If

        ' 現在のウィンドウがアクティブであることを確認します
        Window.Current.Activate()
    End Sub

    ''' <summary>
    ''' アプリを起動した後のコンテンツの移行を復元します。
    ''' </summary>
    Private Sub RootFrame_FirstNavigated(sender As Object, e As NavigationEventArgs)
        Dim newTransitions As TransitionCollection
        If _transitions Is Nothing Then
            newTransitions = New TransitionCollection()
            newTransitions.Add(New NavigationThemeTransition())
        Else
            newTransitions = _transitions
        End If

        Dim rootFrame As Frame = DirectCast(sender, Frame)
        rootFrame.ContentTransitions = newTransitions
        RemoveHandler rootFrame.Navigated, AddressOf RootFrame_FirstNavigated
    End Sub

    ''' <summary>
    ''' アプリケーションの実行が中断されたときに呼び出されます。
    ''' アプリケーションが終了されるか、メモリの内容がそのままで再開されるかに
    ''' かかわらず、アプリケーションの状態が保存されます。
    ''' </summary>
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()

        ' TODO: アプリケーションの状態を保存してバックグラウンドの動作があれば停止します
        deferral.Complete()
    End Sub

End Class
