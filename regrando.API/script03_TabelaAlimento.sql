﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_AGUAS] (
    [IdAgua] int NOT NULL IDENTITY,
    [HrAgua] time NULL,
    [QtdAgua] int NULL,
    CONSTRAINT [PK_TB_AGUAS] PRIMARY KEY ([IdAgua])
);
GO

CREATE TABLE [TB_REFEICOES] (
    [IdRefeicao] int NOT NULL IDENTITY,
    [IdUsuario] int NOT NULL,
    [IdAlimento] int NOT NULL,
    [TpRefeicao] varchar(200) NOT NULL,
    [HrRefeicao] time NULL,
    CONSTRAINT [PK_TB_REFEICOES] PRIMARY KEY ([IdRefeicao])
);
GO

CREATE TABLE [TB_USUARIO] (
    [IdUsuario] int NOT NULL IDENTITY,
    [Cpf] varchar(200) NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Peso] int NOT NULL,
    [Altura] float NOT NULL,
    [Sexo] varchar(200) NOT NULL,
    [Objetivo] int NOT NULL,
    CONSTRAINT [PK_TB_USUARIO] PRIMARY KEY ([IdUsuario])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAgua', N'HrAgua', N'QtdAgua') AND [object_id] = OBJECT_ID(N'[TB_AGUAS]'))
    SET IDENTITY_INSERT [TB_AGUAS] ON;
INSERT INTO [TB_AGUAS] ([IdAgua], [HrAgua], [QtdAgua])
VALUES (1, '08:00:00', 200),
(2, '12:00:00', 300);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAgua', N'HrAgua', N'QtdAgua') AND [object_id] = OBJECT_ID(N'[TB_AGUAS]'))
    SET IDENTITY_INSERT [TB_AGUAS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRefeicao', N'HrRefeicao', N'IdAlimento', N'IdUsuario', N'TpRefeicao') AND [object_id] = OBJECT_ID(N'[TB_REFEICOES]'))
    SET IDENTITY_INSERT [TB_REFEICOES] ON;
INSERT INTO [TB_REFEICOES] ([IdRefeicao], [HrRefeicao], [IdAlimento], [IdUsuario], [TpRefeicao])
VALUES (1, '12:00:00', 1, 1, 'Almoço'),
(2, '19:00:00', 2, 1, 'Jantar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRefeicao', N'HrRefeicao', N'IdAlimento', N'IdUsuario', N'TpRefeicao') AND [object_id] = OBJECT_ID(N'[TB_REFEICOES]'))
    SET IDENTITY_INSERT [TB_REFEICOES] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'Altura', N'Cpf', N'Nome', N'Objetivo', N'Peso', N'Sexo') AND [object_id] = OBJECT_ID(N'[TB_USUARIO]'))
    SET IDENTITY_INSERT [TB_USUARIO] ON;
INSERT INTO [TB_USUARIO] ([IdUsuario], [Altura], [Cpf], [Nome], [Objetivo], [Peso], [Sexo])
VALUES (1, 1.75E0, '123456789', 'Exemplo', 1, 70, 'Masculino');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'Altura', N'Cpf', N'Nome', N'Objetivo', N'Peso', N'Sexo') AND [object_id] = OBJECT_ID(N'[TB_USUARIO]'))
    SET IDENTITY_INSERT [TB_USUARIO] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240616161732_InitialCreate', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_ALIMENTO] (
    [IdAlimento] int NOT NULL IDENTITY,
    [NomeAlimento] varchar(200) NOT NULL,
    [Carboidratos] float NOT NULL,
    [Gorduras] float NOT NULL,
    [Proteinas] float NOT NULL,
    [Calorias] float NOT NULL,
    [Fibras] float NOT NULL,
    [Sodio] float NOT NULL,
    CONSTRAINT [PK_TB_ALIMENTO] PRIMARY KEY ([IdAlimento])
);
GO

