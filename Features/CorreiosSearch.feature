Feature: Testes dos Correios
    Como usuário do site dos Correios
    Quero verificar o CEP e o rastreamento de código
    Para garantir que as funcionalidades estão corretas

Scenario: Verificação de CEPs e Rastreamento de Código
    Given que eu entre no site dos Correios
    When eu procurar pelo CEP "80700000"
    Then eu confirmo que o CEP não existe
    And eu volto para a tela inicial
    When eu procurar pelo CEP "01013-001"
    Then eu confirmo que o resultado seja "Rua Quinze de Novembro, São Paulo/SP"
    And eu volto para a tela inicial
    When eu procurar no rastreamento de código o número "SS987654321BR"
    Then eu confirmo que o código não está correto
    And eu fecho o browser