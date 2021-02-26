Imports System.Net
Imports System.Web
Public Class frmConsultaRucv3
    'Variables
    Dim Url As String = "https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaWeb.jsp"
    Private objCookie As CookieContainer
    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        Try
            ServicePointManager.ServerCertificateValidationCallback = New Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            Dim oWebRequest As HttpWebRequest = WebRequest.Create(Url)
            'oWebRequest.CookieContainer = objCookie
            'oWebRequest.Proxy = Nothing
            'oWebRequest.Credentials = CredentialCache.DefaultCredentials
            Dim myWebResponse As HttpWebResponse = DirectCast(oWebRequest.GetResponse(), HttpWebResponse)
            MsgBox("Paso")
        Catch ex As Exception

        End Try
        'https://e-consulta.sunat.gob.pe/cl-at-ittipcam/tcS01Alias
    End Sub

    Private Function ValidarCertificado(ByVal sender As Object _
                                      , ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate _
                                      , ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain _
                                      , ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Function CheckForInternetConnection() As Boolean
        Dim IsConnected As Boolean = False
        Try
            Using client As New WebClient()
                Using stream As IO.Stream = client.OpenRead("https://www.google.com")
                    IsConnected = True
                End Using
            End Using
        Catch ex As Exception
            IsConnected = False
        End Try
        Return IsConnected
    End Function

    Private Sub CargarPaginaSunat()
        If (CheckForInternetConnection()) Then

        End If
    End Sub

    Private Sub frmConsultaRucV3_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarPaginaSunat()
    End Sub
End Class