CREATE TABLE [TB_OBJETIVO] (
    [IdObjetivo] int NOT NULL IDENTITY,
    [IdUsuario] int NOT NULL,
    [DsObjetivo] varchar(200) NOT NULL,
    [TipoObjetivo] int NOT NULL,
    CONSTRAINT [PK_TB_OBJETIVO] PRIMARY KEY ([IdObjetivo])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAlimento', N'Calorias', N'Carboidratos', N'Fibras', N'Gorduras', N'NomeAlimento', N'Proteinas', N'Sodio') AND [object_id] = OBJECT_ID(N'[TB_ALIMENTO]'))
    SET IDENTITY_INSERT [TB_ALIMENTO] ON;
INSERT INTO [TB_ALIMENTO] ([IdAlimento], [Calorias], [Carboidratos], [Fibras], [Gorduras], [NomeAlimento], [Proteinas], [Sodio])
VALUES (1, 124.0E0, 25.800000000000001E0, 0.40000000000000002E0, 0.29999999999999999E0, 'Arroz branco cozido', 2.6000000000000001E0, 1.0E0),
(2, 77.0E0, 14.5E0, 6.4000000000000004E0, 0.5E0, 'Feijão preto cozido', 5.5E0, 1.0E0),
(3, 143.0E0, 0.0E0, 0.0E0, 1.2E0, 'Carne de frango grelhada', 31.0E0, 70.0E0),
(4, 250.0E0, 0.0E0, 0.0E0, 7.7000000000000002E0, 'Carne bovina magra grelhada', 36.0E0, 60.0E0),
(5, 100.0E0, 1.0E0, 0.0E0, 1.0E0, 'Peito de peru defumado', 21.0E0, 830.0E0),
(6, 70.0E0, 0.59999999999999998E0, 0.0E0, 5.0E0, 'Ovo cozido', 6.5E0, 70.0E0),
(7, 66.0E0, 4.7000000000000002E0, 0.0E0, 3.6000000000000001E0, 'Leite integral', 3.2999999999999998E0, 42.0E0),
(8, 333.0E0, 0.69999999999999996E0, 0.0E0, 25.100000000000001E0, 'Queijo prato', 24.600000000000001E0, 618.0E0),
(9, 265.0E0, 48.0E0, 2.3999999999999999E0, 3.3999999999999999E0, 'Pão francês', 8.5999999999999996E0, 457.0E0),
(10, 717.0E0, 0.0E0, 0.0E0, 81.099999999999994E0, 'Manteiga', 0.5E0, 2.0E0),
(11, 828.0E0, 0.0E0, 0.0E0, 91.599999999999994E0, 'Azeite de oliva', 0.0E0, 2.0E0),
(12, 82.0E0, 18.5E0, 1.8E0, 0.10000000000000001E0, 'Batata inglesa cozida', 2.0E0, 2.0E0),
(13, 18.0E0, 3.8999999999999999E0, 1.2E0, 0.20000000000000001E0, 'Tomate', 0.90000000000000002E0, 5.0E0),
(14, 15.0E0, 2.8999999999999999E0, 1.3E0, 0.20000000000000001E0, 'Alface', 1.1000000000000001E0, 11.0E0),
(15, 35.0E0, 8.1999999999999993E0, 2.7999999999999998E0, 0.20000000000000001E0, 'Cenoura crua', 0.80000000000000004E0, 69.0E0),
(16, 105.0E0, 27.0E0, 3.1000000000000001E0, 0.29999999999999999E0, 'Banana', 1.3E0, 1.0E0),
(17, 52.0E0, 14.0E0, 2.3999999999999999E0, 0.5E0, 'Maçã', 0.29999999999999999E0, 1.0E0),
(18, 47.0E0, 12.0E0, 2.3999999999999999E0, 0.20000000000000001E0, 'Laranja', 1.2E0, 0.0E0),
(19, 43.0E0, 11.0E0, 1.7E0, 0.10000000000000001E0, 'Mamão', 0.5E0, 8.0E0),
(20, 52.0E0, 13.1E0, 1.3999999999999999E0, 0.10000000000000001E0, 'Abacaxi', 0.5E0, 2.0E0),
(21, 30.0E0, 7.5999999999999996E0, 0.40000000000000002E0, 0.20000000000000001E0, 'Melancia', 0.59999999999999998E0, 1.0E0),
(22, 19.0E0, 3.7000000000000002E0, 1.1000000000000001E0, 0.20000000000000001E0, 'Água de coco', 0.69999999999999996E0, 23.0E0),
(23, 39.0E0, 8.1999999999999993E0, 0.5E0, 0.20000000000000001E0, 'Suco de laranja natural', 0.59999999999999998E0, 0.0E0),
(24, 2.0E0, 0.0E0, 0.0E0, 0.20000000000000001E0, 'Café preto sem açúcar', 0.5E0, 2.0E0),
(25, 1.0E0, 0.0E0, 0.0E0, 0.0E0, 'Chá verde sem açúcar', 0.0E0, 0.0E0),
(26, 48.0E0, 3.6000000000000001E0, 0.0E0, 0.10000000000000001E0, 'Iogurte natural desnatado', 4.4000000000000004E0, 39.0E0),
(27, 290.0E0, 1.5E0, 0.0E0, 20.800000000000001E0, 'Queijo minas frescal', 13.4E0, 594.0E0),
(28, 165.0E0, 0.0E0, 0.0E0, 3.6000000000000001E0, 'Peito de frango cozido', 31.0E0, 74.0E0),
(29, 127.0E0, 19.199999999999999E0, 6.5999999999999996E0, 0.69999999999999996E0, 'Feijão carioca cozido', 8.4000000000000004E0, 6.0E0),
(30, 23.0E0, 3.6000000000000001E0, 2.2000000000000002E0, 0.40000000000000002E0, 'Espinafre cozido', 2.8999999999999999E0, 24.0E0),
(31, 17.0E0, 3.6000000000000001E0, 1.3E0, 0.29999999999999999E0, 'Abobrinha cozida', 1.2E0, 1.0E0),
(32, 25.0E0, 5.9000000000000004E0, 3.0E0, 0.20000000000000001E0, 'Berinjela cozida', 1.0E0, 1.0E0),
(33, 26.0E0, 6.2000000000000002E0, 1.0E0, 0.10000000000000001E0, 'Abóbora cozida', 1.0E0, 1.0E0),
(34, 34.0E0, 6.5999999999999996E0, 2.6000000000000001E0, 0.59999999999999998E0, 'Brócolis cozido', 2.7999999999999998E0, 33.0E0),
(35, 16.0E0, 3.6000000000000001E0, 0.5E0, 0.10000000000000001E0, 'Pepino', 0.69999999999999996E0, 2.0E0),
(36, 25.0E0, 4.9000000000000004E0, 2.0E0, 0.29999999999999999E0, 'Couve-flor cozida', 1.8999999999999999E0, 30.0E0),
(37, 680.0E0, 3.2999999999999998E0, 0.0E0, 77.599999999999994E0, 'Maionese', 0.5E0, 620.0E0),
(38, 25.0E0, 6.0999999999999996E0, 2.5E0, 0.10000000000000001E0, 'Repolho cru', 1.3E0, 18.0E0),
(39, 41.0E0, 6.9000000000000004E0, 2.7999999999999998E0, 0.20000000000000001E0, 'Cenoura cozida', 0.90000000000000002E0, 69.0E0),
(40, 259.0E0, 0.0E0, 0.0E0, 10.6E0, 'Bife grelhado', 26.600000000000001E0, 60.0E0),
(41, 132.0E0, 0.0E0, 0.0E0, 0.69999999999999996E0, 'Atum em lata', 23.5E0, 360.0E0),
(42, 86.0E0, 20.100000000000001E0, 3.0E0, 0.10000000000000001E0, 'Batata doce cozida', 1.6000000000000001E0, 4.0E0);
INSERT INTO [TB_ALIMENTO] ([IdAlimento], [Calorias], [Carboidratos], [Fibras], [Gorduras], [NomeAlimento], [Proteinas], [Sodio])
VALUES (43, 111.0E0, 23.199999999999999E0, 1.8E0, 1.3999999999999999E0, 'Arroz integral cozido', 2.6000000000000001E0, 5.0E0),
(44, 120.0E0, 21.300000000000001E0, 2.7999999999999998E0, 3.6000000000000001E0, 'Quinoa cozida', 4.0999999999999996E0, 7.0E0),
(45, 389.0E0, 66.299999999999997E0, 10.6E0, 6.9000000000000004E0, 'Aveia', 11.9E0, 2.0E0),
(46, 158.0E0, 31.0E0, 3.2999999999999998E0, 1.5E0, 'Macarrão integral cozido', 5.7999999999999998E0, 2.0E0),
(47, 98.0E0, 26.300000000000001E0, 0.0E0, 0.29999999999999999E0, 'Tapioca', 0.10000000000000001E0, 1.0E0),
(48, 312.0E0, 35.399999999999999E0, 3.0E0, 19.199999999999999E0, 'Batata frita', 3.3999999999999999E0, 320.0E0),
(49, 207.0E0, 21.100000000000001E0, 0.0E0, 6.7000000000000002E0, 'Sorvete de creme', 2.7000000000000002E0, 45.0E0),
(50, 506.0E0, 57.700000000000003E0, 2.3999999999999999E0, 24.600000000000001E0, 'Biscoito recheado', 4.2000000000000002E0, 400.0E0),
(51, 453.0E0, 55.399999999999999E0, 6.2999999999999998E0, 28.399999999999999E0, 'Pipoca de micro-ondas', 8.0999999999999996E0, 1.0E0),
(52, 535.0E0, 59.700000000000003E0, 7.5E0, 30.899999999999999E0, 'Chocolate ao leite', 6.9000000000000004E0, 16.0E0),
(53, 52.0E0, 13.800000000000001E0, 2.1000000000000001E0, 0.29999999999999999E0, 'Maçã verde', 0.29999999999999999E0, 1.0E0),
(54, 69.0E0, 17.199999999999999E0, 0.90000000000000002E0, 0.20000000000000001E0, 'Uva', 0.59999999999999998E0, 1.0E0),
(55, 32.0E0, 6.7000000000000002E0, 1.6000000000000001E0, 0.40000000000000002E0, 'Morango', 0.80000000000000004E0, 1.0E0),
(56, 60.0E0, 14.800000000000001E0, 1.6000000000000001E0, 0.29999999999999999E0, 'Manga', 0.59999999999999998E0, 1.0E0),
(57, 61.0E0, 15.199999999999999E0, 3.1000000000000001E0, 0.20000000000000001E0, 'Pera', 0.40000000000000002E0, 1.0E0),
(58, 37.0E0, 9.4000000000000004E0, 0.59999999999999998E0, 0.20000000000000001E0, 'Melão', 0.59999999999999998E0, 2.0E0),
(59, 61.0E0, 14.699999999999999E0, 2.5E0, 0.59999999999999998E0, 'Kiwi', 1.1000000000000001E0, 3.0E0),
(60, 367.0E0, 77.0E0, 13.0E0, 0.40000000000000002E0, 'Goji berry', 12.0E0, 3.0E0),
(61, 655.0E0, 12.9E0, 5.0E0, 66.400000000000006E0, 'Castanha-do-pará', 14.300000000000001E0, 0.0E0),
(62, 575.0E0, 21.100000000000001E0, 12.5E0, 49.399999999999999E0, 'Amêndoa', 21.199999999999999E0, 0.0E0),
(63, 650.0E0, 16.100000000000001E0, 9.6999999999999993E0, 61.399999999999999E0, 'Avelã', 14.9E0, 0.0E0),
(64, 654.0E0, 13.0E0, 6.7000000000000002E0, 65.200000000000003E0, 'Nozes', 14.0E0, 0.0E0),
(65, 562.0E0, 27.699999999999999E0, 10.6E0, 45.399999999999999E0, 'Pistache', 20.899999999999999E0, 0.0E0),
(66, 574.0E0, 10.0E0, 6.0E0, 45.799999999999997E0, 'Semente de abóbora', 29.800000000000001E0, 0.0E0),
(67, 582.0E0, 20.0E0, 8.5999999999999996E0, 51.5E0, 'Semente de girassol', 19.300000000000001E0, 0.0E0),
(68, 235.0E0, 19.399999999999999E0, 0.90000000000000002E0, 12.800000000000001E0, 'Pão de queijo', 3.2000000000000002E0, 384.0E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdAlimento', N'Calorias', N'Carboidratos', N'Fibras', N'Gorduras', N'NomeAlimento', N'Proteinas', N'Sodio') AND [object_id] = OBJECT_ID(N'[TB_ALIMENTO]'))
    SET IDENTITY_INSERT [TB_ALIMENTO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdObjetivo', N'DsObjetivo', N'IdUsuario', N'TipoObjetivo') AND [object_id] = OBJECT_ID(N'[TB_OBJETIVO]'))
    SET IDENTITY_INSERT [TB_OBJETIVO] ON;
INSERT INTO [TB_OBJETIVO] ([IdObjetivo], [DsObjetivo], [IdUsuario], [TipoObjetivo])
VALUES (1, 'Manutenção da Saúde Geral', 1, 1),
(2, 'Ganho de Massa Muscular', 1, 2),
(3, 'Melhoria da Saúde Digestiva', 1, 3),
(4, 'Perda de Peso', 1, 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdObjetivo', N'DsObjetivo', N'IdUsuario', N'TipoObjetivo') AND [object_id] = OBJECT_ID(N'[TB_OBJETIVO]'))
    SET IDENTITY_INSERT [TB_OBJETIVO] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240616165753_NewCreate', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_CADASTRO] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Login] varchar(200) NOT NULL,
    [Senha] varchar(200) NOT NULL,
    [AceitouTermos] bit NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_TB_CADASTRO] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_CADASTRO_TB_USUARIO_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIO] ([IdUsuario]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_RECEITA] (
    [IdReceita] int NOT NULL IDENTITY,
    [NomeReceita] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Ingredientes] varchar(200) NOT NULL,
    [ModoPreparo] varchar(200) NOT NULL,
    [Calorias] int NOT NULL,
    [TempoPreparoMinutos] int NOT NULL,
    CONSTRAINT [PK_TB_RECEITA] PRIMARY KEY ([IdReceita])
);
GO

UPDATE [TB_OBJETIVO] SET [IdUsuario] = 2
WHERE [IdObjetivo] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_OBJETIVO] SET [IdUsuario] = 3
WHERE [IdObjetivo] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_OBJETIVO] SET [IdUsuario] = 4
WHERE [IdObjetivo] = 4;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdReceita', N'Calorias', N'Descricao', N'Ingredientes', N'ModoPreparo', N'NomeReceita', N'TempoPreparoMinutos') AND [object_id] = OBJECT_ID(N'[TB_RECEITA]'))
    SET IDENTITY_INSERT [TB_RECEITA] ON;
