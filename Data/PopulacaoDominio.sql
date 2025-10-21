INSERT INTO AcomodacoesStatus VALUES ('Disponivel'), ('Indisponivel'), ('Reforma')
INSERT INTO FormasPagamentos VALUES ('Dinheiro'), ('Debito'), ('Credito')
INSERT INTO FuncionariosCargos VALUES ('Diretor'),('GerenteDepartamento'),('Recepcionista'),('Camareira'),('Limpeza'),('Cozinha')
INSERT INTO FuncionariosNiveisAcessos VALUES ('Administrador'),('Usuario'),('Leitura'),('Edicao')
INSERT INTO FuncionariosStatus VALUES ('Disponivel'),('Indisponivel'),('Bloqueado')
INSERT INTO ProdutosTipos VALUES ('Comida'),('Bebida')

INSERT INTO Funcionarios VALUES (2),(1),('Thales'),('70859746488'),('83987168348'),(04/25/2002)

INSERT INTO Funcionarios (IdCargo, IdStatus, Nome, Cpf, Telefone, DataAdmissao)
VALUES (1, 1, 'João da Silva', '12345678901', '83999887766', '2023-10-26');

select * from funcionarios
