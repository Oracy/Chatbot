SOBE
```sql
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
```


```python
import collections, re
texts = ['John likes to watch movies. Mary likes too.', 'John also likes to watch football games.']
bagsofwords = [ collections.Counter(re.findall(r'\w+', txt)) for txt in texts]
bagsofwords[0]
bagsofwords[1]
sumbags = sum(bagsofwords, collections.Counter())
sumbags



>>> from sklearn.cluster import KMeans
>>> import numpy as np
>>> X = np.array([[1, 2], [1, 4], [1, 0],
...               [4, 2], [4, 4], [4, 0]])
>>> kmeans = KMeans(n_clusters=2, random_state=0).fit(X)
>>> kmeans.labels_
array([0, 0, 0, 1, 1, 1], dtype=int32)
>>> kmeans.predict([[0, 0], [4, 4]])
array([0, 1], dtype=int32)
>>> kmeans.cluster_centers_
array([[ 1.,  2.],
       [ 4.,  2.]])
```       
       http://scikit-learn.org/stable/modules/generated/sklearn.cluster.KMeans.html
       
       
       
       
```python   
# Import libs to work
import numpy as np
from sklearn.naive_bayes import GaussianNB

# Create two numpy array
x = np.array()
y = np.array()

# Create a var that get the how much file will be use to train
with open('Training_Files_Ok.txt') as training:
      train = len(training.readlines())

# Create a var that get the how much file will be use to train
with open('Training_Files_NOk.txt') as training:
      train = len(training.readlines())

# Append the files that is classified to group 1 (Yes) 
for i in range(1, train):
    with open('Training_Files_Ok.txt') as tf:
        for line in tf:
            data=myfile.read().replace('\n', '')
            x.append(data)
            y.append(1)

# Append the files that is classified to group 2 (No) 
for i in range(1, train):
    with open('Training_Files_NOk.txt') as tf:
        for line in tf:
            data=myfile.read().replace('\n', '')
            x.append(data)
            y.append(2)
        
#X = np.array([[-1, -1], [-2, -1], [-3, -2], [1, 1], [2, 1], [3, 2]])
#Y = np.array([1, 1, 1, 2, 2, 2])

# Create a Gaussian Classifier
model = GaussianNB()

# Train the model using the training sets 
model.fit(X, Y)





# Create a var that get the how much file will be use to test
with open('Test_Files.txt') as testing:
      train = len(testing.readlines())

# Append the files that will be test 
for i in range(1, train):
    with open('Test_Files.txt') as tf:
        for line in tf:
            data=myfile.read().replace('\n', '')
            x.append(data)


#print(model.predict([[-0.8, -1]]))
for i in range(1, )
print(model.predict())
```





Sexta 

13:30h Credenciamento

14h WarmUP

14:30 Painel de abertura

15:45 Network

16h Inteligencia e computação cognitiva, analise de dados em midias sociais, analytics

17h Marketing digital que gera resultados reais, neuromarketing

18h Marketing digital que gera resultados reais, marketing digital para startups, vendas para as startups

19h Como tirar ideias do papel

20h ...

21h Network

Sábado

08:30 Credenciamento

09h Onde nascem as ideias do amanhã

10h Design Sprint - Pratique os 5 passos da metodologia Google para inovação, Como ser um influenciador digital, feel in the future.

11h Como nascer global.













```python
# Import libs to work
import numpy as np
from sklearn.naive_bayes import GaussianNB
import timeit

timeit.timeit(
    # Create two numpy array to train
    trainB = np.array([])
    trainA = np.array([])

    # Create one numpy array to test
    testB = np.array([])

    # Create a var that get the how much file will be use to train
    with open('Training_Files_Ok.txt') as training:
        train = len(training.readlines())

    # Create a var that get the how much file will be use to train
    with open('Training_Files_NOk.txt') as training:
        train = len(training.readlines())

    # Append the files that is classified to group 1 (Yes) 
    for i in range(1, train):
        with open('Training_Files_Ok.txt') as tf:
            for line in tf:
                data=myfile.read().replace('\n', '')
                x.append(data)
                y.append(1)

    # Append the files that is classified to group 2 (No) 
    for i in range(1, train):
        with open('Training_Files_NOk.txt') as tf:
            for line in tf:
                data=myfile.read().replace('\n', '')
                x.append(data)
                y.append(2)
            
    # X = np.array([[-1, -1], [-2, -1], [-3, -2], [1, 1], [2, 1], [3, 2]])
    # Y = np.array([1, 1, 1, 2, 2, 2])

    # Create a Gaussian Classifier
    model = GaussianNB()

    # Train the model using the training sets 
    model.fit(X, Y)

    # Create a var that get the how much file will be use to test
    with open('Test_Files.txt') as testing:
        test = len(testing.readlines())

    # Append the files that will be test 
    for i in range(1, test):eu
        with open('Test_Files.txt') as tf:
            for line in tf:
                data=myfile.read().replace('\n', '')
                x.append(data)


    # print(model.predict([[-0.8, -1]]))
    for i in range(1, test)
        print(model.predict([x[i]]))
)
```


http://ankitbko.github.io/2016/08/ChatBot-using-Microsoft-Bot-Framework-Part-1


O objetivo deste paper é criar um framework para auxiliar as empresas de um modo em que mudassem o mindset para Data Driven Decision, através deste roadmap desenvolvido pelos pesquisadores.
