using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security;
using System.Diagnostics;
using System.Threading;

namespace pallasRestart
{
    public partial class Pallas : Form
    {
        public Pallas()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        }

        valor valor = new valor();

        private void button2_Click(object sender, EventArgs e)
        {
            valor.teste = "Apocryphoon";

            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Selecione o inicializador do servidor.                                        Desenvolvido por Apocryphoon!";

            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                valor.teste = openFileDialog1.FileName;
                MessageBox.Show("Arquivo carregado com sucesso!", "Selecionado com sucesso.");
                txtArquivo.Text = valor.teste;

            }

        }

        Process proc;

        private void button3_Click(object sender, EventArgs e)
        {
            decimal n1 = 0;

            if (numericUpDown1.Value == 0 && valor.teste == null)
            {
                MessageBox.Show("Algo está errado! Verifique os campos.");
            }
            else
            {
                n1 = numericUpDown1.Value;
                MessageBox.Show("O servidor reiniciará daqui a: " + n1 + "Hora(s)!");

                //Timer
                InitializeTimer();

            }
        }


        private int counter;
        private int concluido = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

            var processos = Process.GetProcessesByName("FXServer");

            foreach (var p in processos)
            {
                p.Kill();
            }
        }


        private void InitializeTimer()
        {
            counter = 0;
            timer1.Enabled = true;
            proc = Process.Start(valor.teste);
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1minuto é = 1080
            // 1hora é = 64.800
            decimal horas = numericUpDown1.Value * 64800;

            //ABRE O RUN.CMD QUANDO O TIME INICIA, QUANDO ACABA FECHA E ABRE DENOVO

            if (counter >= horas)
            {
                timer1.Enabled = false;
                counter = 0;

                concluido = concluido + 1;
                labelReset.Text = concluido.ToString() + " Veze(s)";


                //Process.GetProcessesByName("FXServer")[0].Kill();

                var processos = Process.GetProcessesByName("FXServer");

                foreach (var p in processos) { 
                    p.Kill();
                }


                InitializeTimer();
            }
            else
            {
                counter = counter + 1;
                labelValor.Text = counter.ToString() + " ms";

            }
        }

    }
}
