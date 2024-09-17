using System.IO.Ports;
using System.Windows.Forms;

namespace Arduino
{
    public partial class Form1 : Form
    {
        private SerialPort srpArduino;
        private bool potentiometerActive = false;
        private int messageCount = 0;  // Contador de mensagens

        public Form1()
        {
            InitializeComponent();
            srpArduino = new SerialPort();
            srpArduino.DataReceived += SrpArduino_DataReceived;
        }

        private void SrpArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var dados = srpArduino.ReadLine();

                // Atualiza a UI na thread principal usando o método Invoke
                txtReceber.Invoke(new Action(() =>
                {
                    txtReceber.Text += dados + "\n";
                    messageCount++;  // Incrementa o contador de mensagens

                    // Verifica se recebeu 10 mensagens e limpa o campo de texto
                    if (messageCount >= 10)
                    {
                        txtReceber.Clear();  // Limpa o txtReceber
                        messageCount = 0;    // Reseta o contador
                    }
                }));
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer uma exceção durante a recepção de dados
                MessageBox.Show("Erro ao receber dados: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrPortas.Tick += TmrPortas_Tick;
            tmrPortas.Enabled = true;
        }

        private void TmrPortas_Tick(object? sender, EventArgs e)
        {
            var i = 0;
            var qtdeDiferente = false;

            if (cmbPortas.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (var porta in SerialPort.GetPortNames())
                    if (!cmbPortas.Items[i++].Equals(porta))
                    {
                        qtdeDiferente = true;
                        break;
                    }
            }
            else
                qtdeDiferente = true;

            if (!qtdeDiferente)
                return;

            cmbPortas.Items.Clear();

            foreach (var porta in SerialPort.GetPortNames())
                cmbPortas.Items.Add(porta);

            cmbPortas.SelectedIndex = 0;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (!srpArduino.IsOpen)
            {
                try
                {
                    srpArduino.PortName = cmbPortas.Text;
                    srpArduino.BaudRate = 9600;  // Certifique-se de que o baud rate está correto
                    srpArduino.Open();
                    btnConectar.Text = "Desconectar";
                    cmbPortas.Enabled = false;
                    AtivarCampos(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    srpArduino.Close();
                    btnConectar.Text = "Conectar";
                    cmbPortas.Enabled = true;
                    AtivarCampos(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnPotenciometro_Click(object sender, EventArgs e)
        {
            // Ativa ou desativa a recepção do potenciômetro
            potentiometerActive = !potentiometerActive;
            btnPotenciometro.Text = potentiometerActive ? "Desativar Potenciometro" : "Ativar Potenciometro";

            // Envia comandos para o Arduino para ativar/desativar a leitura do potenciômetro
            if (srpArduino.IsOpen)
            {
                srpArduino.Write(potentiometerActive ? "#POTENTIOMETER_ON\n" : "#POTENTIOMETER_OFF\n");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (srpArduino.IsOpen)
            {
                srpArduino.Write(checkBox1.Checked ? "#LED1ON\n" : "#LED1OFF\n");  // Liga/Desliga o LED 1
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (srpArduino.IsOpen)
            {
                srpArduino.Write(checkBox2.Checked ? "#LED2ON\n" : "#LED2OFF\n");  // Liga/Desliga o LED 2
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (srpArduino.IsOpen)
            {
                srpArduino.Write(checkBox3.Checked ? "#LED3ON\n" : "#LED3OFF\n");  // Liga/Desliga o LED 3
            }
        }

        private void AtivarCampos(bool ativ)
        {
            grpLeds.Enabled = ativ;
            btnPotenciometro.Enabled = ativ;
            txtReceber.Enabled = ativ;
        }
    }
}
