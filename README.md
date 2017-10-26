SOBE

CREATE TABLE Disciplina
    ID INT NOT NULL,
    Nome Varchar(40),
    PRIMARY KEY (ID);

CREATE TABLE Aluno
    ID INT NOT NULL,
    Nome Varchar(40),
    Email Varchar(40),
    PRIMARY KEY (ID);

CREATE TABLE Notas
    ID INT NOT NULL,
    Disciplina_ID INT,
    Aluno_ID INT,
    Nota INT,
    Frequencia INT,
    FOREIGN KEY (Disciplina_ID)
        REFERENCES Disciplina(ID),
    FOREIGN KEY (Aluno_ID)
        REFERENCES Aluno(ID)


