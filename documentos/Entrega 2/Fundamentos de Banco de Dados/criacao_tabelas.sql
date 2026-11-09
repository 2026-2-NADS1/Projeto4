-- ARCOR: Desafio das Marcas
-- Modelagem física (MySQL) - Entrega 2 de Fundamentos de Banco de Dados

CREATE DATABASE IF NOT EXISTS desafio_marcas;
USE desafio_marcas;

CREATE TABLE marca (
  id_marca INT AUTO_INCREMENT PRIMARY KEY,
  nome VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE produto (
  id_produto INT AUTO_INCREMENT PRIMARY KEY,
  nome VARCHAR(100) NOT NULL,
  id_marca INT NOT NULL,
  FOREIGN KEY (id_marca) REFERENCES marca(id_marca)
);

CREATE TABLE pergunta (
  id_pergunta INT AUTO_INCREMENT PRIMARY KEY,
  enunciado VARCHAR(300) NOT NULL,
  tipo ENUM('multipla_escolha','verdadeiro_falso') NOT NULL,
  dificuldade ENUM('facil','medio','dificil') NOT NULL,
  info_educativa VARCHAR(300),
  ativa BOOLEAN NOT NULL DEFAULT TRUE,
  id_marca INT NOT NULL,
  id_produto INT NULL,
  FOREIGN KEY (id_marca) REFERENCES marca(id_marca),
  FOREIGN KEY (id_produto) REFERENCES produto(id_produto)
);

CREATE TABLE alternativa (
  id_alternativa INT AUTO_INCREMENT PRIMARY KEY,
  id_pergunta INT NOT NULL,
  texto VARCHAR(200) NOT NULL,
  correta BOOLEAN NOT NULL DEFAULT FALSE,
  FOREIGN KEY (id_pergunta) REFERENCES pergunta(id_pergunta)
);

CREATE TABLE jogador (
  id_jogador INT AUTO_INCREMENT PRIMARY KEY,
  nickname VARCHAR(30) NOT NULL
);

CREATE TABLE partida (
  id_partida INT AUTO_INCREMENT PRIMARY KEY,
  id_jogador INT NOT NULL,
  data_hora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  pontuacao INT NOT NULL DEFAULT 0,
  FOREIGN KEY (id_jogador) REFERENCES jogador(id_jogador)
);

CREATE TABLE partida_pergunta (
  id_partida INT NOT NULL,
  id_pergunta INT NOT NULL,
  id_alternativa_escolhida INT NULL,
  PRIMARY KEY (id_partida, id_pergunta),
  FOREIGN KEY (id_partida) REFERENCES partida(id_partida),
  FOREIGN KEY (id_pergunta) REFERENCES pergunta(id_pergunta),
  FOREIGN KEY (id_alternativa_escolhida) REFERENCES alternativa(id_alternativa)
);

-- Carga inicial de exemplo
INSERT INTO marca (nome) VALUES ('Tortuguita'), ('Triunfo');
