using System;
using System.Windows.Forms;
using IntroducaoPOO.Classes;

namespace IntroducaoPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client(); // cria e instancia 
            client.IdClient = (int)numId.Value; // atribui os valores dos atributos
            client.Nome = txtBuss.Text;
            client.CPF = txtDoc.Text;
            client.Telefone = msktel.Text;
            client.DataNascimento = dateBirth.Value;
            client.Renda = numIncome.Value;

            if (rbFem.Checked)
            {
                client.Sexo = "F"; 
            }
            else
            {
                client.Sexo = "M"; 
            }

            if (rbSolt.Checked)
            {
                client.EstadoCivil = "Solteiro";
            }
            else if (rbCasado.Checked)
            {
                client.EstadoCivil = "Casado";
            }
            else if (rbDiv.Checked)
            {
                client.EstadoCivil = "Divorciado";
            }
            else if (rbViu.Checked)
            {
                client.EstadoCivil = "Viúvo";
            }

            if (!CamposPreenchidos())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return; 
            }

            string retorno = client.Create(); // cria 

            if (string.IsNullOrEmpty(retorno))
            {
                MessageBox.Show("Dados inclusos com sucesso");
                LimparCampos(); // Limpar campos após operação somente em caso de sucesso
            }
            else
            {
                MessageBox.Show(retorno); 
            }
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.IdClient = (int)numId.Value;
            client.Nome = txtBuss.Text;
            client.CPF = txtDoc.Text;
            client.Telefone = msktel.Text;
            client.DataNascimento = dateBirth.Value;
            client.Renda = numIncome.Value;

            if (rbFem.Checked)
            {
                client.Sexo = "F"; 
            }
            else
            {
                client.Sexo = "M"; 
            }

            if (rbSolt.Checked)
            {
                client.EstadoCivil = "Solteiro";
            }
            else if (rbCasado.Checked)
            {
                client.EstadoCivil = "Casado";
            }
            else if (rbDiv.Checked)
            {
                client.EstadoCivil = "Divorciado";
            }
            else if (rbViu.Checked)
            {
                client.EstadoCivil = "Viúvo";
            }

            string retorno = client.Update(); 

            if (string.IsNullOrEmpty(retorno))
            {
                MessageBox.Show("Dados atualizados com sucesso");
                LimparCampos(); 
            }
            else
            {
                MessageBox.Show(retorno); 
            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.IdClient = (int)numId.Value;

            string retorno = client.Delete();

            if (string.IsNullOrEmpty(retorno))
            {
                MessageBox.Show("Cliente deletado com sucesso");
                LimparCampos(); 
            }
            else
            {
                MessageBox.Show(retorno); 
            }
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.IdClient = (int)numId.Value; 

            string retorno = client.Read(); 

            if (string.IsNullOrEmpty(retorno))
            {
                txtBuss.Text = client.Nome;
                txtDoc.Text = client.CPF;
                numIncome.Value = client.Renda;
                dateBirth.Value = client.DataNascimento;
                msktel.Text = client.Telefone;

                if (client.Sexo == "M")
                {
                    rbMasc.Checked = true;
                }
                else
                {
                    rbFem.Checked = true;
                }

                switch (client.EstadoCivil)
                {
                    case "Solteiro":
                        rbSolt.Checked = true;
                        break;
                    case "Casado":
                        rbCasado.Checked = true;
                        break;
                    case "Divorciado":
                        rbDiv.Checked = true;
                        break;
                    case "Viúvo":
                        rbViu.Checked = true;
                        break;
                }

                MessageBox.Show("Cliente consultado com sucesso");
            }
            else
            {
                MessageBox.Show(retorno); 
            }
        }

        // Método para limpar todos os campos após as operações
        private void LimparCampos()
        {
            txtBuss.Clear();
            numId.Value = 0;
            txtDoc.Clear();
            numIncome.Value = 0;
            dateBirth.Value = DateTime.Now;
            msktel.Clear();
            rbFem.Checked = false;
            rbMasc.Checked = false;
            rbSolt.Checked = false;
            rbCasado.Checked = false;
            rbDiv.Checked = false;
            rbViu.Checked = false;
        }

        private bool CamposPreenchidos()
        {
            return this.numId.Value > 0 && // Verifica se numId é maior que 0
                   !string.IsNullOrEmpty(this.txtBuss.Text) &&
                   !string.IsNullOrEmpty(this.txtDoc.Text) &&
                   this.numIncome.Value > 0 &&
                   (this.rbFem.Checked || this.rbMasc.Checked) && // Verifica se um dos radio buttons está selecionado
                   (this.rbSolt.Checked || this.rbCasado.Checked || this.rbViu.Checked || this.rbDiv.Checked) && // Verifica se um dos radio buttons está selecionado
                   this.dateBirth.Value != default(DateTime); // Verifica se a data de nascimento foi definida
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
