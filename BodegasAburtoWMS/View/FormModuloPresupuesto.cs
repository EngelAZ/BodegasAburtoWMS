using BodegasAburtoWMS.Service;
using System;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class FormModuloPresupuesto : Form
    {
        private readonly PresupuestoService _supuestoService;
        private readonly PresupuestoOperativoService _operativoService;
        private readonly EstadoProformaService _proformaService;

        // Inyección de dependencias limpia desde el Program.cs
        public FormModuloPresupuesto(
            PresupuestoService supuestoService,
            PresupuestoOperativoService operativoService,
            EstadoProformaService proformaService)
        {
            InitializeComponent();
            _supuestoService = supuestoService;
            _operativoService = operativoService;
            _proformaService = proformaService;

            InicializarPestanas();
        }

        private void InicializarPestanas()
        {
            var tabControl = new TabControl { Dock = DockStyle.Fill };

            // Instanciar los formularios utilizando los servicios inyectados
            var formSupuestos = ConfigurarFormularioHijo(new FormSupuestosBudget(_supuestoService));
            var formOperativo = ConfigurarFormularioHijo(new FormPresupuestoOperacion(_operativoService));
            var formProforma = ConfigurarFormularioHijo(new FormEstadosProforma(_proformaService));

            var tab1 = new TabPage("1. Supuestos y Políticas");
            tab1.Controls.Add(formSupuestos);

            var tab2 = new TabPage("2. Presupuesto Operativo y Caja");
            tab2.Controls.Add(formOperativo);

            var tab3 = new TabPage("3. Estados Financieros Proforma");
            tab3.Controls.Add(formProforma);

            tabControl.TabPages.AddRange(new[] { tab1, tab2, tab3 });
            this.Controls.Add(tabControl);

            formSupuestos.Show();
            formOperativo.Show();
            formProforma.Show();
        }

        private Form ConfigurarFormularioHijo(Form hijo)
        {
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            return hijo;
        }
    }
}