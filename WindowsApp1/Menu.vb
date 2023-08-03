Imports BLL
Imports EE
Imports Servicios
Public Class Menu
    Implements Iidiomaobserver

    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim contador As Integer
    Dim bllpermiso As New BLLpermiso

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)

        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)

        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)

        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)

        bllpalabra.verificacionpalabras(DevolucionToolStripMenuItem.Tag, DevolucionToolStripMenuItem.Text)
        DevolucionToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, DevolucionToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(UsuarioToolStripMenuItem.Tag, UsuarioToolStripMenuItem.Text)
        UsuarioToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, UsuarioToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(ProductoToolStripMenuItem.Tag, ProductoToolStripMenuItem.Text)
        ProductoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ProductoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(CerrarSesionToolStripMenuItem.Tag, CerrarSesionToolStripMenuItem.Text)
        CerrarSesionToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, CerrarSesionToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(BitacoraToolStripMenuItem.Tag, BitacoraToolStripMenuItem.Text)
        BitacoraToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, BitacoraToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(BackupToolStripMenuItem.Tag, BackupToolStripMenuItem.Text)
        BackupToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, BackupToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(RestoreToolStripMenuItem.Tag, RestoreToolStripMenuItem.Text)
        RestoreToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, RestoreToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(IdiomaToolStripMenuItem.Tag, IdiomaToolStripMenuItem.Text)
        IdiomaToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, IdiomaToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(PermisoToolStripMenuItem.Tag, PermisoToolStripMenuItem.Text)
        PermisoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, PermisoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(CompradorToolStripMenuItem.Tag, CompradorToolStripMenuItem.Text)
        CompradorToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, CompradorToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SucursalToolStripMenuItem.Tag, SucursalToolStripMenuItem.Text)
        SucursalToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, SucursalToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(DepositoToolStripMenuItem.Tag, DepositoToolStripMenuItem.Text)
        DepositoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, DepositoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(ReclamoToolStripMenuItem.Tag, ReclamoToolStripMenuItem.Text)
        ReclamoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ReclamoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(ProveedorToolStripMenuItem.Tag, ProveedorToolStripMenuItem.Text)
        ProveedorToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ProveedorToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SucursalToolStripMenuItem1.Tag, SucursalToolStripMenuItem1.Text)
        SucursalToolStripMenuItem1.Text = blltraduccion.Traduccion(idioma, SucursalToolStripMenuItem1.Tag)

        bllpalabra.verificacionpalabras(DepositoToolStripMenuItem1.Tag, DepositoToolStripMenuItem1.Text)
        DepositoToolStripMenuItem1.Text = blltraduccion.Traduccion(idioma, DepositoToolStripMenuItem1.Tag)

        bllpalabra.verificacionpalabras(DepositoToolStripMenuItem2.Tag, DepositoToolStripMenuItem2.Text)
        DepositoToolStripMenuItem2.Text = blltraduccion.Traduccion(idioma, DepositoToolStripMenuItem2.Tag)

        bllpalabra.verificacionpalabras(ReposicionToolStripMenuItem.Tag, ReposicionToolStripMenuItem.Text)
        ReposicionToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ReposicionToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(ResumenToolStripMenuItem.Tag, ResumenToolStripMenuItem.Text)
        ResumenToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ResumenToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SucursalToolStripMenuItem2.Tag, SucursalToolStripMenuItem2.Text)
        SucursalToolStripMenuItem2.Text = blltraduccion.Traduccion(idioma, SucursalToolStripMenuItem2.Tag)

        bllpalabra.verificacionpalabras(RenovacionDepositoToolStripMenuItem.Tag, RenovacionDepositoToolStripMenuItem.Text)
        RenovacionDepositoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, RenovacionDepositoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(DetalleVentaToolStripMenuItem.Tag, DetalleVentaToolStripMenuItem.Text)
        DetalleVentaToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, DetalleVentaToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(GenerarToolStripMenuItem.Tag, GenerarToolStripMenuItem.Text)
        GenerarToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, GenerarToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(AsignarToolStripMenuItem.Tag, AsignarToolStripMenuItem.Text)
        AsignarToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, AsignarToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(VerToolStripMenuItem.Tag, VerToolStripMenuItem.Text)
        VerToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, VerToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(AdministrarToolStripMenuItem.Tag, AdministrarToolStripMenuItem.Text)
        AdministrarToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, AdministrarToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SeguridadToolStripMenuItem.Tag, SeguridadToolStripMenuItem.Text)
        SeguridadToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, SeguridadToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(StockToolStripMenuItem.Tag, StockToolStripMenuItem.Text)
        StockToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, StockToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(VENTAToolStripMenuItem.Tag, VENTAToolStripMenuItem.Text)
        VENTAToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, VENTAToolStripMenuItem.Tag)


        bllpalabra.verificacionpalabras(EnvioToolStripMenuItem.Tag, EnvioToolStripMenuItem.Text)
        EnvioToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, EnvioToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(EmpleadoToolStripMenuItem.Tag, EmpleadoToolStripMenuItem.Text)
        EmpleadoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, EmpleadoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

    End Sub

    Private Sub ProductoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuarioToolStripMenuItem.Click
        Dim n As New Usuario
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub ProductoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProductoToolStripMenuItem.Click
        Dim n As New Producto
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Servicios.SesionManager._instancia = Nothing
        'Login.rolusuario = New Servicios.Rol
        Dim n As New Login
        n.Show()
        Me.Close()

    End Sub

    Private Sub BitacoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitacoraToolStripMenuItem.Click
        Dim n As New Bitacora
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        Dim n As New Backup
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        Dim n As New Restore
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub IdiomaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IdiomaToolStripMenuItem.Click
        Dim n As New Idioma
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub PermisoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermisoToolStripMenuItem.Click
        Dim n As New Permisos
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub CompradorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompradorToolStripMenuItem.Click
        Dim n As New Comprador
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucursalToolStripMenuItem.Click
        Dim n As New Sucursal
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub DepositoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepositoToolStripMenuItem.Click
        Dim n As New Deposito
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub ReclamoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReclamoToolStripMenuItem.Click
        Dim n As New Reclamo
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub ProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedorToolStripMenuItem.Click
        Dim n As New Proveedor
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub SucursalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SucursalToolStripMenuItem1.Click
        Dim n As New Stocksucursal
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub DepositoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DepositoToolStripMenuItem1.Click
        Dim n As New Stockdeposito
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub DepositoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DepositoToolStripMenuItem2.Click
        Dim n As New Empleadodeposito
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub SucursalToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SucursalToolStripMenuItem2.Click
        Dim n As New Empleadosucursal
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub ReposicionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReposicionToolStripMenuItem.Click
        Dim n As New Reposicion
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub RenovacionDepositoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenovacionDepositoToolStripMenuItem.Click
        Dim n As New Renovaciondeposito
        n.MdiParent = Me
        n.Show()
    End Sub


    Private Sub DetalleVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleVentaToolStripMenuItem.Click
        Dim n As New Detalleventa
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub GenerarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarToolStripMenuItem.Click
        Dim n As New Venta
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub AsignarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarToolStripMenuItem.Click
        Dim n As New Envioasignar
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub VerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerToolStripMenuItem.Click
        Dim n As New Enviover
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub DevolucionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionToolStripMenuItem.Click
        Dim n As New Devolucion
        n.MdiParent = Me
        n.Show()
    End Sub


    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usuarion As New Servicios.Usuario
        usuarion = Servicios.SesionManager.obtenerinstancia
        Label3.Text = usuarion.user
        Label7.Text = DateTime.Now
        contador = 0
        Label5.Text = contador
        Timersesion.Enabled = True
        Timersesion.Interval = 1000
        Label8.Text = DateTime.Now
        Singletonidioma._instancia.Agregar(Me)
        'ListBox1.DataSource = Nothing

        'ListBox1.DataSource = Login.rolusuario.Mostrar

        Dim verificador As Boolean

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Usuario")
        If verificador = True Then
            UsuarioToolStripMenuItem.Enabled = True
        Else
            UsuarioToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Idioma")
        If verificador = True Then
            IdiomaToolStripMenuItem.Enabled = True
        Else
            IdiomaToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Permiso")
        If verificador = True Then
            PermisoToolStripMenuItem.Enabled = True
        Else
            PermisoToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Producto")
        If verificador = True Then
            ProductoToolStripMenuItem.Enabled = True
        Else
            ProductoToolStripMenuItem.Enabled = False
        End If


        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Comprador")
        If verificador = True Then
            CompradorToolStripMenuItem.Enabled = True
        Else
            CompradorToolStripMenuItem.Enabled = False
        End If


        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Sucursal")
        If verificador = True Then
            SucursalToolStripMenuItem.Enabled = True
        Else
            SucursalToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Deposito")
        If verificador = True Then
            DepositoToolStripMenuItem.Enabled = True
        Else
            DepositoToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Proveedor")
        If verificador = True Then
            ProveedorToolStripMenuItem.Enabled = True
        Else
            ProveedorToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Empleadodeposito")
        If verificador = True Then
            DepositoToolStripMenuItem2.Enabled = True
        Else
            DepositoToolStripMenuItem2.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Empleadosucursal")
        If verificador = True Then
            SucursalToolStripMenuItem2.Enabled = True
        Else
            SucursalToolStripMenuItem2.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Backup")
        If verificador = True Then
            BackupToolStripMenuItem.Enabled = True
        Else
            BackupToolStripMenuItem.Enabled = False
        End If


        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Restore")
        If verificador = True Then
            RestoreToolStripMenuItem.Enabled = True
        Else
            RestoreToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Bitacora")
        If verificador = True Then
            BitacoraToolStripMenuItem.Enabled = True
            DetalleVentaToolStripMenuItem.Enabled = True
        Else
            BitacoraToolStripMenuItem.Enabled = False
            DetalleVentaToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Reclamo")
        If verificador = True Then
            ReclamoToolStripMenuItem.Enabled = True
        Else
            ReclamoToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Depositostock")
        If verificador = True Then
            DepositoToolStripMenuItem1.Enabled = True
        Else
            DepositoToolStripMenuItem1.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Sucursalstock")
        If verificador = True Then
            SucursalToolStripMenuItem1.Enabled = True
        Else
            SucursalToolStripMenuItem1.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Reposicion")
        If verificador = True Then
            ReposicionToolStripMenuItem.Enabled = True
        Else
            ReposicionToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Renovacion")
        If verificador = True Then
            RenovacionDepositoToolStripMenuItem.Enabled = True
        Else
            RenovacionDepositoToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Venta")
        If verificador = True Then
            VENTAToolStripMenuItem.Enabled = True
        Else
            VENTAToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Devolucion")
        If verificador = True Then
            DevolucionToolStripMenuItem.Enabled = True
        Else
            DevolucionToolStripMenuItem.Enabled = False
        End If


        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Envio Asignar")
        If verificador = True Then
            AsignarToolStripMenuItem.Enabled = True
        Else
            AsignarToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Envio Ver")
        If verificador = True Then
            VerToolStripMenuItem.Enabled = True
        Else
            VerToolStripMenuItem.Enabled = False
        End If

        verificador = bllpermiso.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Acceso Bitacora")
        If verificador = True Then
            ResumenToolStripMenuItem.Enabled = True
        Else
            ResumenToolStripMenuItem.Enabled = False
        End If


        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)

        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)

        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)

        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)

        bllpalabra.verificacionpalabras(DevolucionToolStripMenuItem.Tag, DevolucionToolStripMenuItem.Text)
        DevolucionToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, DevolucionToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(UsuarioToolStripMenuItem.Tag, UsuarioToolStripMenuItem.Text)
        UsuarioToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, UsuarioToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(ProductoToolStripMenuItem.Tag, ProductoToolStripMenuItem.Text)
        ProductoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ProductoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(CerrarSesionToolStripMenuItem.Tag, CerrarSesionToolStripMenuItem.Text)
        CerrarSesionToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, CerrarSesionToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(BitacoraToolStripMenuItem.Tag, BitacoraToolStripMenuItem.Text)
        BitacoraToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, BitacoraToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(BackupToolStripMenuItem.Tag, BackupToolStripMenuItem.Text)
        BackupToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, BackupToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(RestoreToolStripMenuItem.Tag, RestoreToolStripMenuItem.Text)
        RestoreToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, RestoreToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(IdiomaToolStripMenuItem.Tag, IdiomaToolStripMenuItem.Text)
        IdiomaToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, IdiomaToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(PermisoToolStripMenuItem.Tag, PermisoToolStripMenuItem.Text)
        PermisoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, PermisoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(CompradorToolStripMenuItem.Tag, CompradorToolStripMenuItem.Text)
        CompradorToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, CompradorToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SucursalToolStripMenuItem.Tag, SucursalToolStripMenuItem.Text)
        SucursalToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, SucursalToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(DepositoToolStripMenuItem.Tag, DepositoToolStripMenuItem.Text)
        DepositoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, DepositoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(ReclamoToolStripMenuItem.Tag, ReclamoToolStripMenuItem.Text)
        ReclamoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ReclamoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(ProveedorToolStripMenuItem.Tag, ProveedorToolStripMenuItem.Text)
        ProveedorToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ProveedorToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SucursalToolStripMenuItem1.Tag, SucursalToolStripMenuItem1.Text)
        SucursalToolStripMenuItem1.Text = blltraduccion.Traduccion(idioma, SucursalToolStripMenuItem1.Tag)

        bllpalabra.verificacionpalabras(DepositoToolStripMenuItem1.Tag, DepositoToolStripMenuItem1.Text)
        DepositoToolStripMenuItem1.Text = blltraduccion.Traduccion(idioma, DepositoToolStripMenuItem1.Tag)

        bllpalabra.verificacionpalabras(DepositoToolStripMenuItem2.Tag, DepositoToolStripMenuItem2.Text)
        DepositoToolStripMenuItem2.Text = blltraduccion.Traduccion(idioma, DepositoToolStripMenuItem2.Tag)

        bllpalabra.verificacionpalabras(ReposicionToolStripMenuItem.Tag, ReposicionToolStripMenuItem.Text)
        ReposicionToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ReposicionToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SucursalToolStripMenuItem2.Tag, SucursalToolStripMenuItem2.Text)
        SucursalToolStripMenuItem2.Text = blltraduccion.Traduccion(idioma, SucursalToolStripMenuItem2.Tag)

        bllpalabra.verificacionpalabras(RenovacionDepositoToolStripMenuItem.Tag, RenovacionDepositoToolStripMenuItem.Text)
        RenovacionDepositoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, RenovacionDepositoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(DetalleVentaToolStripMenuItem.Tag, DetalleVentaToolStripMenuItem.Text)
        DetalleVentaToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, DetalleVentaToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(GenerarToolStripMenuItem.Tag, GenerarToolStripMenuItem.Text)
        GenerarToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, GenerarToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(AsignarToolStripMenuItem.Tag, AsignarToolStripMenuItem.Text)
        AsignarToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, AsignarToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(VerToolStripMenuItem.Tag, VerToolStripMenuItem.Text)
        VerToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, VerToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(AdministrarToolStripMenuItem.Tag, AdministrarToolStripMenuItem.Text)
        AdministrarToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, AdministrarToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(SeguridadToolStripMenuItem.Tag, SeguridadToolStripMenuItem.Text)
        SeguridadToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, SeguridadToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(StockToolStripMenuItem.Tag, StockToolStripMenuItem.Text)
        StockToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, StockToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(VENTAToolStripMenuItem.Tag, VENTAToolStripMenuItem.Text)
        VENTAToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, VENTAToolStripMenuItem.Tag)


        bllpalabra.verificacionpalabras(ResumenToolStripMenuItem.Tag, ResumenToolStripMenuItem.Text)
        ResumenToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, ResumenToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(EnvioToolStripMenuItem.Tag, EnvioToolStripMenuItem.Text)
        EnvioToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, EnvioToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(EmpleadoToolStripMenuItem.Tag, EmpleadoToolStripMenuItem.Text)
        EmpleadoToolStripMenuItem.Text = blltraduccion.Traduccion(idioma, EmpleadoToolStripMenuItem.Tag)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)


    End Sub

    Private Sub AdministrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministrarToolStripMenuItem.Click

    End Sub

    Private Sub SeguridadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguridadToolStripMenuItem.Click

    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click

    End Sub

    Private Sub VENTAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VENTAToolStripMenuItem.Click

    End Sub

    Private Sub EnvioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvioToolStripMenuItem.Click

    End Sub

    Private Sub EmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadoToolStripMenuItem.Click

    End Sub

    Private Sub Timersesion_Tick(sender As Object, e As EventArgs) Handles Timersesion.Tick
        contador = contador + 1
        Label5.Text = contador
        Label7.Text = DateTime.Now
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ResumenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenToolStripMenuItem.Click
        Dim n As New Grafico
        n.MdiParent = Me
        n.Show()
    End Sub
End Class