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




import collections, re
texts = ['John likes to watch movies. Mary likes too.', 'John also likes to watch football games.']
bagsofwords = [ collections.Counter(re.findall(r'\w+', txt)) for txt in texts]
bagsofwords[0]
bagsofwords[1]
sumbags = sum(bagsofwords, collections.Counter())
sumbags
