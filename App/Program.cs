using System;
using System.IO;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

                    string line1;

                    string line2;

                    string currentDir = Environment.CurrentDirectory;
                    DirectoryInfo directory = new DirectoryInfo(currentDir);
                    FileInfo file1 = new FileInfo("produtos.txt");
                    FileInfo file2 = new FileInfo("vendas.txt");
                    FileInfo file3 = new FileInfo("transfere.txt");
                    FileInfo file4 = new FileInfo("divergencias.txt");
                    FileInfo file5 = new FileInfo("totcanal.txt");

                    string fullFile1 = file1.FullName;
                    string fullFile2 = file2.FullName;
                    string fullFile3 = file3.FullName;
                    string fullFile4 = file4.FullName;
                    string fullFile5 = file5.FullName;

                    /* Leitura dos produtos */

                    StreamReader produtos = new StreamReader(@fullFile1);

                    line1 = produtos.ReadLine();

                    int qtvendas = 0;
                    
                    /* Lista de armazenamentos */

                    /* Lista de armazenamento dos transferes */

                    List<string> codigos_produtos = new List<string>();
                    List<string> estoque_produtos = new List<string>();
                    List<string> minimo_produtos = new List<string>();
                    List<string> qtvendas_produtos = new List<string>();
                    List<string> apos_vendas_produtos = new List<string>();
                    List<string> necessidade_produtos = new List<string>();
                    List<string> transferencia_produtos = new List<string>();

                    int LL = 1;

                    while (line1 != null) {

                        string[] dados_produtos = line1.Split(';');
                        int codigo1 = int.Parse(dados_produtos[0]);
                        int estoque = int.Parse(dados_produtos[1]);
                        int minimo = int.Parse(dados_produtos[2]);
                        if (codigo1 > 9999 && codigo1 < 100000 && estoque >= minimo) {

                        /* Leitura das vendas */

                        StreamReader vendas = new StreamReader(@fullFile2);

                        line2 = vendas.ReadLine();

                        while(line2 != null) {

                            string[] dados_vendas = line2.Split(';');
                            int codigo2 = int.Parse(dados_vendas[0]);
                            int dvendas = int.Parse(dados_vendas[1]);
                            int situacao = int.Parse(dados_vendas[2]);
                            int canal = int.Parse(dados_vendas[3]);

                            if(codigo1 == codigo2 && (situacao == 100 || situacao == 102)) {
                                qtvendas = qtvendas + dvendas;
                            }



                        line2 = vendas.ReadLine();



                        }

                        int apos_vendas = estoque - qtvendas;

                        int necessidade = minimo - apos_vendas;

                        int transferencia = 0;

                        if(necessidade < 0) {
                            necessidade = necessidade * 0;
                        }

                        if(necessidade >= 1 && necessidade <=10) {
                            transferencia = 10;
                        } else {
                            transferencia = necessidade;
                        }

                        /* Adição dos produtos nas listas */

                        string caractere_codigo1 = Convert.ToString(codigo1);
                        string caractere_estoque = Convert.ToString(estoque);
                        string caractere_minimo = Convert.ToString(minimo);
                        string caractere_qtvendas = Convert.ToString(qtvendas);
                        string caractere_apos_vendas = Convert.ToString(apos_vendas);
                        string caractere_necessidade = Convert.ToString(necessidade);
                        string caractere_transferencia = Convert.ToString(transferencia);
                        

                        if(!codigos_produtos.Contains(caractere_codigo1)) {
                            
                            codigos_produtos.Add(caractere_codigo1);
                            estoque_produtos.Add(caractere_estoque);
                            minimo_produtos.Add(caractere_minimo);
                            qtvendas_produtos.Add(caractere_qtvendas);
                            apos_vendas_produtos.Add(caractere_apos_vendas);
                            necessidade_produtos.Add(caractere_necessidade);
                            transferencia_produtos.Add(caractere_transferencia);

                        } else {

                            Console.Write("O produto {0} já foi cadastrado", caractere_codigo1);

                        }

                        qtvendas = qtvendas*0;

                        vendas.Close();

                    }

                    if(codigo1 < 9999 || codigo1 > 100000) {

                        Console.WriteLine("Somente 5 digitos é permitido\nO produto {0} não é válido\r\n", codigo1);

                    }

                    if(estoque < minimo) {

                        Console.WriteLine("A quantidade no estoque não pode ser menor que a quantidade mínima\nNo produto {0} a quantidade no estoque é menor que a quantidade mínima\r\n", codigo1);

                    }

                        line1 = produtos.ReadLine();

                    }

