<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaRucv2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtConsultaRuc = New System.Windows.Forms.TextBox()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.txtResultado = New System.Windows.Forms.TextBox()
        Me.lblIntentos = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtConsultaRuc
        '
        Me.txtConsultaRuc.Location = New System.Drawing.Point(61, 30)
        Me.txtConsultaRuc.Name = "txtConsultaRuc"
        Me.txtConsultaRuc.Size = New System.Drawing.Size(144, 20)
        Me.txtConsultaRuc.TabIndex = 0
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(233, 30)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(75, 23)
        Me.btnConsulta.TabIndex = 1
        Me.btnConsulta.Text = "&Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtResultado
        '
        Me.txtResultado.Location = New System.Drawing.Point(61, 66)
        Me.txtResultado.Multiline = True
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResultado.Size = New System.Drawing.Size(580, 214)
        Me.txtResultado.TabIndex = 2
        '
        'lblIntentos
        '
        Me.lblIntentos.AutoSize = True
        Me.lblIntentos.Location = New System.Drawing.Point(58, 297)
        Me.lblIntentos.Name = "lblIntentos"
        Me.lblIntentos.Size = New System.Drawing.Size(81, 13)
        Me.lblIntentos.TabIndex = 3
        Me.lblIntentos.Text = "Total Intentos : "
        '
        'frmConsultaRucv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblIntentos)
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.txtConsultaRuc)
        Me.Name = "frmConsultaRucv2"
        Me.Text = "frmConsultaRucv2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtConsultaRuc As TextBox
    Friend WithEvents btnConsulta As Button
    Friend WithEvents txtResultado As TextBox
    Friend WithEvents lblIntentos As Label
End Class