INSERT INTO [TB_RECEITA] ([IdReceita], [Calorias], [Descricao], [Ingredientes], [ModoPreparo], [NomeReceita], [TempoPreparoMinutos])
VALUES (1, 200, 'Delicioso bolo de cenoura com cobertura de chocolate', 'Cenoura, óleo, ovos, açúcar, farinha de trigo, fermento em pó, chocolate', '1. Bata no liquidificador as cenouras, óleo e ovos. 2. Adicione o açúcar e a farinha de trigo. 3. Por último, coloque o fermento e misture delicadamente. 4. Asse em forno médio por aproximadamente 40 minutos.', 'Bolo de cenoura', 40),
(2, 150, 'Salada refrescante com quinoa, tomate, pepino e temperos', 'Quinoa, tomate, pepino, azeite, limão, sal', '1. Cozinhe a quinoa conforme as instruções da embalagem. 2. Corte os tomates e pepinos em cubos. 3. Misture tudo e tempere a gosto. 4. Sirva frio.', 'Salada de quinoa', 30);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdReceita', N'Calorias', N'Descricao', N'Ingredientes', N'ModoPreparo', N'NomeReceita', N'TempoPreparoMinutos') AND [object_id] = OBJECT_ID(N'[TB_RECEITA]'))
    SET IDENTITY_INSERT [TB_RECEITA] OFF;
GO

UPDATE [TB_REFEICOES] SET [IdUsuario] = 2
WHERE [IdRefeicao] = 2;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_TB_OBJETIVO_IdUsuario] ON [TB_OBJETIVO] ([IdUsuario]);
GO

CREATE UNIQUE INDEX [IX_TB_CADASTRO_UsuarioId] ON [TB_CADASTRO] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240618230511_AnotherCreate', N'8.0.6');
GO

COMMIT;
GO

