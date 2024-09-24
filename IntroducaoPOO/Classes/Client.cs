using System;
using System.IO;
using System.Windows.Forms;

namespace IntroducaoPOO.Classes
{
    public class Client
    {
        private int idClient;
        private string nome;
        private string cpf;
        private DateTime dataNascimento;
        private decimal renda;
        private string telefone;
        private string estadoCivil;
        private string sexo;

        public int IdClient
        {
            get { return idClient; }
            set { idClient = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string CPF
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        public decimal Renda
        {
            get { return renda; }
            set { renda = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set
            { telefone = value;  }
        }

        public string EstadoCivil 
        { 
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        // Criação do cliente
        public string Create()
        {
            string nomeArquivo = "Client" + this.idClient.ToString() + ".txt";

            // Verifica se já existe um cliente com esse ID
            if (File.Exists(nomeArquivo))
                return "O Id já está cadastrado";

            try
            {
                using (StreamWriter arquivo = new StreamWriter(nomeArquivo))
                {
                    arquivo.WriteLine(this.idClient.ToString());
                    arquivo.WriteLine(this.nome);
                    arquivo.WriteLine(this.CPF);
                    arquivo.WriteLine(this.dataNascimento.ToString("yyyy-MM-dd")); 
                    arquivo.WriteLine(this.renda.ToString());
                    arquivo.WriteLine(this.telefone);
                    arquivo.WriteLine(this.estadoCivil);
                    arquivo.WriteLine(this.sexo);  
                }
                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao criar cliente: " + ex.Message;
            }
        }

        // Atualização do cliente
        public string Update()
        {
            string nomeArquivo = "Client" + this.idClient.ToString() + ".txt";

            if (!File.Exists(nomeArquivo))
                return "O Id não está cadastrado";

            try
            {
                using (StreamWriter arquivo = new StreamWriter(nomeArquivo))
                {
                    arquivo.WriteLine(this.idClient.ToString());
                    arquivo.WriteLine(this.nome);
                    arquivo.WriteLine(this.CPF);
                    arquivo.WriteLine(this.renda.ToString());
                    arquivo.WriteLine(this.dataNascimento.ToString("yyyy-MM-dd"));
                    arquivo.WriteLine(this.telefone);
                    arquivo.WriteLine(this.estadoCivil);
                    arquivo.WriteLine(this.sexo);
                }

                return "Cliente alterado com sucesso";
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar o cliente: " + ex.Message;
            }
        }

        // Consulta do cliente
        public string Read()
        {
            string nomeArquivo = "Client" + this.idClient.ToString() + ".txt";

            if (!File.Exists(nomeArquivo))
                return "O Id não está cadastrado";

            try
            {
                using (StreamReader arquivo = new StreamReader(nomeArquivo))
                {
                    this.idClient = Convert.ToInt32(arquivo.ReadLine());
                    this.nome = arquivo.ReadLine();
                    this.CPF = arquivo.ReadLine();
                    this.renda = Convert.ToDecimal(arquivo.ReadLine());
                    this.dataNascimento = DateTime.Parse(arquivo.ReadLine()); this.telefone = arquivo.ReadLine();
                    this.estadoCivil = arquivo.ReadLine();
                    this.sexo = arquivo.ReadLine();
                    this.renda = Convert.ToDecimal(arquivo.ReadLine());
                    this.dataNascimento = DateTime.Parse(arquivo.ReadLine());
                }

                return "";
            }
            catch (Exception ex)
            {
                return "Erro ao ler o cliente: " + ex.Message;
            }
        }

        // Exclusão do cliente
        public string Delete()
        {
            string nomeArquivo = "Client" + this.idClient.ToString() + ".txt";

            if (!File.Exists(nomeArquivo))
                return "O Id não foi encontrado!";

            try
            {
                File.Delete(nomeArquivo);
                return "Dados excluídos com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro ao deletar o cliente: " + ex.Message;
            }
        }
    }
}
