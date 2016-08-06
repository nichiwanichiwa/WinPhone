' 空のアプリケーション テンプレートについては、http://go.microsoft.com/fwlink/?LinkID=391641 を参照してください

''' <summary>
''' それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    ''' <summary>
    ''' このページがフレームに表示されるときに呼び出されます。
    ''' </summary>
    ''' <param name="e">このページにどのように到達したかを説明するイベント データ。
    ''' このプロパティは、通常、ページを構成するために使用します。</param>
    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        ' TODO: ここに表示するページを準備します。

        ' TODO: アプリケーションに複数のページが含まれている場合は、次のイベントの
        ' 登録によりハードウェアの戻るボタンを処理していることを確認してください:
        ' Windows.Phone.UI.Input.HardwareButtons.BackPressed イベント。
        ' 一部のテンプレートで指定された NavigationHelper を使用している場合は、
        ' このイベントが自動的に処理されます。
    End Sub

End Class
