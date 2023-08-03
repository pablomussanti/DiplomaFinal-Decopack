<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enviover
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
        Me.cmbempleado = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.txtdirecion = New System.Windows.Forms.TextBox()
        Me.txtestado = New System.Windows.Forms.TextBox()
        Me.txtfechasalida = New System.Windows.Forms.TextBox()
        Me.cmbventa = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtfechallegada = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbempleado
        '
        Me.cmbempleado.FormattingEnabled = True
        Me.cmbempleado.Location = New System.Drawing.Point(24, 43)
        Me.cmbempleado.Name = "cmbempleado"
        Me.cmbempleado.Size = New System.Drawing.Size(108, 21)
        Me.cmbempleado.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(151, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(982, 225)
        Me.DataGridView1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 166)
        Me.Button1.TabIndex = 2
        Me.Button1.Tag = "145"
        Me.Button1.Text = "Ver lista asignada"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 244)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 133)
        Me.Button2.TabIndex = 3
        Me.Button2.Tag = "146"
        Me.Button2.Text = "Confirmar entrega"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Tag = "144"
        Me.Label1.Text = "Empleado"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(151, 248)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(1121, 129)
        Me.DataGridView2.TabIndex = 5
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(26, 27)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtcodigo.TabIndex = 6
        '
        'txtdirecion
        '
        Me.txtdirecion.Location = New System.Drawing.Point(26, 53)
        Me.txtdirecion.Name = "txtdirecion"
        Me.txtdirecion.Size = New System.Drawing.Size(100, 20)
        Me.txtdirecion.TabIndex = 7
        '
        'txtestado
        '
        Me.txtestado.Location = New System.Drawing.Point(26, 80)
        Me.txtestado.Name = "txtestado"
        Me.txtestado.Size = New System.Drawing.Size(100, 20)
        Me.txtestado.TabIndex = 8
        '
        'txtfechasalida
        '
        Me.txtfechasalida.Location = New System.Drawing.Point(26, 107)
        Me.txtfechasalida.Name = "txtfechasalida"
        Me.txtfechasalida.Size = New System.Drawing.Size(100, 20)
        Me.txtfechasalida.TabIndex = 9
        '
        'cmbventa
        '
        Me.cmbventa.FormattingEnabled = True
        Me.cmbventa.Location = New System.Drawing.Point(26, 133)
        Me.cmbventa.Name = "cmbventa"
        Me.cmbventa.Size = New System.Drawing.Size(100, 21)
        Me.cmbventa.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtfechallegada)
        Me.GroupBox1.Controls.Add(Me.cmbventa)
        Me.GroupBox1.Controls.Add(Me.txtfechasalida)
        Me.GroupBox1.Controls.Add(Me.txtestado)
        Me.GroupBox1.Controls.Add(Me.txtdirecion)
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(1139, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(133, 224)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "147"
        Me.GroupBox1.Text = "Envio seleccionado"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(26, 195)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 23)
        Me.Button3.TabIndex = 13
        Me.Button3.Tag = "148"
        Me.Button3.Text = "Limpiar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtfechallegada
        '
        Me.txtfechallegada.Location = New System.Drawing.Point(26, 160)
        Me.txtfechallegada.Name = "txtfechallegada"
        Me.txtfechallegada.Size = New System.Drawing.Size(100, 20)
        Me.txtfechallegada.TabIndex = 12
        '
        'Enviover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1276, 389)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmbempleado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Enviover"
        Me.Tag = "143"
        Me.Text = "Enviover"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbempleado As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents txtdirecion As TextBox
    Friend WithEvents txtestado As TextBox
    Friend WithEvents txtfechasalida As TextBox
    Friend WithEvents cmbventa As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtfechallegada As TextBox
    Friend WithEvents Button3 As Button
End Class
