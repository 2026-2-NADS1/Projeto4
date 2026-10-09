String linha;
bool conversaoOk;

Console.WriteLine("Digite seu nickname:");
String nickname = Console.ReadLine();
if (nickname == null || nickname == "") {
    Console.WriteLine("ERRO na entrada 1 (nickname): dado ausente (ou fim do arquivo).");
    Environment.Exit(1);
}

Console.WriteLine("Digite faixa etaria:");
linha = Console.ReadLine();
int faixaEtaria;
conversaoOk = int.TryParse(linha, out faixaEtaria);
if(!conversaoOk) {
    Console.WriteLine("ERRO na entrada 2 (faixa etaria): dado ausente/inválido (ou fim do arquivo).");
    Environment.Exit(1);
}
if(faixaEtaria < 1 || faixaEtaria > 6) {
    Console.WriteLine("ERRO na entrada 2 (faixa etaria): faixa inválida.");
    Environment.Exit(1);    
}

String nomeFaixa = "Até 12 anos";
if(faixaEtaria == 2) {
    nomeFaixa = "13 a 17 anos";
}
if(faixaEtaria == 3) {
    nomeFaixa = "18 a 24 anos";
}
if(faixaEtaria == 4) {
    nomeFaixa = "25 a 39 anos";
}
if (faixaEtaria == 5) {
    nomeFaixa = "40 anos ou mais";
}
if (faixaEtaria == 6) {
    nomeFaixa = "Prefiro não informar";
}

Console.WriteLine("Digite o total de questões fáceis:");
linha = Console.ReadLine();
int qFaceis;
conversaoOk = int.TryParse(linha, out qFaceis);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 3 (questões fáceis): valor mal formado.");
    Environment.Exit(1);
}
if (qFaceis < 0) {
    Console.WriteLine("ERRO na entrada 3 (questões fáceis): valor deve ser zero ou maior.");
    Environment.Exit(1);
}

Console.WriteLine("Digite os acertos nas fáceis:");
linha = Console.ReadLine();
int aFaceis;
conversaoOk = int.TryParse(linha, out aFaceis);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 4 (acertos fáceis): valor mal formado.");
    Environment.Exit(1);
}
if (aFaceis < 0 || aFaceis > qFaceis) {
    Console.WriteLine("ERRO na entrada 4 (acertos fáceis): valor maior que o total de questões fáceis.");
    Environment.Exit(1);
}

Console.WriteLine("Digite o total de questões médias:");
linha = Console.ReadLine();
int qMedias;
conversaoOk = int.TryParse(linha, out qMedias);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 5 (questões médias): valor mal formado.");
    Environment.Exit(1);
}
if (qMedias < 0) {
    Console.WriteLine("ERRO na entrada 5 (questões médias): valor deve ser zero ou maior.");
    Environment.Exit(1);
}

Console.WriteLine("Digite os acertos nas médias:");
linha = Console.ReadLine();
int aMedias;
conversaoOk = int.TryParse(linha, out aMedias);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 6 (acertos médios): valor mal formado.");
    Environment.Exit(1);
}
if (aMedias < 0 || aMedias > qMedias) {
    Console.WriteLine("ERRO na entrada 6 (acertos médios): valor maior que o total de questões médias.");
    Environment.Exit(1);
}

Console.WriteLine("Digite o total de questões difíceis:");
linha = Console.ReadLine();
int qDificeis;
conversaoOk = int.TryParse(linha, out qDificeis);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 7 (questões difíceis): valor mal formado.");
    Environment.Exit(1);
}
if (qDificeis < 0) {
    Console.WriteLine("ERRO na entrada 7 (questões difíceis): valor deve ser zero ou maior.");
    Environment.Exit(1);
}

int totalQuestoes = qFaceis + qMedias + qDificeis;
if (totalQuestoes < 1) {
    Console.WriteLine("ERRO na entrada 7 (questões difíceis): a partida precisa ter pelo menos 1 questão.");
    Environment.Exit(1);
}

Console.WriteLine("Digite os acertos nas difíceis:");
linha = Console.ReadLine();
int aDificeis;
conversaoOk = int.TryParse(linha, out aDificeis);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 8 (acertos difíceis): valor mal formado.");
    Environment.Exit(1);
}
if (aDificeis < 0 || aDificeis > qDificeis) {
    Console.WriteLine("ERRO na entrada 8 (acertos difíceis): valor maior que o total de questões difíceis.");
    Environment.Exit(1);
}

Console.WriteLine("Digite o tempo total (em segundos):");
linha = Console.ReadLine();
int tempo;
conversaoOk = int.TryParse(linha, out tempo);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 9 (tempo): valor mal formado.");
    Environment.Exit(1);
}
if (tempo <= 0) {
    Console.WriteLine("ERRO na entrada 9 (tempo): valor deve ser maior que zero.");
    Environment.Exit(1);
}


