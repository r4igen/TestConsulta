<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaRucv3
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblIntentos = New System.Windows.Forms.Label()
        Me.txtResultado = New System.Windows.Forms.TextBox()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.txtConsultaRuc = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblIntentos
        '
        Me.lblIntentos.AutoSize = True
        Me.lblIntentos.Location = New System.Drawing.Point(9, 272)
        Me.lblIntentos.Name = "lblIntentos"
        Me.lblIntentos.Size = New System.Drawing.Size(81, 13)
        Me.lblIntentos.TabIndex = 7
        Me.lblIntentos.Text = "Total Intentos : "
        '
        'txtResultado
        '
        Me.txtResultado.Location = New System.Drawing.Point(12, 41)
        Me.txtResultado.Multiline = True
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResultado.Size = New System.Drawing.Size(580, 214)
        Me.txtResultado.TabIndex = 6
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(341, 10)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(75, 23)
        Me.btnConsulta.TabIndex = 5
        Me.btnConsulta.Text = "&Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtConsultaRuc
        '
        Me.txtConsultaRuc.Location = New System.Drawing.Point(189, 11)
        Me.txtConsultaRuc.Name = "txtConsultaRuc"
        Me.txtConsultaRuc.Size = New System.Drawing.Size(144, 20)
        Me.txtConsultaRuc.TabIndex = 4
        '
        'frmConsultaRucV3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 294)
        Me.Controls.Add(Me.lblIntentos)
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.txtConsultaRuc)
        Me.Name = "frmConsultaRucV3"
        Me.Text = "frmConsultaRucV3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIntentos As Label
    Friend WithEvents txtResultado As TextBox
    Friend WithEvents btnConsulta As Button
    Friend WithEvents txtConsultaRuc As TextBox
End Class
