# EcoSmart - Projeto de Monitoramento de Energia

## Nosso Projeto
Desenvolvemos o EcoSmart para a disciplina de Enterprise Application Development da FIAP. É um sistema que ajuda as pessoas a controlarem melhor seu gasto de energia usando tecnologias modernas como IA.

## O que nosso sistema faz
- Monitora quanto de energia cada aparelho está gastando
- Avisa quando o consumo está muito alto
- Dá dicas de como economizar energia
- Mostra previsões de quanto você vai gastar
- Conecta com aparelhos inteligentes da casa

## Como fizemos
Usamos várias tecnologias que aprendemos nas aulas:
- .NET 8.0 para fazer a API
- Banco de dados Oracle para guardar as informações
- IA para fazer as previsões
- JWT para segurança dos usuários

## Partes principais do sistema
1. Área do Usuário
   - Login/Cadastro
   - Ver seus aparelhos
   - Histórico de consumo

2. Controle de Aparelhos
   - Adicionar novos aparelhos
   - Ver consumo de cada um
   - Receber alertas

3. Previsões e Dicas
   - Previsão do próximo mês
   - Dicas personalizadas
   - Alertas de consumo alto

## Como usar
1. Configure o banco de dados:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "User Id=rm98866;Password=010804;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)))"
  }
}
```

2. Rode os comandos no Visual Studio:
```
Add-Migration InitialCreate
Update-Database
```

3. Inicie o projeto e use o Swagger para testar

## APIs principais
- /api/users - para usuários
- /api/devices - para aparelhos
- /api/consumption - para consumo
- /api/predictions - para previsões

## Segurança
- Login com JWT
- Senhas criptografadas
- Proteção dos dados

---
FIAP 2024
