namespace Zeus.Application
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oficialDeGuardiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correlativosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.continuarExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.módulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarMódulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despachoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cantidadDeCarrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prioridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compañíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prioridad2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prioridad3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recursosHumanosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conductoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voluntariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuartelerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oficialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operadorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subroganciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoInterinajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interinajesEnCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llamadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clavesYSubclavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preinformesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBox = new System.Windows.Forms.ToolStrip();
            this.toolMódulos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMaterialMayor = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.tsHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServidor = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBarraEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBaseDatos = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkFeriado = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mainTree1 = new Zeus.UIElements.ExpedientesTreeView();
            this.slidePanel1 = new Zeus.UIElements.SlidePanel();
            this.mainTabs1 = new Zeus.UIElements.BitacoraExpedientesTabControl();
            this.mainLlamadosCarros1 = new Zeus.UIElements.MainLlamadosCarros();
            this.Hora = new System.Windows.Forms.Timer(this.components);
            this.VerificacionLlave = new System.Windows.Forms.Timer(this.components);
            this.CeroHoras = new System.Windows.Forms.Timer(this.components);
            this.MenuPrincipal.SuspendLayout();
            this.ToolBox.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.slidePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.módulosToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(1017, 24);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "Menu";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarToolStripMenuItem,
            this.oficialDeGuardiaToolStripMenuItem,
            this.correlativosToolStripMenuItem,
            this.toolStripSeparator2,
            this.cerrarSesiónToolStripMenuItem,
            this.toolStripSeparator4,
            this.asdToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.menuToolStripMenuItem.Text = "Sistema";
            // 
            // configurarToolStripMenuItem
            // 
            this.configurarToolStripMenuItem.Name = "configurarToolStripMenuItem";
            this.configurarToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.configurarToolStripMenuItem.Text = "Configurar...";
            this.configurarToolStripMenuItem.Click += new System.EventHandler(this.configurarToolStripMenuItem_Click);
            // 
            // oficialDeGuardiaToolStripMenuItem
            // 
            this.oficialDeGuardiaToolStripMenuItem.Name = "oficialDeGuardiaToolStripMenuItem";
            this.oficialDeGuardiaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.oficialDeGuardiaToolStripMenuItem.Text = "Oficial de Guardia...";
            this.oficialDeGuardiaToolStripMenuItem.Click += new System.EventHandler(this.oficialDeGuardiaToolStripMenuItem_Click);
            // 
            // correlativosToolStripMenuItem
            // 
            this.correlativosToolStripMenuItem.Name = "correlativosToolStripMenuItem";
            this.correlativosToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.correlativosToolStripMenuItem.Text = "Correlativos...";
            this.correlativosToolStripMenuItem.Click += new System.EventHandler(this.correlativosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem1,
            this.continuarExpedienteToolStripMenuItem,
            this.cambiarContraseñaToolStripMenuItem});
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Sesión";
            // 
            // cerrarSesiónToolStripMenuItem1
            // 
            this.cerrarSesiónToolStripMenuItem1.Name = "cerrarSesiónToolStripMenuItem1";
            this.cerrarSesiónToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.cerrarSesiónToolStripMenuItem1.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem1.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // continuarExpedienteToolStripMenuItem
            // 
            this.continuarExpedienteToolStripMenuItem.Name = "continuarExpedienteToolStripMenuItem";
            this.continuarExpedienteToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.continuarExpedienteToolStripMenuItem.Text = "Continuar Expediente...";
            this.continuarExpedienteToolStripMenuItem.Click += new System.EventHandler(this.continuarExpedienteToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña...";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(174, 6);
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.asdToolStripMenuItem.Text = "&Salir";
            this.asdToolStripMenuItem.Click += new System.EventHandler(this.asdToolStripMenuItem_Click);
            // 
            // módulosToolStripMenuItem
            // 
            this.módulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarMódulosToolStripMenuItem,
            this.mnuMostrar,
            this.toolStripSeparator1});
            this.módulosToolStripMenuItem.Name = "módulosToolStripMenuItem";
            this.módulosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.módulosToolStripMenuItem.Text = "Módulos";
            // 
            // administrarMódulosToolStripMenuItem
            // 
            this.administrarMódulosToolStripMenuItem.Image = global::Zeus.Application.Properties.Resources.modulos;
            this.administrarMódulosToolStripMenuItem.Name = "administrarMódulosToolStripMenuItem";
            this.administrarMódulosToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.administrarMódulosToolStripMenuItem.Text = "Administrar módulos...";
            this.administrarMódulosToolStripMenuItem.Click += new System.EventHandler(this.administrarMódulosToolStripMenuItem_Click);
            // 
            // mnuMostrar
            // 
            this.mnuMostrar.Name = "mnuMostrar";
            this.mnuMostrar.Size = new System.Drawing.Size(195, 22);
            this.mnuMostrar.Text = "Mostrar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carrosToolStripMenuItem,
            this.despachoToolStripMenuItem,
            this.recursosHumanosToolStripMenuItem,
            this.llamadosToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // carrosToolStripMenuItem
            // 
            this.carrosToolStripMenuItem.Name = "carrosToolStripMenuItem";
            this.carrosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.carrosToolStripMenuItem.Text = "Material Mayor...";
            this.carrosToolStripMenuItem.Click += new System.EventHandler(this.carrosToolStripMenuItem_Click);
            // 
            // despachoToolStripMenuItem
            // 
            this.despachoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cantidadDeCarrosToolStripMenuItem,
            this.ordenToolStripMenuItem,
            this.prioridadToolStripMenuItem,
            this.compañíasToolStripMenuItem,
            this.prioridad2ToolStripMenuItem,
            this.prioridad3ToolStripMenuItem});
            this.despachoToolStripMenuItem.Name = "despachoToolStripMenuItem";
            this.despachoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.despachoToolStripMenuItem.Text = "Despacho";
            // 
            // cantidadDeCarrosToolStripMenuItem
            // 
            this.cantidadDeCarrosToolStripMenuItem.Name = "cantidadDeCarrosToolStripMenuItem";
            this.cantidadDeCarrosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.cantidadDeCarrosToolStripMenuItem.Text = "Cantidades Despacho...";
            this.cantidadDeCarrosToolStripMenuItem.Click += new System.EventHandler(this.cantidadDeCarrosToolStripMenuItem_Click);
            // 
            // ordenToolStripMenuItem
            // 
            this.ordenToolStripMenuItem.Name = "ordenToolStripMenuItem";
            this.ordenToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ordenToolStripMenuItem.Text = "Orden Solicitud de Carros...";
            this.ordenToolStripMenuItem.Click += new System.EventHandler(this.ordenToolStripMenuItem_Click);
            // 
            // prioridadToolStripMenuItem
            // 
            this.prioridadToolStripMenuItem.Name = "prioridadToolStripMenuItem";
            this.prioridadToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.prioridadToolStripMenuItem.Text = "Prioridad Despacho...";
            this.prioridadToolStripMenuItem.Click += new System.EventHandler(this.prioridadToolStripMenuItem_Click);
            // 
            // compañíasToolStripMenuItem
            // 
            this.compañíasToolStripMenuItem.Name = "compañíasToolStripMenuItem";
            this.compañíasToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.compañíasToolStripMenuItem.Text = "Compañías...";
            this.compañíasToolStripMenuItem.Click += new System.EventHandler(this.compañíasToolStripMenuItem_Click);
            // 
            // prioridad2ToolStripMenuItem
            // 
            this.prioridad2ToolStripMenuItem.Name = "prioridad2ToolStripMenuItem";
            this.prioridad2ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.prioridad2ToolStripMenuItem.Text = "Prioridad 2";
            this.prioridad2ToolStripMenuItem.Click += new System.EventHandler(this.prioridad2ToolStripMenuItem_Click);
            // 
            // prioridad3ToolStripMenuItem
            // 
            this.prioridad3ToolStripMenuItem.Name = "prioridad3ToolStripMenuItem";
            this.prioridad3ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.prioridad3ToolStripMenuItem.Text = "Prioridad 3";
            // 
            // recursosHumanosToolStripMenuItem
            // 
            this.recursosHumanosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conductoresToolStripMenuItem,
            this.voluntariosToolStripMenuItem,
            this.cuartelerosToolStripMenuItem,
            this.oficialesToolStripMenuItem,
            this.operadorasToolStripMenuItem,
            this.locutoresToolStripMenuItem,
            this.subroganciaToolStripMenuItem});
            this.recursosHumanosToolStripMenuItem.Name = "recursosHumanosToolStripMenuItem";
            this.recursosHumanosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.recursosHumanosToolStripMenuItem.Text = "Recursos Humanos";
            // 
            // conductoresToolStripMenuItem
            // 
            this.conductoresToolStripMenuItem.Name = "conductoresToolStripMenuItem";
            this.conductoresToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.conductoresToolStripMenuItem.Text = "Conductores...";
            this.conductoresToolStripMenuItem.Click += new System.EventHandler(this.conductoresToolStripMenuItem_Click_1);
            // 
            // voluntariosToolStripMenuItem
            // 
            this.voluntariosToolStripMenuItem.Name = "voluntariosToolStripMenuItem";
            this.voluntariosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.voluntariosToolStripMenuItem.Text = "Voluntarios...";
            this.voluntariosToolStripMenuItem.Click += new System.EventHandler(this.voluntariosToolStripMenuItem_Click);
            // 
            // cuartelerosToolStripMenuItem
            // 
            this.cuartelerosToolStripMenuItem.Name = "cuartelerosToolStripMenuItem";
            this.cuartelerosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.cuartelerosToolStripMenuItem.Text = "Cuarteleros...";
            this.cuartelerosToolStripMenuItem.Click += new System.EventHandler(this.cuartelerosToolStripMenuItem_Click);
            // 
            // oficialesToolStripMenuItem
            // 
            this.oficialesToolStripMenuItem.Name = "oficialesToolStripMenuItem";
            this.oficialesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.oficialesToolStripMenuItem.Text = "Oficiales...";
            this.oficialesToolStripMenuItem.Click += new System.EventHandler(this.oficialesToolStripMenuItem_Click);
            // 
            // operadorasToolStripMenuItem
            // 
            this.operadorasToolStripMenuItem.Name = "operadorasToolStripMenuItem";
            this.operadorasToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.operadorasToolStripMenuItem.Text = "Operadoras...";
            this.operadorasToolStripMenuItem.Click += new System.EventHandler(this.operadorasToolStripMenuItem_Click);
            // 
            // locutoresToolStripMenuItem
            // 
            this.locutoresToolStripMenuItem.Name = "locutoresToolStripMenuItem";
            this.locutoresToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.locutoresToolStripMenuItem.Text = "Locutores...";
            this.locutoresToolStripMenuItem.Click += new System.EventHandler(this.locutoresToolStripMenuItem_Click);
            // 
            // subroganciaToolStripMenuItem
            // 
            this.subroganciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoInterinajeToolStripMenuItem,
            this.interinajesEnCursoToolStripMenuItem});
            this.subroganciaToolStripMenuItem.Name = "subroganciaToolStripMenuItem";
            this.subroganciaToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.subroganciaToolStripMenuItem.Text = "Interinaje de Oficiales";
            // 
            // nuevoInterinajeToolStripMenuItem
            // 
            this.nuevoInterinajeToolStripMenuItem.Name = "nuevoInterinajeToolStripMenuItem";
            this.nuevoInterinajeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.nuevoInterinajeToolStripMenuItem.Text = "Nuevo Interinaje...";
            this.nuevoInterinajeToolStripMenuItem.Click += new System.EventHandler(this.nuevoInterinajeToolStripMenuItem_Click);
            // 
            // interinajesEnCursoToolStripMenuItem
            // 
            this.interinajesEnCursoToolStripMenuItem.Name = "interinajesEnCursoToolStripMenuItem";
            this.interinajesEnCursoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.interinajesEnCursoToolStripMenuItem.Text = "Interinajes Programados...";
            // 
            // llamadosToolStripMenuItem
            // 
            this.llamadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clavesYSubclavesToolStripMenuItem,
            this.preinformesToolStripMenuItem});
            this.llamadosToolStripMenuItem.Name = "llamadosToolStripMenuItem";
            this.llamadosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.llamadosToolStripMenuItem.Text = "Llamados";
            // 
            // clavesYSubclavesToolStripMenuItem
            // 
            this.clavesYSubclavesToolStripMenuItem.Name = "clavesYSubclavesToolStripMenuItem";
            this.clavesYSubclavesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clavesYSubclavesToolStripMenuItem.Text = "Claves y subclaves...";
            this.clavesYSubclavesToolStripMenuItem.Click += new System.EventHandler(this.clavesYSubclavesToolStripMenuItem_Click);
            // 
            // preinformesToolStripMenuItem
            // 
            this.preinformesToolStripMenuItem.Name = "preinformesToolStripMenuItem";
            this.preinformesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.preinformesToolStripMenuItem.Text = "Preinformes...";
            this.preinformesToolStripMenuItem.Click += new System.EventHandler(this.preinformesToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // ToolBox
            // 
            this.ToolBox.AllowItemReorder = true;
            this.ToolBox.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMódulos,
            this.toolStripSeparator3,
            this.toolMaterialMayor});
            this.ToolBox.Location = new System.Drawing.Point(0, 24);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(1017, 54);
            this.ToolBox.TabIndex = 1;
            this.ToolBox.Text = "toolStrip1";
            // 
            // toolMódulos
            // 
            this.toolMódulos.AutoSize = false;
            this.toolMódulos.Image = global::Zeus.Application.Properties.Resources.modulos;
            this.toolMódulos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMódulos.Name = "toolMódulos";
            this.toolMódulos.Size = new System.Drawing.Size(70, 50);
            this.toolMódulos.Text = "Módulos";
            this.toolMódulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolMódulos.Click += new System.EventHandler(this.toolMódulos_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // toolMaterialMayor
            // 
            this.toolMaterialMayor.Image = ((System.Drawing.Image)(resources.GetObject("toolMaterialMayor.Image")));
            this.toolMaterialMayor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMaterialMayor.Name = "toolMaterialMayor";
            this.toolMaterialMayor.Size = new System.Drawing.Size(91, 51);
            this.toolMaterialMayor.Text = "Material Mayor";
            this.toolMaterialMayor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolMaterialMayor.Click += new System.EventHandler(this.toolMaterialMayor_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHora,
            this.lblUsuario,
            this.lblServidor,
            this.lblBarraEstado,
            this.lblBaseDatos});
            this.StatusBar.Location = new System.Drawing.Point(0, 718);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1017, 24);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // tsHora
            // 
            this.tsHora.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsHora.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsHora.Name = "tsHora";
            this.tsHora.Size = new System.Drawing.Size(16, 19);
            this.tsHora.Text = "-";
            // 
            // lblUsuario
            // 
            this.lblUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(19, 19);
            this.lblUsuario.Text = "[]";
            // 
            // lblServidor
            // 
            this.lblServidor.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblServidor.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(19, 19);
            this.lblServidor.Text = "[]";
            // 
            // lblBarraEstado
            // 
            this.lblBarraEstado.Name = "lblBarraEstado";
            this.lblBarraEstado.Size = new System.Drawing.Size(0, 19);
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(15, 19);
            this.lblBaseDatos.Text = "[]";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 78);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkFeriado);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.mainTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.slidePanel1);
            this.splitContainer1.Panel2.Controls.Add(this.mainLlamadosCarros1);
            this.splitContainer1.Panel2.SizeChanged += new System.EventHandler(this.splitContainer1_Panel2_SizeChanged);
            this.splitContainer1.Size = new System.Drawing.Size(1017, 640);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 3;
            // 
            // chkFeriado
            // 
            this.chkFeriado.AutoSize = true;
            this.chkFeriado.Location = new System.Drawing.Point(10, 616);
            this.chkFeriado.Name = "chkFeriado";
            this.chkFeriado.Size = new System.Drawing.Size(141, 17);
            this.chkFeriado.TabIndex = 3;
            this.chkFeriado.Text = "Feriado o fin de semana";
            this.chkFeriado.UseVisualStyleBackColor = true;
            this.chkFeriado.Visible = false;
            this.chkFeriado.CheckedChanged += new System.EventHandler(this.chkFeriado_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 611);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reemplazo de Bombas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainTree1
            // 
            this.mainTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTree1.Location = new System.Drawing.Point(0, 0);
            this.mainTree1.Name = "mainTree1";
            this.mainTree1.Size = new System.Drawing.Size(303, 636);
            this.mainTree1.TabIndex = 0;
            this.mainTree1.ZeusWin = null;
            // 
            // slidePanel1
            // 
            this.slidePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slidePanel1.Controls.Add(this.mainTabs1);
            this.slidePanel1.Id_operadora = 0;
            this.slidePanel1.Location = new System.Drawing.Point(3, 3);
            this.slidePanel1.MaxHeight = 0;
            this.slidePanel1.Name = "slidePanel1";
            this.slidePanel1.Size = new System.Drawing.Size(696, 466);
            this.slidePanel1.TabIndex = 1;
            this.slidePanel1.ZeusWin = null;
            this.slidePanel1.StateChanged += new System.EventHandler<Zeus.UIElements.SlidePanelEventArgs>(this.slidePanel1_StateChanged);
            this.slidePanel1.StateChanging += new System.EventHandler<Zeus.UIElements.SlidePanelEventArgs>(this.slidePanel1_StateChanging);
            // 
            // mainTabs1
            // 
            this.mainTabs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs1.Location = new System.Drawing.Point(0, 0);
            this.mainTabs1.Name = "mainTabs1";
            this.mainTabs1.Size = new System.Drawing.Size(696, 421);
            this.mainTabs1.TabIndex = 2;
            this.mainTabs1.ZeusWin = null;
            // 
            // mainLlamadosCarros1
            // 
            this.mainLlamadosCarros1.BackgroundImage = global::Zeus.Application.Properties.Resources.zeus_png;
            this.mainLlamadosCarros1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainLlamadosCarros1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLlamadosCarros1.Location = new System.Drawing.Point(0, 0);
            this.mainLlamadosCarros1.Name = "mainLlamadosCarros1";
            this.mainLlamadosCarros1.Size = new System.Drawing.Size(702, 636);
            this.mainLlamadosCarros1.TabIndex = 0;
            this.mainLlamadosCarros1.ZeusWin = null;
            // 
            // Hora
            // 
            this.Hora.Interval = 1000;
            this.Hora.Tick += new System.EventHandler(this.Hora_Tick);
            // 
            // VerificacionLlave
            // 
            this.VerificacionLlave.Tick += new System.EventHandler(this.VerificacionLlave_Tick);
            // 
            // CeroHoras
            // 
            this.CeroHoras.Tick += new System.EventHandler(this.CeroHoras_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 742);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ToolBox);
            this.Controls.Add(this.MenuPrincipal);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "MainForm";
            this.Text = "ZEUS - Cuerpo de Bomberos Metropolitano Sur";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.ToolBox.ResumeLayout(false);
            this.ToolBox.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.slidePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStrip ToolBox;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem módulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarMódulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tsHora;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblServidor;
        private System.Windows.Forms.Timer Hora;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraEstado;
        private Zeus.UIElements.ExpedientesTreeView mainTree1;
        private System.Windows.Forms.ToolStripButton toolMódulos;
        private System.Windows.Forms.ToolStripMenuItem configurarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolMaterialMayor;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despachoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cantidadDeCarrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prioridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recursosHumanosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conductoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voluntariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuartelerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oficialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subroganciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem llamadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clavesYSubclavesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preinformesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operadorasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locutoresToolStripMenuItem;
        private Zeus.UIElements.SlidePanel slidePanel1;
        private Zeus.UIElements.BitacoraExpedientesTabControl mainTabs1;
        private Zeus.UIElements.MainLlamadosCarros mainLlamadosCarros1;
        private System.Windows.Forms.ToolStripMenuItem mnuMostrar;
        private System.Windows.Forms.Timer VerificacionLlave;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem continuarExpedienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoInterinajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interinajesEnCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oficialDeGuardiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblBaseDatos;
        private System.Windows.Forms.ToolStripMenuItem compañíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correlativosToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer CeroHoras;
        private System.Windows.Forms.CheckBox chkFeriado;
        private System.Windows.Forms.ToolStripMenuItem prioridad2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prioridad3ToolStripMenuItem;
    }
}

