import sys
import os


def handle_args(args):
    #aqui pode usar também isso
    #return args.replace("..", ".")
    ##caso o nome da pasta tenha pontos achei melhor colocar assim
    if args[0]=="." and args[1]==".":
        return args[1:]
    else:
        return args

def handle_file(file):
    
    return os.path.dirname(file)


def handle_path(txt):
    #perceba que aqui usa absoluto path logo vai ficar nas mesmas localização do exe. 
    return os.path.abspath(txt)

# função para formatar os aquivos


def toArray(arquivo):
    lista = []
    for linha in arquivo:
        valor = linha.split(";")
        x = len(valor)-1
        if "\n" in valor[x]:
            valor[x] = valor[x].replace("\n", "")
        lista.append(valor)
    return lista

# Função para calcular os meios


def vendasCanais(sales):
    canal = {1: 0, 2: 0, 3: 0, 4: 0}
    for dado in sales:
        if dado[2] == "100" or dado[2] == "102":
            num = int(dado[3])
            canal[num] = canal.get(num)+int(dado[1])
    return canal

# Função para mostrar meios


def mostrarCanais(canal):
    print("Quantidades de Vendas por canal\n")
    print("1 - Representantes		{}".format(canal.get(1)))
    print("2 - Website			{}".format(canal.get(2)))
    print("3 - App móvel Android		{}".format(canal.get(3)))
    print("4 - App móvel iPhone		{}".format(canal.get(4)))

# função para salvar os canais


def salvarCanais(canal, file):
    name = handle_file(file)
    filename = name+"/TOTCANAIS.txt"
    arquivo = open(filename, "w")
    arquivo.write("Quantidades de Vendas por canal\n\n")
    arquivo.write("1 - Representantes		{}\n".format(canal.get(1)))
    arquivo.write("2 - Website			{}\n".format(canal.get(2)))
    arquivo.write("3 - App móvel Android		{}\n".format(canal.get(3)))
    arquivo.write("4 - App móvel iPhone		{}\n".format(canal.get(4)))
    arquivo.close()
    return name

# carrega e já transforma arquivo


def loadData(file):
    arquivo = open(file, "r")
    data = toArray(arquivo)
    arquivo.close()
    return data

# verifica se tem o produto na lista


def isProduct(cod, products):
    for i in products:
        if i[0] == cod:
            return True
    return False

# procura por divergencias


def searchError(products, sales, name):
    filename = name+"/DIVERGENCIAS.txt"
    arquivo = open(filename, "w")
    linha = 1
    for item in sales:
        if not isProduct(item[0], products) and int(item[2]) not in [135, 190, 999]:
            arquivo.write(
                "Linha {} – Código de Produto não encontrado {}\n".format(linha, item[0]))
        if int(item[2]) == 135:
            arquivo.write("Linha {} – Venda cancelada\n".format(linha))
        if int(item[2]) == 190:
            arquivo.write("Linha {} – Venda não finalizada\n".format(linha))
        if int(item[2]) == 999:
            arquivo.write(
                "Linha {} – Erro desconhecido. Acionar equipe de TI\n".format(linha))
        if linha != len(sales):
            linha += 1
    arquivo.close()
    return True

# calcular as vendas


def calcSales(cod, sales):
    vendas = 0
    for item in sales:
        if item[0] == cod and int(item[2]) in [102, 100]:
            vendas += int(item[1])
    return vendas

# calcula as necessidades e salvar no transfere


def vendasProjeto(products, sales, name):
    filename = name+"/transfere.txt"
    arquivo = open(filename, "w")
    arquivo.write("Necessidade de Transferência Armazém para CO\n\n")
    arquivo.write("Produto	QtCO	QtMin	QtVendas	Estq.após	Necess.	Transf. de\n")
    arquivo.write("					Vendas			Arm p/ CO\n")
    for item in products:
        vendidos = calcSales(item[0], sales)
        estoque = int(item[1])-vendidos
        transf = 0
        if estoque < int(item[2]):
            reposicao = int(item[2])-estoque
            if reposicao > 1 and reposicao < 10:
                transf = 10
            else:
                transf = reposicao
        else:
            reposicao = 0
        arquivo.write("{}	{}	{}	{}		{}		{}		{}\n".format(
            item[0], item[1], item[2], vendidos, estoque, reposicao, transf))
    arquivo.close()
    return True


def main(file, file1):
    products = loadData(file1)
    sales = loadData(file)
    canal = vendasCanais(sales)
    # mostrarCanais(canal)
    name = salvarCanais(canal, file)
    searchError(products, sales, name)
    vendasProjeto(products, sales, name)
    return 0


if __name__ == "__main__":
    #Deixei assim porque pede para ler da forma arquivo.exe "file1" "file2"
    #Como tem dois  '..' inves de somente um '.' no windows tive que substituir.
    #Se o nome do diretorio tiver dois '..' irá da erro de exception FileNotfound porque irá substituir os '..' para somente '.'
    txt = handle_args(sys.argv[1])
    txt1 = handle_args(sys.argv[2])
    file = handle_path(txt)
    file1 = handle_path(txt1)
    main(file, file1)
