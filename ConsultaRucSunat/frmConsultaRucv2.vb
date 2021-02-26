Imports System.Text.RegularExpressions
Imports System.Web

Public Class frmConsultaRucv2

    'Create a web browser
    Public oWb As New WebBrowser()
    Dim Contador As Integer = 0
    Public Event DocumentCompleted As WebBrowserDocumentCompletedEventHandler
    Dim url As String = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaWeb.jsp" '"https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias" '"https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias"
    Dim ContadorClicks As Integer = 0
    Dim Ruc10() As String
    Dim Ruc20() As String

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        Contador = 0
        txtResultado.Clear()
        oWb.Navigate(url)
        ContadorClicks += 1
        lblIntentos.Text = String.Format("Total Intentos : {0}", ContadorClicks.ToString())
        'oWb.Document.GetElementById("txtRuc").SetAttribute("value", txtConsultaRuc.Text)
        'oWb.Document.GetElementById("btnAceptar").InvokeMember("click")
    End Sub

    Private Sub frmConsultaRucv2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler oWb.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf validarcarga)
        Ruc10 = Split("Número de RUC:, Tipo Contribuyente:,Tipo de Documento:,Nombre Comercial:,Fecha de Inscripción:,Fecha de Inicio de Actividades:,Estado del Contribuyente:,Condición del Contribuyente:,Domicilio Fiscal:,Sistema Emisión de Comprobante:,Actividad Comercio Exterior:,Sistema Contabilidiad:,Actividad(es) Económica(s):,Comprobantes de Pago c/aut. de impresión (F. 806 u 816):,Sistema de Emisión Electrónica:,Emisor electrónico desde:,Comprobantes Electrónicos:,Afiliado al PLE desde:,Padrones:,Fecha consulta", ",")
        Ruc20 = Split("Número de RUC:, Tipo Contribuyente:,Nombre Comercial:,Fecha de Inscripción:,Fecha de Inicio de Actividades:,Estado del Contribuyente:,Condición del Contribuyente:,Domicilio Fiscal:,Sistema Emisión de Comprobante:,Actividad Comercio Exterior:,Sistema Contabilidiad:,Actividad(es) Económica(s):,Comprobantes de Pago c/aut. de impresión (F. 806 u 816):,Sistema de Emisión Electrónica:,Emisor electrónico desde:,Comprobantes Electrónicos:,Afiliado al PLE desde:,Padrones:,Fecha consulta", ",")
    End Sub

    Private Sub validarcarga(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        'Threading.Thread.Sleep(3000)
        Dim owbp As WebBrowser = CType(sender, WebBrowser)
        If (owbp.ReadyState = WebBrowserReadyState.Complete) Then
            Contador += 1
            If (Contador = 4) Then
                'MsgBox("Ya puede realizar la consulta")
            End If
            If (Contador = 4) Then
                owbp.Document.GetElementById("txtruc").SetAttribute("value", txtConsultaRuc.Text)
                owbp.Document.GetElementById("btnaceptar").InvokeMember("click")
            End If
            If (Contador = 5) Then
                If (owbp.ReadyState = WebBrowserReadyState.Complete) Then
                    For Each Etiqueta As HtmlElement In owbp.Document.GetElementsByTagName("div")
                        If Etiqueta.GetAttribute("className").Contains("row") Then
                            Dim cadena As String = Etiqueta.InnerText
                            If (String.IsNullOrEmpty(cadena) = False) Then
                                'cadena = cadena.Replace(Environment.NewLine, "")
                                'txtResultado.Text += (cadena)
                                'ParsearTexto(cadena)
                                If txtConsultaRuc.Text.Substring(0, 2) = "10" Then
                                    ParsearTexto(cadena, Ruc10)
                                Else
                                    ParsearTexto(cadena, Ruc20)
                                End If
                            Else
                                txtResultado.Text += ("No se pudieron recuperar los datos")
                            End If

                        End If
                    Next

                    For Each EtiquetaError As HtmlElement In owbp.Document.GetElementsByTagName("p")
                        If EtiquetaError.GetAttribute("className").Contains("error") Then
                            txtResultado.Text = (EtiquetaError.InnerText)
                        End If
                    Next

                    'Dim punto As New Point(500, 1000)
                    'Dim Contenedor As HtmlElement = owbp.Document.GetElementFromPoint(punto)
                    'Dim xDat As String = HttpUtility.HtmlDecode(owbp.DocumentText)
                    'Dim documento As HtmlDocument = oWb.Document
                    'Dim coleccion As HtmlElement = documento.All("list-group-item")
                    'Dim tabla As String()
                    'xDat = xDat.Replace("     ", " ")
                    'xDat = xDat.Replace("    ", " ")
                    'xDat = xDat.Replace("   ", " ")
                    'xDat = xDat.Replace("  ", " ")
                    'xDat = xDat.Replace("( ", "(")
                    'xDat = xDat.Replace(" )", ")")

                    'Lo convertimos a tabla o mejor dicho a un arreglo de string como se ve declarado arriba
                    'Dim filtro As String = "<div class=" & """list-group-item""" & ">" ''"<!-- Inicio filas de datos -->"
                    'tabla = Regex.Split(xDat, filtro)
                    'lbResultado.Items.Clear()
                    'Dim RucDescripcion As String = BuscarTag(xDat, txtConsultaRuc.Text, "</h4>", 14)
                    'lbResultado.Items.Add(String.Format("{0} {1}-{2}", "Número de RUC : ", txtConsultaRuc.Text, RucDescripcion)) 'txtResultado.Text = RucDescripcion 'Dim result As String = owbp.DocumentText
                    'Dim TipoContribuyente As String = BuscarTag(xDat, "Tipo Contribuyente:</h4>", "</p>", 10)
                    'lbResultado.Items.Add(String.Format("{0} {1}", "Tipo Contribuyente : ", TipoContribuyente))
                End If
            End If
        End If
    End Sub

    'Private Sub oNavegador_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles oWb.DocumentCompleted
    '    MsgBox("Listo")
    'End Sub
    'Private Function BuscarTag(ByVal Cadena As String, ByVal Principio As String, ByVal Final As String, PrimeraAcumulada As Integer) As String
    '    Dim posicion1, posicion2 As Integer

    '    posicion1 = InStr(Cadena, Principio)
    '    posicion2 = InStr(posicion1, Cadena, Final)
    '    posicion1 += PrimeraAcumulada
    '    Dim CadenaEncontrada As String = Mid(Cadena, posicion1, posicion2 - posicion1)

    '    Return CadenaEncontrada
    'End Function

    Private Function BuscarTag(Cadena As String, Principio As String, Fin As String)
        Dim Resultado As String = String.Empty
        Dim PosIni, PosFin As Integer
        PosIni = InStr(Cadena, Principio)
        PosFin = InStr(PosIni, Cadena, Fin)

        Dim Respuesta As String = Mid(Cadena, PosIni, PosFin - PosIni)
        If (Principio = "Comprobantes de Pago c/aut. de impresión (F. 806 u 816):" Or Principio = "Actividad(es) Económica(s):" Or Principio = "Sistema de Emisión Electrónica:" Or Principio = "Padrones:") Then
            Respuesta = Respuesta.Replace(Principio, "")
            For Each ItemCadena As String In Respuesta.Split(Environment.NewLine)
                ItemCadena = ItemCadena.Replace(Environment.NewLine, "")
                ItemCadena = ItemCadena.Replace(vbLf, "")
                If (String.IsNullOrEmpty(ItemCadena.Trim()) = False) Then
                    Resultado += String.Format("{0} {1}", Principio, ItemCadena) & Environment.NewLine 'String.Format("{0} {1}", Principio, Respuesta.Replace(Principio, "")) & Environment.NewLine
                End If
            Next

            'Respuesta = Respuesta.Replace(Principio, "")
            'Dim RespuestaTabla() = Respuesta.Split(Environment.NewLine)
        Else
            Respuesta = Respuesta.Replace(Environment.NewLine, "")
            Resultado = String.Format("{0} {1}", Principio, Respuesta.Replace(Principio, "")) & Environment.NewLine
        End If
        Return Resultado
    End Function

    Private Sub ParsearTexto(Texto As String)
        txtResultado.Text += BuscarTag(Texto, "Número de RUC:", "Tipo Contribuyente:")
        txtResultado.Text += BuscarTag(Texto, "Tipo Contribuyente:", "Tipo de Documento:")
        txtResultado.Text += BuscarTag(Texto, "Tipo de Documento:", "Nombre Comercial:")
        txtResultado.Text += BuscarTag(Texto, "Nombre Comercial:", "Fecha de Inscripción:")
        txtResultado.Text += BuscarTag(Texto, "Fecha de Inscripción:", "Fecha de Inicio de Actividades:")
        txtResultado.Text += BuscarTag(Texto, "Fecha de Inicio de Actividades:", "Estado del Contribuyente:")
        txtResultado.Text += BuscarTag(Texto, "Estado del Contribuyente:", "Condición del Contribuyente:")
        txtResultado.Text += BuscarTag(Texto, "Condición del Contribuyente:", "Domicilio Fiscal:")
        txtResultado.Text += BuscarTag(Texto, "Domicilio Fiscal:", "Sistema Emisión de Comprobante:")
        txtResultado.Text += BuscarTag(Texto, "Sistema Emisión de Comprobante:", "Actividad Comercio Exterior:")
        txtResultado.Text += BuscarTag(Texto, "Actividad Comercio Exterior:", "Sistema Contabilidiad:")
        txtResultado.Text += BuscarTag(Texto, "Sistema Contabilidiad:", "Actividad(es) Económica(s):")
        txtResultado.Text += BuscarTag(Texto, "Actividad(es) Económica(s):", "Comprobantes de Pago c/aut. de impresión (F. 806 u 816):")
        txtResultado.Text += BuscarTag(Texto, "Comprobantes de Pago c/aut. de impresión (F. 806 u 816):", "Sistema de Emisión Electrónica:")
        txtResultado.Text += BuscarTag(Texto, "Sistema de Emisión Electrónica:", "Emisor electrónico desde:")
        txtResultado.Text += BuscarTag(Texto, "Emisor electrónico desde:", "Comprobantes Electrónicos:")
        txtResultado.Text += BuscarTag(Texto, "Comprobantes Electrónicos:", "Afiliado al PLE desde:")
        txtResultado.Text += BuscarTag(Texto, "Afiliado al PLE desde:", "Padrones:")
        txtResultado.Text += BuscarTag(Texto, "Padrones:", "Fecha consulta")
    End Sub

    Private Sub ParsearTexto(Texto As String, oVector() As String)
        Dim TotalElementos As Integer = oVector.Length - 1
        For index = 0 To TotalElementos - 1
            txtResultado.Text += BuscarTag(Texto, oVector(index).Trim(), oVector(index + 1).Trim())
        Next
    End Sub



End Class