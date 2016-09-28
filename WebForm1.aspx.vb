Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim strcode As String = "{""code"":0,""data"":{""match"":25.68,""buyPankou"":[{""price"":25.67,""volume"":67.0},{""price"":25.66,""volume"":50.0},{""price"":25.65,""volume"":914.0},{""price"":25.64,""volume"":67.0},{""price"":25.63,""volume"":476.0},{""price"":25.62,""volume"":160.0},{""price"":25.61,""volume"":310.0},{""price"":25.6,""volume"":706.0},{""price"":25.59,""volume"":253.0},{""price"":25.58,""volume"":630.0}],""sellPankou"":[{""price"":25.68,""volume"":529.0},{""price"":25.69,""volume"":102.0},{""price"":25.7,""volume"":164.0},{""price"":25.71,""volume"":31.0},{""price"":25.72,""volume"":96.0},{""price"":25.73,""volume"":65.0},{""price"":25.74,""volume"":268.0},{""price"":25.75,""volume"":3653.0},{""price"":25.76,""volume"":287.0},{""price"":25.77,""volume"":247.0}],""preClose"":27.0,""type"":1},""message"":"""",""success"":true}"""
    Dim strurl As String = "https://app.leverfun.com/timelyInfo/timelyOrderForm?stockCode=000002"

    Dim strcode1 As String = "{""code"":0,""data"":{""match"":9.05,""buyPankou"":[{""price"":9.04,""volume"":3404.0},{""price"":9.03,""volume"":13936.0},{""price"":9.02,""volume"":9519.0},{""price"":9.01,""volume"":10786.0},{""price"":9.0,""volume"":18672.0},{""price"":8.99,""volume"":2381.0},{""price"":8.98,""volume"":2861.0},{""price"":8.97,""volume"":1697.0},{""price"":8.96,""volume"":1294.0},{""price"":8.95,""volume"":1177.0}],""sellPankou"":[{""price"":9.05,""volume"":12199.0},{""price"":9.06,""volume"":21325.0},{""price"":9.07,""volume"":14934.0},{""price"":9.08,""volume"":14679.0},{""price"":9.09,""volume"":10177.0},{""price"":9.1,""volume"":7489.0},{""price"":9.11,""volume"":4838.0},{""price"":9.12,""volume"":3080.0},{""price"":9.13,""volume"":1429.0},{""price"":9.14,""volume"":2611.0}],""preClose"":9.0600004196167,""type"":1},""message"":"""",""success"":true}"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ReadJson2(strcode1)
        'timer1.Dispose()


    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'If TextBox1.Text.Length = 6 AndAlso IsNumeric(TextBox1.Text) Then
        '    hidcode.Value = TextBox1.Text

        '    If TextBox1.Text = "000001" Then
        '        ReadJson(strcode1)
        '    Else
        '        ReadJson(strcode)
        '    End If
        'End If
    End Sub

    'Protected Sub timer1_Tick(sender As Object, e As EventArgs) Handles timer1.Tick

    'End Sub

    Private Sub ReadJson(ByVal strJson As String)

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("price", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("volume", GetType(Decimal)))
        Dim re As Regex = New Regex("{""price"":([0-9\.]+),""volume"":([0-9\.]+)}")
        Dim rematch As New Regex("""match"":([0-9\.]+)")
        'Match
        lblmatch.Text = rematch.Match(strJson).Groups(1).Value

        For Each ma As Match In re.Matches(strJson)
            Dim row As DataRow = dt.NewRow
            row(0) = ma.Groups(1).Value
            row(1) = ma.Groups(2).Value
            dt.Rows.Add(row)
        Next
        dt.DefaultView.Sort = "price"
        GridView1.DataSource = dt.DefaultView.ToTable
        GridView1.DataBind()
    End Sub

    Private Sub ReadJson2(ByVal strJson As String)

        Dim re1 As New Regex("""buyPankou""\:\[([^]]+)\]")
        Dim buyPankou As String = re1.Match(strJson).Groups(1).Value

        Dim re2 As New Regex("""sellPankou""\:\[([^]]+)\]")
        Dim sellPankou As String = re2.Match(strJson).Groups(1).Value
        'Match
        Dim rematch As New Regex("""match"":([0-9\.]+)")
        lblmatch.Text = rematch.Match(strJson).Groups(1).Value

        Dim re As Regex = New Regex("{""price"":([0-9\.]+),""volume"":([0-9\.]+)}")

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("price", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("volume", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("price_sell", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("volume_sell", GetType(Decimal)))

        Dim dt1 As DataTable = dt.Clone
        Dim dt2 As DataTable = dt.Clone

        'buyPankou
        For Each ma As Match In re.Matches(buyPankou)
            Dim row As DataRow = dt1.NewRow
            row(0) = ma.Groups(1).Value
            row(1) = ma.Groups(2).Value
            dt1.Rows.Add(row)
        Next
        dt1.DefaultView.Sort = "price DESC"
        dt1 = dt1.DefaultView.ToTable
        'GridView1.DataSource = dt.DefaultView.ToTable
        'GridView1.DataBind()

        'sellPankou
        'dt.Clear()
        For Each ma As Match In re.Matches(sellPankou)
            Dim row As DataRow = dt2.NewRow
            row(2) = ma.Groups(1).Value
            row(3) = ma.Groups(2).Value
            dt2.Rows.Add(row)
        Next
        dt2.DefaultView.Sort = "price"
        dt2 = dt2.DefaultView.ToTable
        'GridView2.DataSource = dt.DefaultView.ToTable
        'GridView2.DataBind()

        For i As Integer = 0 To 9
            Dim row As DataRow = dt.NewRow
            row(0) = dt1.Rows(i)(0)
            row(1) = dt1.Rows(i)(1)
            row(2) = dt2.Rows(i)(2)
            row(3) = dt2.Rows(i)(3)
            dt.Rows.Add(row)
        Next
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length = 6 AndAlso IsNumeric(TextBox1.Text) Then
            hidcode.Value = TextBox1.Text

            If TextBox1.Text = "000001" Then
                ReadJson2(strcode1)
            Else
                ReadJson2(strcode)
            End If
        End If
    End Sub
End Class