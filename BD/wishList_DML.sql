USE WISH_LIST;
GO

INSERT INTO usuario (email, senha)
VALUES ('samuel@gmail.com','12345678'),
	   ('murillo@gmail.com','12345678'),
	   ('isabelle@gmail.com','12345678'),
	   ('felipe@gmail.com','12345678');
GO

INSERT INTO desejo (idUsuario,titulo, descricao)
VALUES (1, 'Ser um bom profissional na área de TI', 'Eu quero ser um profissional de muito sucesso na área de TI');
GO