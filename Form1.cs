using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Termo
{
    public partial class Form1 : Form
    {
        private readonly Color corFundo = ColorTranslator.FromHtml("#121213");
        private readonly Color corVazio = ColorTranslator.FromHtml("#3A3A3C");
        private readonly Color corDigitando = ColorTranslator.FromHtml("#565758");
        private readonly Color corCerta = ColorTranslator.FromHtml("#538D4E");
        private readonly Color corExiste = ColorTranslator.FromHtml("#B59F3B");
        private readonly Color corErrada = ColorTranslator.FromHtml("#3A3A3C");
        private readonly Color corTeclado = ColorTranslator.FromHtml("#818384");
        int linhaAtual = 0;
        int casaAtual = 0;
        string palavra;
        List<List<Button>> linhas = new List<List<Button>>();
        List<string> palavraDigitadaLinha = new List<string>();
        List<Button> letrasErradas = new List<Button>();
        List<string> Palavras = new List<string>();
        public Form1()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#FAFAFC");
            Apply(this);
            foreach (Control c in this.Controls)
            {
                if (c is Button b && b.Text.Length == 1)
                {
                    b.BackColor = corTeclado;
                    b.FlatAppearance.BorderSize = 0;
                }
            }
            this.BackColor = corFundo;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            Palavras.Add("TERMO");
            Palavras.Add("PAULO");
            Palavras.Add("TESTE");
            palavraDigitadaLinha = Enumerable.Repeat("", 5).ToList();
            Random r = new Random();
            int numSort = r.Next(0, Palavras.Count);
            palavra = Palavras[numSort];

            linhas.Add(new List<Button>()
            {
                button28,
                button29,
                button31,
                button30,
                button33,
            });
            linhas.Add(new List<Button>()
            {
                button37,
                button36,
                button35,
                button34,
                button32,
            });
            linhas.Add(new List<Button>()
            {
                button42,
                button41,
                button40,
                button39,
                button38,
            });
            linhas.Add(new List<Button>()
            {
                button47,
                button46,
                button45,
                button44,
                button43,
            });

            linhas.Add(new List<Button>()
            {
                button52,
                button51,
                button50,
                button49,
                button48,
            });

            PintarLinha();
        }

        private void PintarLinha()
        {

            foreach (var b in linhas[linhaAtual])
            {
                b.BackColor = Color.Transparent;
            }
        }
        private void Entrada()
        {
            if (casaAtual != 5)
            {
                return;
            }

            var r = VerificarResultado();
            if (linhaAtual == 4)
            {
                MessageBox.Show("Acabou o jogo");
                Reiniciar();
                return;
            }
            if (r)
            {
                Reiniciar();
                return;
            }

            foreach (Control c in this.Controls)
            {
                if (c is Button b)
                {
                    if (!palavra.Contains(b.Text) && palavraDigitadaLinha[linhaAtual].Contains(b.Text))
                    {
                        b.BackColor = Color.Brown;
                    }
                }
            }
            casaAtual = 0;
            linhaAtual++;
            foreach (var b in linhas[linhaAtual])
            {
                b.BackColor = Color.Transparent;
            }


        }

        private void Reiniciar()
        {
            Random r = new Random();
            int numSort = r.Next(0, Palavras.Count);
            palavra = Palavras[numSort];
            palavraDigitadaLinha.Clear();
            palavraDigitadaLinha.Add("");
            palavraDigitadaLinha.Add("");
            palavraDigitadaLinha.Add("");
            palavraDigitadaLinha.Add("");
            palavraDigitadaLinha.Add("");
            casaAtual = 0;
            linhaAtual = 0;
            Apply(this);
            for (int i = 0; i < linhas.Count; i++)
            {
                foreach (var x in linhas[i])
                {
                    x.Text = "";
                }

            }

        }


        private bool VerificarResultado()
        {
            var tentativa = palavraDigitadaLinha[linhaAtual];

            Dictionary<char, int> contador = new Dictionary<char, int>();

            foreach (char c in palavra)
            {
                if (contador.ContainsKey(c))
                    contador[c]++;
                else
                    contador[c] = 1;
            }

            for (int i = 0; i < tentativa.Length; i++)
            {
                if (tentativa[i] == palavra[i])
                {
                    linhas[linhaAtual][i].BackColor = corCerta;
                    contador[tentativa[i]]--;
                }
            }

            for (int i = 0; i < tentativa.Length; i++)
            {
                if (linhas[linhaAtual][i].BackColor == corCerta)
                    continue;

                char letra = tentativa[i];

                if (contador.ContainsKey(letra) && contador[letra] > 0)
                {
                    linhas[linhaAtual][i].BackColor = corExiste;
                    contador[letra]--;
                }
                else
                {
                    linhas[linhaAtual][i].BackColor = corErrada;
                    letrasErradas.Add(linhas[linhaAtual][i]);
                }
            }

            if (tentativa == palavra)
            {
                MessageBox.Show("Impressionante voce ganhou na " + (linhaAtual + 1) + " linha!");
                return true;
            }

            return false;
        }


        private void Apagar()
        {
            if (casaAtual == 0) return;
            casaAtual--;
            linhas[linhaAtual][casaAtual].Text = "";
            linhas[linhaAtual][casaAtual].BackColor = Color.Transparent;
            palavraDigitadaLinha[linhaAtual] = palavraDigitadaLinha[linhaAtual].Substring(0, palavraDigitadaLinha[linhaAtual].Length - 1);
        }


        private void PintarCasa(string txt)
        {

            if (casaAtual == 5) return;
            linhas[linhaAtual][casaAtual].BackColor = corDigitando;
            linhas[linhaAtual][casaAtual].Text = txt;
            palavraDigitadaLinha[linhaAtual] += txt;
            casaAtual++;
        }


        public void Apply(Control c)
        {
            if (c is Button b)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 2;
                b.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3A3A3C");
                b.BackColor = corVazio;
                b.ForeColor = Color.White;
                b.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }

            foreach (Control x in c.Controls)
            {
                Apply(x);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PintarCasa("Y");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PintarCasa("D");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PintarCasa("F");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            PintarCasa("G");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PintarCasa("H");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PintarCasa("Q");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PintarCasa("W");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PintarCasa("E");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PintarCasa("R");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PintarCasa("T");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PintarCasa("U");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PintarCasa("I");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PintarCasa("O");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PintarCasa("P");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PintarCasa("A");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PintarCasa("S");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            PintarCasa("J");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PintarCasa("K");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            PintarCasa("L");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            PintarCasa("Ç");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            PintarCasa("Z");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            PintarCasa("X");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            PintarCasa("C");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            PintarCasa("V");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            PintarCasa("B");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            PintarCasa("N");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            PintarCasa("M");
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Entrada();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Apagar();
        }
    }
}