/* Distancias */

    /* Codigo */

    /* Estoque */
                    int estoque_qtespaco_fixo = 0;

                    int quantidade_caracteres = 0;

                    foreach(string e in estoque_produtos) {

                        quantidade_caracteres = e.Length;

                        if(quantidade_caracteres > estoque_qtespaco_fixo) {

                            estoque_qtespaco_fixo = quantidade_caracteres;

                        }
                    }

                    if(estoque_qtespaco_fixo < 4) {

                        estoque_qtespaco_fixo = 4;

                    }

                    
    /* Minimo */

                    int minimo_qtespaco_fixo = 0;

                    foreach(string m in minimo_produtos) {

                        quantidade_caracteres = m.Length;

                        if(quantidade_caracteres > minimo_qtespaco_fixo) {

                            minimo_qtespaco_fixo = quantidade_caracteres;

                        }
                    }

                    if(minimo_qtespaco_fixo < 5) {

                        minimo_qtespaco_fixo = 5;

                    }

    /* qtVendas */

                    int qtvendas_qtespaco_fixo = 0;

                    foreach(string qtv in qtvendas_produtos) {

                        quantidade_caracteres = qtv.Length;

                        if(quantidade_caracteres > qtvendas_qtespaco_fixo) {

                            qtvendas_qtespaco_fixo = quantidade_caracteres;

                        }
                    }

                    if(qtvendas_qtespaco_fixo < 8) {

                        qtvendas_qtespaco_fixo = 8;

                    }

    /* Estoque.Apos.Vendas */

                    int apos_vendas_qtespaco_fixo = 0;

                    foreach(string eav in apos_vendas_produtos) {

                        quantidade_caracteres = eav.Length;

                        if(quantidade_caracteres > apos_vendas_qtespaco_fixo) {

                            apos_vendas_qtespaco_fixo = quantidade_caracteres;

                        }
                    }

                    if(apos_vendas_qtespaco_fixo < 16) {

                        apos_vendas_qtespaco_fixo = 16;

                    }
    /* Necessidade */

                    int necessidade_qtespaco_fixo = 0;

                    foreach(string n in necessidade_produtos) {

                        quantidade_caracteres = n.Length;

                        if(quantidade_caracteres > necessidade_qtespaco_fixo) {

                            necessidade_qtespaco_fixo = quantidade_caracteres;

                        }
                    }

                    if(necessidade_qtespaco_fixo < 7) {

                        necessidade_qtespaco_fixo = 7;

                    }

    /* Transferencia */

                    int transferencia_qtespaco_fixo = 0;

                    foreach(string t in transferencia_produtos) {

                        quantidade_caracteres = t.Length;

                        if(quantidade_caracteres > transferencia_qtespaco_fixo) {

                            transferencia_qtespaco_fixo = quantidade_caracteres;
                        }
                    }

                    if(transferencia_qtespaco_fixo < 20) {

                        transferencia_qtespaco_fixo = 20;
                    }

                    /* espacamento_das_informacoes */

                    string espaco_info_estoque = "";
                    string espaco_info_minimo = "";
                    string espaco_info_qtvendas = "";
                    string espaco_info_apos_vendas = "";
                    string espaco_info_necessidade = "";
                    string espaco_info_transferencia = "";

                    string info_estoque = "QtCO";
                    string info_minimo = "QtMin";
                    string info_qtvendas = "Qtvendas";
                    string info_apos_vendas = "Estq.após Vendas";
                    string info_necessidade = "Necess.";
                    string info_transferencia = "transf. de Arm p/ CO";

                    int numero_espaco_info_estoque = estoque_qtespaco_fixo - info_estoque.Length;

                    for(int e = 0 ; e < numero_espaco_info_estoque; e++) {
                        
                        espaco_info_estoque = espaco_info_estoque.Insert(0, " ");
                    }

                    int numero_espaco_info_minimo = minimo_qtespaco_fixo - info_minimo.Length;

                    for(int m = 0 ; m < numero_espaco_info_minimo; m++) {
                        
                        espaco_info_minimo = espaco_info_minimo.Insert(0, " ");
                    }

                    int numero_espaco_info_qtvendas = qtvendas_qtespaco_fixo - info_qtvendas.Length;

                    for(int qtv = 0 ; qtv < numero_espaco_info_qtvendas; qtv++) {
                        
                        espaco_info_qtvendas = espaco_info_qtvendas.Insert(0, " ");
                    }

                    int numero_espaco_info_apos_vendas = apos_vendas_qtespaco_fixo - info_apos_vendas.Length;

                    for(int qtv = 0 ; qtv < numero_espaco_info_apos_vendas; qtv++) {
                        
                        espaco_info_apos_vendas = espaco_info_apos_vendas.Insert(0, " ");
                    }

                    int numero_espaco_info_necessidade = necessidade_qtespaco_fixo - info_necessidade.Length;

                    for(int qtv = 0 ; qtv < numero_espaco_info_necessidade; qtv++) {
                        
                        espaco_info_necessidade = espaco_info_necessidade.Insert(0, " ");
                    }

                    int numero_espaco_info_transferencia = transferencia_qtespaco_fixo - info_transferencia.Length;

                    for(int qtv = 0 ; qtv < numero_espaco_info_transferencia; qtv++) {
                        
                        espaco_info_transferencia = espaco_info_transferencia.Insert(0, " ");
                    }

                    string filePath_transfere_unico=(@fullFile3);

                    using (StreamWriter transfere_unico = File.AppendText(filePath_transfere_unico))
                        {
                            transfere_unico.WriteLine("Necessidade de Transferência Armazém para CO\r\n");

                            transfere_unico.WriteLine("Produto      QtCO" + espaco_info_estoque + "      QtMin" + espaco_info_minimo + "      Qtvendas" + espaco_info_qtvendas + "      Estq.após Vendas" + espaco_info_apos_vendas + "      Necess." + espaco_info_necessidade + "      transf. de Arm p/ CO" + espaco_info_transferencia + "\r\n");

                            transfere_unico.Close();
                        }

                    int posicao_tranfere = 0;
                    
                    while(posicao_tranfere < codigos_produtos.Count) {

                        /* contas */

                        string espaco_extra_estoque = "";
                        string espaco_extra_minimo = "";
                        string espaco_extra_qtvendas = "";
                        string espaco_extra_apos_vendas = "";
                        string espaco_extra_necessidade = "";
                        string espaco_extra_transferencia = "";

                        /* estoque */

                        string posicao_estoque = estoque_produtos[posicao_tranfere];

                        int numero_espaco_extra_estoque = estoque_qtespaco_fixo - posicao_estoque.Length;

                        for(int e = 0; e < numero_espaco_extra_estoque; e++) {

                            espaco_extra_estoque = espaco_extra_estoque.Insert(0, " ");

                        }

                        /* minimo */

                        string posicao_minimo = minimo_produtos[posicao_tranfere];

                        int numero_espaco_extra_minimo = minimo_qtespaco_fixo - posicao_minimo.Length;

                        for(int m = 0; m < numero_espaco_extra_minimo; m++) {

                            espaco_extra_minimo = espaco_extra_minimo.Insert(0, " ");

                        }

                        /* qtvendas */

                        string posicao_qtvendas = qtvendas_produtos[posicao_tranfere];

                        int numero_espaco_extra_qtvendas = qtvendas_qtespaco_fixo - posicao_qtvendas.Length;

                        for(int qtv = 0; qtv < numero_espaco_extra_qtvendas; qtv++) {

                            espaco_extra_qtvendas = espaco_extra_qtvendas.Insert(0, " ");

                        }

                        /* apos.vendas */

                        string posicao_apos_vendas = apos_vendas_produtos[posicao_tranfere];

                        int numero_espaco_extra_apos_vendas = apos_vendas_qtespaco_fixo - posicao_apos_vendas.Length;

                        for(int eav = 0; eav < numero_espaco_extra_apos_vendas; eav++) {

                            espaco_extra_apos_vendas = espaco_extra_apos_vendas.Insert(0, " ");

                        }

                        /* necessidade */

                        string posicao_necessidade = necessidade_produtos[posicao_tranfere];

                        int numero_espaco_extra_necessidade = necessidade_qtespaco_fixo - posicao_necessidade.Length;

                        for(int n = 0; n < numero_espaco_extra_necessidade; n++) {

                            espaco_extra_necessidade = espaco_extra_necessidade.Insert(0, " ");

                        }

                        /* transferencia */

                        string posicao_transferencia = transferencia_produtos[posicao_tranfere];

                        int numero_espaco_extra_transferencia = transferencia_qtespaco_fixo - posicao_transferencia.Length;

                        for(int t = 0; t < numero_espaco_extra_transferencia; t++) {

                            espaco_extra_transferencia = espaco_extra_transferencia.Insert(0, " ");

                        }

                        /* imprimir o transfere */
                        
                        string filePath_transfere=(@fullFile3);

                        using (StreamWriter transfere = File.AppendText(filePath_transfere))
                        {
                            transfere.WriteLine(codigos_produtos[posicao_tranfere] + "        " + estoque_produtos[posicao_tranfere] + espaco_extra_estoque + "      " + minimo_produtos[posicao_tranfere] + espaco_extra_minimo + "      " + qtvendas_produtos[posicao_tranfere] + espaco_extra_qtvendas + "      " + apos_vendas_produtos[posicao_tranfere] + espaco_extra_apos_vendas + "      " + necessidade_produtos[posicao_tranfere] + espaco_extra_necessidade + "      " + transferencia_produtos[posicao_tranfere] + espaco_extra_transferencia);

                            transfere.Close();
                        }

                        posicao_tranfere++;

                    }   

                        /* variáveis das vendas por canal */

                        int vendas_canal_1 = 0;
                        int vendas_canal_2 = 0;
                        int vendas_canal_3 = 0;
                        int vendas_canal_4 = 0;

                        /* releitura das vendas */

                        StreamReader releitura_vendas = new StreamReader(@fullFile2);

                        string filePath_divergencias=(@fullFile4);

                        line2 = releitura_vendas.ReadLine();

                        while(line2 != null) {
                            string[] dados_vendas = line2.Split(';');
                            string codigo2 = (dados_vendas[0]);
                            int dvendas = int.Parse(dados_vendas[1]);
                            int situacao = int.Parse(dados_vendas[2]);
                            int canal = int.Parse(dados_vendas[3]);
                        
                            if(situacao == 135) {
                        
                                using (StreamWriter divergencias = File.AppendText(filePath_divergencias))
                                {
                                    divergencias.WriteLine("Linha {0} - Venda cancelada", LL);

                                    divergencias.Close();
                                }
                            } else if (situacao == 190) {

                                using (StreamWriter divergencias = File.AppendText(filePath_divergencias))
                                {
                                    divergencias.WriteLine("Linha {0} - Venda não finalizada", LL);

                                    divergencias.Close();
                                }

                            } else if (situacao == 999) {

                                using (StreamWriter divergencias = File.AppendText(filePath_divergencias))
                                {
                                    divergencias.WriteLine("Linha {0} - Erro desconhecido. Acionar equipe de TI", LL);

                                    divergencias.Close();
                                }

                            } else if (!codigos_produtos.Contains(codigo2)) {
                                using (StreamWriter divergencias = File.AppendText(filePath_divergencias))
                                {
                                    divergencias.WriteLine("Linha {0} - Código de Produto não encontrado {1}",LL ,codigo2);

                                    divergencias.Close();
                                }
                            }   

                                /* vendas por canal */
                                
                                if(situacao == 100 || situacao == 102) {
                                    if(canal == 1) {

                                        vendas_canal_1 = vendas_canal_1 + dvendas;

                                    } else if(canal == 2) {

                                    vendas_canal_2 = vendas_canal_2 + dvendas;
                                    
                                    } else if(canal == 3) {

                                    vendas_canal_3 = vendas_canal_3 + dvendas;
                                    
                                    } else if(canal == 4) {

                                    vendas_canal_4 = vendas_canal_4 + dvendas;
                                    
                                    }
                                }

                        LL = LL + 1;
                            
                        
                        line2 = releitura_vendas.ReadLine();
                        }

                                string filePath_totcanal=(@fullFile5);

                            using (StreamWriter totcanal = File.AppendText(filePath_totcanal))
                            
                        {
                            totcanal.WriteLine("Quantidades de Vendas por canal\r\n");
                            totcanal.WriteLine("Canal                  QtVendas");
                            totcanal.WriteLine("1 - Representantes" + "     "+ vendas_canal_1);
                            totcanal.WriteLine("2 - Website" + "            " + vendas_canal_2);
                            totcanal.WriteLine("3 - App móvel Android" + "  " + vendas_canal_3);
                            totcanal.WriteLine("4 - App móvel iPhone" + "   " + vendas_canal_4);
                            totcanal.Close();
                        }

                    produtos.Close();
                    releitura_vendas.Close();

                    Console.ReadLine();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
        }
    }
}