Console.WriteLine("Digite a quantidade de dicas usadas:");
linha = Console.ReadLine();
int dicas;
conversaoOk = int.TryParse(linha, out dicas);
if (!conversaoOk) {
    Console.WriteLine("ERRO na entrada 10 (dicas): valor mal formado.");
    Environment.Exit(1);
}
if (dicas < 0 || dicas > totalQuestoes) {
    Console.WriteLine("ERRO na entrada 10 (dicas): valor maior que o total de questões.");
    Environment.Exit(1);
}

int totalAcertos = aFaceis + aMedias + aDificeis;
int totalErros = totalQuestoes - totalAcertos;
double pctGeral = totalAcertos * 100.0 / totalQuestoes;

double pctFaceis = 0.0;
if (qFaceis > 0) {
    pctFaceis = aFaceis * 100.0 / qFaceis;
}

double pctMedias = 0.0;
if (qMedias > 0) {
    pctMedias = aMedias * 100.0 / qMedias;
}

double pctDificeis = 0.0;
if (qDificeis > 0) {
    pctDificeis = aDificeis * 100.0 / qDificeis;
}

int pontuacaoMaxima = (qFaceis * 10) + (qMedias * 20) + (qDificeis * 30);
int penalidadeDicas = dicas * 5;
int pontuacao = (aFaceis * 10) + (aMedias * 20) + (aDificeis * 30) - penalidadeDicas;

if (pontuacao < 0) {
    pontuacao = 0;
}

double pctPontuacao = 0.0;
if (pontuacaoMaxima > 0) {
    pctPontuacao = pontuacao * 100.0 / pontuacaoMaxima;
}

int minutos = tempo / 60;
int segundosRestantes = tempo % 60;
double tempoMedio = tempo * 1.0 / totalQuestoes;

String classificacao = "Iniciante";
if (pctGeral >= 90.0) {
    classificacao = "Mestre das Marcas";
} else if (pctGeral >= 70.0) {
    classificacao = "Conhecedor de Marcas";
} else if (pctGeral >= 50.0) {
    classificacao = "Aprendiz";
}

String ritmo = "Pausado";
if (tempoMedio <= 10.0) {
    ritmo = "Rápido";
} else if (tempoMedio <= 20.0) {
    ritmo = "Normal";
}

String melhorNivel = "Nenhum";
double maiorPct = -1.0;

if (qFaceis > 0) {
    maiorPct = pctFaceis;
    melhorNivel = "Fácil";
}

if (qMedias > 0 && pctMedias >= maiorPct) {
    maiorPct = pctMedias;
    melhorNivel = "Médio";
}

if (qDificeis > 0 && pctDificeis >= maiorPct) {
    maiorPct = pctDificeis;
    melhorNivel = "Difícil";
}

String astFaceis = "";
for (int i = 0; i < aFaceis; i++) {
    astFaceis = astFaceis + "*";
}

String astMedias = "";
for (int i = 0; i < aMedias; i++) {
    astMedias = astMedias + "*";
}

String astDificeis = "";
for (int i = 0; i < aDificeis; i++) {
    astDificeis = astDificeis + "*";
}

Console.WriteLine("===== ARCOR – DESAFIO DAS MARCAS: RESUMO DA PARTIDA =====");
Console.WriteLine("Jogador: " + nickname);
Console.WriteLine("Faixa etária: " + nomeFaixa);
Console.WriteLine("Desempenho por nível:");

if (qFaceis > 0) {
    Console.WriteLine($"  Fácil ({aFaceis}/{qFaceis}) {pctFaceis:F1}% {astFaceis}");
} else {
    Console.WriteLine("  Fácil (0/0) não jogado");
}

if (qMedias > 0) {
    Console.WriteLine($"  Médio ({aMedias}/{qMedias}) {pctMedias:F1}% {astMedias}");
} else {
    Console.WriteLine("  Médio (0/0) não jogado");
}

if (qDificeis > 0) {
    Console.WriteLine($"  Difícil ({aDificeis}/{qDificeis}) {pctDificeis:F1}% {astDificeis}");
} else {
    Console.WriteLine("  Difícil (0/0) não jogado");
}

Console.WriteLine($"Total: {totalAcertos} acertos e {totalErros} erros em {totalQuestoes} questões ({pctGeral:F1}%)");
Console.WriteLine($"Pontuação: {pontuacao} de {pontuacaoMaxima} pontos possíveis ({pctPontuacao:F1}%)");
Console.WriteLine($"Dicas usadas: {dicas} (penalidade de {penalidadeDicas} pontos)");
Console.WriteLine($"Tempo total: {minutos} min {segundosRestantes} s | Média: {tempoMedio:F1} s por questão");
Console.WriteLine($"Ritmo: {ritmo}");
Console.WriteLine($"Melhor nível: {melhorNivel}");
Console.WriteLine($"Classificação: {classificacao}");
Console.WriteLine("=========================================================");