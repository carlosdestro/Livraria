Como rodar o sistema Livraria:

- clone o repositório a partir de https://github.com/carlosdestro/Livraria
- no SQL Server Management Studio rode o script CreateDataBase.sql para criar o banco de dados e inserir os dados iniciais
- dê permissão de owner para o usuário do iis ao banco Livraria que recém foi criado:
	vá em object explorer, expanda security, expanda logins
	clique direito no usuáro do iis (no meu caso IIS APPPOOL\localhost.com) e vá em propriedades
	clique em user mapping e no painel superior direito marque o banco Livraria, depois no painel inferior marque db_owner e dê OK

- abra o visual Studio 2017 como administrador e abra projeto recém clonado.
- em solution explorer clique direito no projeto Livraria e clique em propriedades
- na aba recém aberta clique em web
- na seção servers selecione Local iis no dropdown.
- em project url defina a url local (no meu caso http://localhost.com/Livraria) e clique em Create Virtual Directory
- salve as alterações
- pressione f5 para rodar o projeto em modo debug